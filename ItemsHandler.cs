using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;

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
            selectedItemID = matchingIDs.ElementAt(0);
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
            return images[selectedImage];
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

                //get the document from google. this will not be the same as the one
                //rendered for a normal web browser
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument hdoc = hw.Load("https://patents.google.com/patent/US" + identifier);

                //get the image source links from their xpath
                string imageXpath = "/html/body/search-app/article/section[1]/ul/li/meta";
                HtmlNodeCollection images = hdoc.DocumentNode.SelectNodes(imageXpath);
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

                //get the text sections from their xpaths
                string titleXpath = "/html/body/search-app/article/span";
                title = hdoc.DocumentNode.SelectSingleNode(titleXpath).InnerHtml;
                itemData.addItemComponent(id, "Title", title);

                string abstractXpath = "//*[@id=\"p-0001\"]";
                abstractText = hdoc.DocumentNode.SelectSingleNode(abstractXpath).InnerHtml;
                itemData.addItemComponent(id, "Abstract", abstractText);

                string descriptionXpath = "/html/body/search-app/article/section[4]/div/div";
                description = hdoc.DocumentNode.SelectSingleNode(descriptionXpath).InnerHtml;
                itemData.addItemComponent(id, "Description", description);

                string claimsXpath = "/html/body/search-app/article/section[5]/div/div";
                claims = hdoc.DocumentNode.SelectSingleNode(claimsXpath).InnerHtml;
                itemData.addItemComponent(id, "Claims", claims);


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
