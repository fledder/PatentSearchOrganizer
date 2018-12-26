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

        public void addItem(string type, string identifier, string fetchLink, string relevance)
        {
            DataRow r = itemData.Tables["items"].NewRow();
            r["type"] = type;
            r["identifier"] = identifier;
            r["fetchLink"] = fetchLink;
            r["relevance"] = relevance;
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

        public void updateTreeData(System.Windows.Forms.TreeView tree)
        {
            tree.Nodes.Clear();
            EnumerableRowCollection<ItemDataset.itemsRow> lines = from item in itemData.items select item;
            foreach(ItemDataset.itemsRow row in lines)
            {
                System.Windows.Forms.TreeNode parentNode = tree.Nodes.Add(row.id.ToString(), row.identifier);
                parentNode.Nodes.Add("References");
                parentNode.Nodes.Add("Referenced By");
            }
        }

        public void searchCPC(string dataSource, string searchTerm)
        {
            if(dataSource == "Google Patents")
            {
                string url = "https://patents.google.com/xhr/query?url=q%3Dcpc%253d" + WebUtility.UrlEncode(searchTerm);
                using (WebClient client = new WebClient())
                {
                    string resultString = client.DownloadString(url);
                    JObject result = JObject.Parse(resultString);
                    JToken cluster = result.SelectToken("results.cluster[0]").Children().First();
                }
            }
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

        public Item(Int32 id)
        {
            this.id = id;
            this.selectedImage = 0;
            this.images = new List<byte[]>();
        }
        
        public void retrieveData(string selectedDataSource, ItemDataset itemData)
        {

            string identifier = (from item in itemData.items where item.id == id select item.identifier).ElementAt(0);
            if(selectedDataSource == "Google Patents")
            {
                //Delete the old data. May need to make this more specific...
                DataTable itemComponents = itemData.Tables["itemComponents"];
                foreach (DataRow dataRow in itemComponents.Rows)
                {
                    if ((Int32)dataRow["itemID"] == id)
                    {
                        dataRow.Delete();
                    }
                }
                itemData.AcceptChanges();

                fetchLink = "https://patents.google.com/patent/US" + identifier;

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
                title = hdoc.DocumentNode.SelectSingleNode(titleXpath).InnerHtml;
                itemData.addItemComponent(id, "Title", title);

                string abstractXpath = "/html/body/search-app/article/section[3]/div/abstract/div";
                HtmlNode abstractNode = hdoc.DocumentNode.SelectSingleNode(abstractXpath);
                if(abstractNode != null)
                {
                    abstractText = abstractNode.InnerHtml;
                    itemData.addItemComponent(id, "Abstract", abstractText);
                }
                
                string descriptionXpath = "/html/body/search-app/article/section[4]/div/div";
                description = hdoc.DocumentNode.SelectSingleNode(descriptionXpath).InnerHtml;
                itemData.addItemComponent(id, "Description", description);

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

            if(dataSource == "Google Patents")
            {
                string identifier = (from item in itemData.items where item.id == id select item.identifier).ElementAt(0);
                fetchLink = "https://patents.google.com/patent/US" + identifier;

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

                                    Regex patnoRx = new Regex(@"US(\d{7})[A-Z]\d");
                                    Match patMatch = patnoRx.Match(text);

                                    if (patMatch.Success)
                                    {
                                        newRefIdentifier = patMatch.Groups[1].Value;
                                    }
                                    else
                                    {
                                        Regex pubnoRx = new Regex(@"US(\d{11})[A-Z]\d");
                                        Match pubMatch = pubnoRx.Match(text);
                                        if (pubMatch.Success)
                                        {
                                            newRefIdentifier = pubMatch.Groups[1].Value;
                                        }
                                        else
                                        {
                                            newRefIdentifier = "";
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
            }
        }
    }
}
