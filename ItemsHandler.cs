using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PatentSearchOrganizer
{
    public enum Relevance { None = 0, Minimal = 10, Moderate = 20, High = 30, Unreviewed = 100};

    class Constants
    {
        public static string GoogleUSPatentRegex = @"US(\d{6,8})[A-Z]?\d?$";
        public static string GoogleUSDocumentRegex = @"US(\d{11})[A-Z]?\d?$";
        public static string BareUSPatentRegex = @"^(\d{6,8})[A-Z]?\d?$";
        public static string BareUSDocumentRegex = @"^(\d{11})[A-Z]?\d?$";
        public static string ExtractUSPatentRegex = @"US(\d{6,8})[A-Z]?\d?";
        public static string ExtractUSDocumentRegex = @"US(\d{11})[A-Z]?\d?";
    }

    class ItemsHandler
    {
        public ItemDataset itemData;
        private Int32 selectedItemID;

        //getters, setters, selectors
        public void selectNextItem()
        {
            selectedItemID++;
        }

        public void selectPreviousItem()
        {
            selectedItemID--;
        }

        public void selectItem(int selection)
        {
            selectedItemID = selection;
        }

        public ItemsHandler()
        {
            itemData = new ItemDataset();
            selectedItemID = -1;
        }

        public void addItem(string type, string identifier, string fetchLink, Relevance relevance)
        {
            DataRow r = itemData.Tables["items"].NewRow();
            r["type"] = type;
            r["identifier"] = identifier;
            r["fetchLink"] = fetchLink;
            r["relevance"] = (int)relevance;
            itemData.Tables["items"].Rows.Add(r);
            r.AcceptChanges();
        }

        public void selectItemByIdentifier(string identifier)
        {
            EnumerableRowCollection<int> matchingIDs = from item in itemData.items where item.identifier == identifier select item.id;
            if (matchingIDs.Count() > 0)
            {
                selectedItemID = matchingIDs.First();
            }
        }

        public Item getSelectedItem()
        {
            Item returnItem = new Item(selectedItemID);
            returnItem.updateFromLocal(itemData);
            return returnItem;
        }

        public void save(string filePath)
        {
            itemData.WriteXml(filePath);
        }

        public void load(string filePath)
        {
            itemData.Clear();
            itemData.ReadXml(filePath);
        }

        public void updateTreeData(System.Windows.Forms.TreeView tree, bool showNotRelevant)
        {
            tree.Nodes.Clear();
            EnumerableRowCollection<ItemDataset.itemsRow> lines =  from item in itemData.items where item.relevance > (int)Relevance.None orderby item.relevance descending, item.identifier ascending select item;
            if (showNotRelevant)
            {
                lines = from item in itemData.items orderby item.relevance descending, item.identifier ascending select item;
            }
            foreach(ItemDataset.itemsRow row in lines)
            {
                System.Windows.Forms.TreeNode parentNode = tree.Nodes.Add(row.id.ToString(), row.identifier);
                switch ((Relevance)row.relevance)
                {
                    case Relevance.Unreviewed:
                        parentNode.BackColor = System.Drawing.Color.Black;
                        parentNode.ForeColor = System.Drawing.Color.White;
                        break;
                    case Relevance.High:
                        parentNode.BackColor = System.Drawing.Color.DarkRed;
                        parentNode.ForeColor = System.Drawing.Color.White;
                        break;
                    case Relevance.Moderate:
                        parentNode.BackColor = System.Drawing.Color.Yellow;
                        parentNode.ForeColor = System.Drawing.Color.Black;
                        break;
                    case Relevance.Minimal:
                        parentNode.BackColor = System.Drawing.Color.DarkBlue;
                        parentNode.ForeColor = System.Drawing.Color.White;
                        break;
                    case Relevance.None:
                        parentNode.BackColor = System.Drawing.Color.DarkGray;
                        parentNode.ForeColor = System.Drawing.Color.LightGray;
                        break;
                }
                parentNode.Nodes.Add("References");
                parentNode.Nodes.Add("Referenced By");
            }
        }

        public void searchCPC(string dataSource, string searchTerm)
        {
            historyItem h = new historyItem("CPC Search", searchTerm, itemData);

            if (dataSource == "Google Patents")
            {
                void parseResult(JObject result)
                {
                    JToken cluster = result.SelectToken("results.cluster[0]").Children().First();
                    JToken resultItemList = cluster.Children().First();
                    foreach (JToken resultItem in resultItemList)
                    {
                        string resultIdentifier = resultItem.SelectToken("patent.publication_number").ToString();
                        EnumerableRowCollection<int> existingResults = from item in itemData.items where item.identifier == resultIdentifier select item.id;
                        if (existingResults.Count() == 0)
                        {
                            EnumerableRowCollection<ItemDataset.itemsRow> refExistRows;
                            Regex patnoRx = new Regex(Constants.GoogleUSPatentRegex);
                            Match patMatch = patnoRx.Match(resultIdentifier);
                            string refIdentifier = "";
                            string refType = "";
                            if (patMatch.Success)
                            {
                                refType = "US Patent";
                                refIdentifier = patMatch.Groups[1].Value;
                            }
                            else
                            {
                                Regex pubnoRx = new Regex(Constants.GoogleUSDocumentRegex);
                                Match pubMatch = pubnoRx.Match(resultIdentifier);
                                if (pubMatch.Success)
                                {
                                    refType = "US Publication";
                                    refIdentifier = pubMatch.Groups[1].Value;
                                }
                                else
                                {
                                    refType = "Unknown";
                                    refIdentifier = resultIdentifier;
                                }
                            }
                            refExistRows = from item in itemData.items where item.identifier == refIdentifier select item;
                            if(refExistRows.Count() == 0)
                            {
                                DataRow newRow = itemData.Tables["items"].NewRow();
                                newRow["identifier"] = refIdentifier;
                                newRow["type"] = refType;
                                itemData.Tables["items"].Rows.Add(newRow);
                                itemData.Tables["items"].AcceptChanges();
                                int newID = (from item in itemData.items where item.identifier == refIdentifier select item.id).First();
                                itemData.addItemComponent(newID, "Title", resultItem.SelectToken("patent.title").ToString());
                            }
                        }
                    }
                }

                string getURL(string term, int page)
                {
                    return "https://patents.google.com/xhr/query?url=q%3Dcpc%253d" + WebUtility.UrlEncode(term) + "%26num%3D100%26page%3D" + page;
                }

                int currentPage = 0;
                string url = getURL(searchTerm, currentPage);
                using (WebClient client = new WebClient())
                {
                    string retrievedString = client.DownloadString(url);
                    JObject result = JObject.Parse(retrievedString);
                    int numPages = int.Parse(result.SelectToken("results.total_num_pages").ToString());
                    parseResult(result);
                    if (numPages > 1)
                    {
                        for (currentPage = 1; currentPage < numPages; currentPage++)
                        {
                            url = getURL(searchTerm, currentPage);
                            retrievedString = client.DownloadString(url);
                            result = JObject.Parse(retrievedString);
                            parseResult(result);
                        }
                    }
                }
            }
        }

        public void fetchAll(string dataSource)
        {
            foreach(DataRow row in itemData.Tables["items"].Rows)
            {
                if((row["fetchLink"] == null || row["fetchLink"].ToString() == "") && (Relevance)row["relevance"] != Relevance.None)
                {
                    Item item = new Item((int)row["id"]);
                    item.retrieveData("Google Patents", itemData);
                }
            }
        }

        public void removeIrrelevantData()
        {
            foreach(ItemDataset.itemsRow row in itemData.Tables["items"].Rows)
            {
                if ((Relevance)row.relevance == Relevance.None)
                {
                    foreach (ItemDataset.itemComponentsRow deleteRow in itemData.Tables["itemComponents"].Select("itemID = " + row.id + " and componentType <> 'Title'"))
                    {
                        deleteRow.Delete();
                    }
                }
            }
            itemData.AcceptChanges();
        }
    }

    class Item
    {
        private Int32 id;
        private string title;
        private string abstractText;
        private string description;
        private string claims;
        private List<byte[]> images;
        private int selectedImage;
        private string fetchLink;
        private Relevance relevance;
        private string notes;
        private string identifier;
        private byte[] pdf;

        //Getters, setters, selectors
        public string getTitle()
        {
            return title;
        }

        public string getAbstract()
        {
            return abstractText;
        }

        public string getDescription()
        {
            return description;
        }

        public string getClaims()
        {
            return claims;
        }

        public byte[] getSelectedImage()
        {
            if (images.Count() > 0)
            {
                return images[selectedImage];
            }
            else
            {
                return new byte[0];
            }
        }

        public void selectNextImage()
        {
            selectedImage++;
            if(selectedImage >= images.Count)
            {
                selectedImage = images.Count - 1;
            }
        }

        public void selectPreviousImage()
        {
            selectedImage--;
            if(selectedImage < 0)
            {
                selectedImage = 0;
            }
        }

        public void selectImage(int selection)
        {
            selectedImage = selection;
        }

        public void selectLastImage()
        {
            selectedImage = images.Count - 1;
        }

        public Relevance getRelevance()
        {
            return relevance;
        }

        public string getNotes()
        {
            return notes ?? "";
        }

        public Item(Int32 id)
        {
            this.id = id;
            this.selectedImage = 0;
            this.images = new List<byte[]>();
        }

        public byte[] getPDF()
        {
            return pdf;
        }
        
        public string getIdentifier()
        {
            return identifier;
        }

        public void retrieveData(string selectedDataSource, ItemDataset itemData)
        {

            identifier = (from item in itemData.items where item.id == id select item.identifier).ElementAt(0);
            if(selectedDataSource == "Google Patents")
            {
                //Delete the old data. May need to make this more specific...
                DataTable itemComponents = itemData.Tables["itemComponents"];
                DataRow[] itemComponentsToDelete = itemComponents.Select("itemID = " + id);
                foreach (DataRow dataRow in itemComponentsToDelete)
                {
                    if ((Int32)dataRow["itemID"] == id)
                    {
                        dataRow.Delete();
                    }
                }
                itemData.AcceptChanges();

                fetchLink = "https://patents.google.com/patent/US" + identifier;
                DataRow itemRow = itemData.Tables["items"].Select("id = " + id).First();
                itemRow["fetchLink"] = fetchLink;
                itemRow.AcceptChanges();

                //get the document from google. this will not be the same as the one
                //rendered for a normal web browser
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument hdoc = hw.Load(fetchLink);

                //get the image source links from their xpath
                string imageXpath = "/html/body/search-app/article/section[1]/ul/li/meta";
                HtmlNodeCollection images = hdoc.DocumentNode.SelectNodes(imageXpath);
                if(images != null && images.Count() > 0)
                {
                    using (WebClient client = new WebClient())
                    {
                        foreach (HtmlNode node in images)
                        {
                            string itempropValue = node.Attributes["itemprop"].Value;

                            if (node.Attributes["itemprop"].Value == "full")
                            {
                                string imgSource = node.Attributes["content"].Value;
                                byte[] image = client.DownloadData(imgSource);
                                DataRow newRow = itemComponents.NewRow();
                                newRow["itemID"] = id;
                                newRow["componentType"] = "Figure Image";
                                newRow["fileExtension"] = "png";
                                newRow["componentData"] = image;
                                itemComponents.Rows.Add(newRow);
                                newRow.AcceptChanges();
                            }
                        }
                    }
                }
                
                //get the text sections from their xpaths
                string titleXpath = "/html/body/search-app/article/span";
                HtmlNode titleNode = hdoc.DocumentNode.SelectSingleNode(titleXpath);
                if(titleNode != null)
                {
                    title = titleNode.InnerHtml;
                    itemData.addItemComponent(id, "Title", title);
                }
                string abstractXpath = "/html/body/search-app/article/section[3]/div/abstract/div";
                HtmlNode abstractNode = hdoc.DocumentNode.SelectSingleNode(abstractXpath);
                if(abstractNode != null)
                {
                    abstractText = abstractNode.InnerHtml;
                    itemData.addItemComponent(id, "Abstract", abstractText);
                }
                
                string descriptionXpath = "/html/body/search-app/article/section[4]/div/div";
                HtmlNode descriptionNode = hdoc.DocumentNode.SelectSingleNode(descriptionXpath);
                if (descriptionNode != null)
                {
                    description = descriptionNode.InnerHtml;
                    itemData.addItemComponent(id, "Description", description);
                }

                string claimsXpath = "/html/body/search-app/article/section[5]/div/div";
                HtmlNode claimsNode = hdoc.DocumentNode.SelectSingleNode(claimsXpath);
                if(claimsNode != null)
                {
                    claims = claimsNode.InnerHtml;
                    itemData.addItemComponent(id, "Claims", claims);
                }
            }
        }

        public void retrieveReferences(string dataSource, ItemDataset itemData)
        {
            updateFromLocal(itemData);

            

            if (dataSource == "Google Patents")
            {
                identifier = (from item in itemData.items where item.id == id select item.identifier).ElementAt(0);

                historyItem h = new historyItem("Reference Fetch", identifier, itemData);

                if (Regex.Match(identifier, Constants.BareUSDocumentRegex).Success || Regex.Match(identifier, Constants.BareUSPatentRegex).Success)
                {
                    fetchLink = "https://patents.google.com/patent/US" + identifier;
                }
                else
                {
                    fetchLink = "https://patents.google.com/patent/" + identifier;
                }

                //get the document from google. this will not be the same as the one
                //rendered for a normal web browser
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument hdoc = hw.Load(fetchLink);

                string sectionXpath = "/html/body/search-app/article/section";
                HtmlNodeCollection section = hdoc.DocumentNode.SelectNodes(sectionXpath);

                foreach(HtmlNode node in section)
                {
                    HtmlNode heading = node.SelectSingleNode("h2");
                    HtmlNode table = node.SelectSingleNode("table");
                    string refType = "Unknown";
                    string direction = "Unknown";
                    if(heading.InnerHtml.Contains("Citations"))
                    {
                        refType = "Citation";
                        direction = "Forward";
                    }
                    else if(heading.InnerHtml.Contains("Cited By"))
                    {
                        refType = "Citation";
                        direction = "Backward";
                    }
                    else if(heading.InnerHtml.Contains("Similar Documents"))
                    {
                        refType = "Similar";
                        direction = "Forward";
                    }
                    if(refType != "Unknown")
                    {
                        HtmlNodeCollection rows = table.SelectNodes("tbody/tr");
                        foreach(HtmlNode row in rows)
                        {
                            HtmlNodeCollection cells = row.SelectNodes("td");
                            string newRefIdentifier = "";
                            string newRefTitle = "";
                            foreach(HtmlNode cell in cells)
                            {
                                HtmlNode link = cell.SelectSingleNode("a");
                                if(link != null)
                                {
                                    string text = link.Attributes["href"].Value;

                                    Regex patnoRx = new Regex(Constants.ExtractUSPatentRegex);
                                    Match patMatch = patnoRx.Match(text);

                                    if (patMatch.Success)
                                    {
                                        newRefIdentifier = patMatch.Groups[1].Value;
                                    }
                                    else
                                    {
                                        Regex pubnoRx = new Regex(Constants.ExtractUSDocumentRegex);
                                        Match pubMatch = pubnoRx.Match(text);
                                        if (pubMatch.Success)
                                        {
                                            newRefIdentifier = pubMatch.Groups[1].Value;
                                        }
                                        else
                                        {
                                            string[] parts = text.Split('/');
                                            newRefIdentifier = parts[2];
                                        }
                                    }
                                }
                                else if(cell.Attributes.Count > 0 && cell.Attributes["itemprop"].Value == "title")
                                {
                                    string text = cell.InnerHtml;
                                    newRefTitle = text;
                                }
                            }

                            if(newRefIdentifier.Length > 0)
                            {
                                EnumerableRowCollection<int> newRefIDRows = from item in itemData.items where item.identifier == newRefIdentifier select item.id;
                                if (newRefIDRows.Count() > 0)
                                {
                                    int newRefID = newRefIDRows.First();

                                    if (direction == "Forward")
                                    {
                                        itemData.addItemRelation(this.id, newRefID, refType);
                                    }
                                    else
                                    {
                                        itemData.addItemRelation(newRefID, this.id, refType);
                                    }
                                }
                                else
                                {
                                    DataRow newItemRow = itemData.Tables["items"].NewRow();
                                    newItemRow["identifier"] = newRefIdentifier;
                                    newItemRow["type"] = "US Patent";
                                    itemData.Tables["items"].Rows.Add(newItemRow);
                                    itemData.Tables["items"].AcceptChanges();
                                    int newRefID = (from item in itemData.items where item.identifier == newRefIdentifier select item.id).First();
                                    itemData.addItemComponent(newRefID, "Title", newRefTitle);
                                    if (direction == "Forward")
                                    {
                                        itemData.addItemRelation(this.id, newRefID, refType);
                                    }
                                    else
                                    {
                                        itemData.addItemRelation(newRefID, this.id, refType);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void updateFromLocal(ItemDataset itemData)
        {
            EnumerableRowCollection<ItemDataset.itemComponentsRow> matchingData = from itemComponent in itemData.itemComponents where itemComponent.itemID == id select itemComponent;
            foreach(ItemDataset.itemComponentsRow row in matchingData)
            {
                if(row.componentType == "Title")
                {
                    title = row.componentStringValue;
                }
                else if(row.componentType == "Abstract")
                {
                    abstractText = row.componentStringValue;
                } 
                else if(row.componentType == "Description")
                {
                    description = row.componentStringValue;
                }
                else if(row.componentType == "Claims")
                {
                    claims = row.componentStringValue;
                }
                else if(row.componentType == "Figure Image")
                {
                    images.Add(row.componentData);
                }
                else if(row.componentType == "PDF")
                {
                    pdf = row.componentData;
                }
            }
            ItemDataset.itemsRow itemRow = (from item in itemData.items where item.id == id select item).First();
            identifier = itemRow.identifier;
            if (itemRow["notes"] != null)
            {
                notes = itemRow["notes"].ToString();
            }
            else
            {
                notes = "";
            }
            //EnumerableRowCollection<string> itemNotes = from item in itemData.items where item.id == id select item.notes;
            //notes = itemNotes.First() ?? "";
        }

        public void setRelevance(Relevance relevanceInput, ItemDataset dataset)
        {
            relevance = relevanceInput;
            DataRow updateRow = dataset.Tables["items"].Select("id = " + id).First();
            updateRow["relevance"] = (int)relevanceInput;
            updateRow.AcceptChanges();
        }

        public void setNotes(string notesInput, ItemDataset dataset)
        {
            notes = notesInput;
            DataRow updateRow = dataset.Tables["items"].Select("id = " + id).First();
            updateRow["notes"] = notesInput;
            updateRow.AcceptChanges();
        }

        public void deleteItem(ItemDataset dataset)
        {
            DataRow deleteRow = dataset.Tables["items"].Select("id = " + id).First();
            deleteRow.Delete();
            dataset.AcceptChanges();
        }

        public void retrievePDF(string dataSource, ItemDataset dataset)
        {
            if (dataSource == "USPTO")
            {
                string groupA;
                string groupB;
                string groupC;
                string groupD;

                updateFromLocal(dataset);

                Regex patnoRx = new Regex(Constants.BareUSPatentRegex);
                Match patMatch = patnoRx.Match(identifier);
                Regex pubnoRx = new Regex(Constants.BareUSDocumentRegex);
                Match pubMatch = pubnoRx.Match(identifier);

                if (patMatch.Success)
                {
                    string paddedIdentifier = Int64.Parse(identifier).ToString("00000000");
                    groupA = paddedIdentifier.Substring(0, 3);
                    groupB = paddedIdentifier.Substring(3, 3);
                    groupC = paddedIdentifier.Substring(6, 2);
                    string fetchURL = "http://pimg-fpiw.uspto.gov/fdd/" + groupC + "/" + groupB + "/" + groupA + "/0.pdf";
                    using (WebClient client = new WebClient())
                    {
                        pdf = client.DownloadData(fetchURL);
                    }
                    DataRow newRow = dataset.Tables["itemComponents"].NewRow();
                    newRow["itemID"] = id;
                    newRow["componentType"] = "PDF";
                    newRow["componentData"] = pdf;
                    dataset.Tables["itemComponents"].Rows.Add(newRow);
                    dataset.AcceptChanges();
                }
                else if (pubMatch.Success)
                {
                    string paddedIdentifier = Int64.Parse(identifier).ToString("00000000000");
                    groupA = paddedIdentifier.Substring(0, 4);
                    groupB = paddedIdentifier.Substring(4, 3);
                    groupC = paddedIdentifier.Substring(7, 2);
                    groupD = paddedIdentifier.Substring(9, 2);
                    string fetchURL = "http://pimg-faiw.uspto.gov/fdd/" + groupD + "/" + groupA + "/" + groupC + "/" + groupB + "/0.pdf";
                    using (WebClient client = new WebClient())
                    {
                        pdf = client.DownloadData(fetchURL);
                    }
                    DataRow newRow = dataset.Tables["itemComponents"].NewRow();
                    newRow["itemID"] = id;
                    newRow["componentType"] = "PDF";
                    newRow["componentData"] = pdf;
                    dataset.Tables["itemComponents"].Rows.Add(newRow);
                    dataset.AcceptChanges();
                }
            }
            else if (dataSource == "Google Patents")
            {
                if (Regex.Match(identifier, @"^\d*$").Success)
                {
                    fetchLink = "https://patents.google.com/patent/US" + identifier;
                }
                else
                {
                    fetchLink = "https://patents.google.com/patent/" + identifier;
                }
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument detailsDocument = hw.Load(fetchLink);
                HtmlNodeCollection linkCandidates = detailsDocument.DocumentNode.SelectNodes("/html/body/search-app/article/a");
                string pdfFetchLink = "";
                if(linkCandidates != null && linkCandidates.Count() > 0)
                {
                    foreach (HtmlNode node in linkCandidates)
                    {
                        if (node.InnerHtml.Contains("Download PDF"))
                        {
                            pdfFetchLink = node.Attributes["href"].Value;
                        }
                    }
                    if (pdfFetchLink.Length > 0)
                    {
                        using (WebClient client = new WebClient())
                        {
                            byte[] pdfData = client.DownloadData(pdfFetchLink);
                            DataRow newRow = dataset.Tables["itemComponents"].NewRow();
                            newRow["itemID"] = id;
                            newRow["componentType"] = "PDF";
                            newRow["componentData"] = pdfData;
                            dataset.Tables["itemComponents"].Rows.Add(newRow);
                            dataset.AcceptChanges();
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Could not find patent in Google Patents", "PDF Not Found");
                }
            }
        }
    }

    class historyItem
    {
        int id;
        DateTime timestamp;
        string type;
        string query;

        public historyItem(int id, ItemDataset i)
        {
            this.id = id;
            this.getDataFromDatabase(id, i);
        }

        public historyItem(string type, string query, ItemDataset i)
        {
            this.type = type;
            this.query = query;
            this.timestamp = System.DateTime.Now;
            this.storeNewRecord(i);
        }

        public void getDataFromDatabase(int id, ItemDataset i)
        {
            ItemDataset.historyDataTable h = i.history;
            ItemDataset.historyRow r = (from ItemDataset.historyRow item in h.Rows where item.id == id select item).First();
            this.timestamp = r.timestamp;
            this.type = r.type;
            this.query = r.query;
        }

        public void storeNewRecord(ItemDataset i)
        {
            ItemDataset.historyDataTable h = i.history;
            ItemDataset.historyRow newRow = h.NewhistoryRow();
            newRow.timestamp = this.timestamp;
            newRow.type = this.type;
            newRow.query = this.query;
            h.Rows.Add(newRow);
            h.AcceptChanges();
        }
    }

    class Historian
    {
        public List<historyItem> historyItems;

        public Historian(ItemDataset i)
        {
            this.historyItems = new List<historyItem>();
            this.refresh(i);
        }

        public void refresh(ItemDataset i)
        {
            ItemDataset.historyDataTable h = i.history;
            this.historyItems.Clear();
            foreach (ItemDataset.historyRow row in h.Rows)
            {
                this.historyItems.Add(new historyItem(row.id, i));
            }
        }

        public void getListViewData(System.Windows.Forms.ListView v, ItemDataset i)
        {
            ItemDataset.historyDataTable h = i.history;
            v.Items.Clear();
            this.refresh(i);

            foreach (ItemDataset.historyRow row in h.Rows)
            {
                v.Items.Add(row.timestamp.ToLongDateString() + " " + row.timestamp.ToLongTimeString() + ": " + row.type + ": " + row.query);
            }
        }
    }
}
