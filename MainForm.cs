using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatentSearchOrganizer
{
    public partial class MainForm : Form
    {
        private ItemsHandler items;
        private Item selectedItem;
        private Historian history;
        private string filePath;
        private bool showNotRelevant;
        private int _selectedIndex;
        private int selectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                if(tree.Nodes.Count > 0 && items.itemData.Tables["items"].Rows.Count > 0)
                {
                    tree.SelectedNode = tree.Nodes[_selectedIndex];
                    items.selectItemByIdentifier(tree.SelectedNode.Text);
                    selectedItem = items.getSelectedItem();
                    refreshDisplays();
                }
            }
        }
        private bool moveToNext;
        private string pid;

        public MainForm()
        {
            InitializeComponent();
            pid = Process.GetCurrentProcess().Id.ToString();
            showNotRelevant = false;
            moveToNext = true;
            items = new ItemsHandler();
            //items.addItem("US Patent", "6789012", "https://example.com/9876543", Relevance.High);
            //items.selectItem(0);
            //selectedItem = items.getSelectedItem();
            //selectedItem.retrieveData("Google Patents", this.items.itemData);
            //selectedItem.retrieveReferences("Google Patents", this.items.itemData);
            //selectedItem = items.getSelectedItem();
            selectedItem = null;
            //selectedIndex = 0;
            refreshTree();
            history = new Historian(items.itemData);
            refreshDisplays();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            string folderPath = System.IO.Path.GetTempPath();
            DirectoryInfo di = new DirectoryInfo(folderPath);
            IEnumerable<string> fileList = di.GetFiles().Where(file => file.Name.StartsWith("pso_" + pid)).Select(file => file.Name);
            foreach(string path in fileList)
            {
                File.Delete(path);
            }
            base.OnFormClosing(e);
        }

        public void refreshTree()
        {
            items.updateTreeData(tree, showNotRelevant);
        }

        public void refreshFigures()
        {
            Stream figureImageStream = new MemoryStream(selectedItem.getSelectedImage());
            figurePictureBox.Image = null;
            if (figureImageStream.Length > 0)
            {
                Image figureImage = Image.FromStream(figureImageStream);
                figurePictureBox.Image = figureImage;
            }
        }

        public void refreshDisplays()
        {
            if (selectedItem != null)
            {
                selectedItem = items.getSelectedItem();
                itemTitle.Text = selectedItem.getIdentifier() + ": " + selectedItem.getTitle();
                itemAbstract.Text = selectedItem.getAbstract();
                claimsWebBrowser.Navigate("about:blank");
                claimsWebBrowser.Document.OpenNew(true);
                claimsWebBrowser.Document.Write(selectedItem.getClaims());
                refreshFigures();
                specificationBrowser.Navigate("about:blank");
                specificationBrowser.Document.OpenNew(true);
                specificationBrowser.Document.Write(selectedItem.getDescription());
                rtbNotes.Text = selectedItem.getNotes();
                byte[] pdfData = selectedItem.getPDF();
                wbPDF.Navigate("about:blank");
                if (pdfData != null && pdfData.Length > 0)
                {
                    string tempPath = System.IO.Path.GetTempPath();
                    string filePath = tempPath + "pso_" + pid + selectedItem.getIdentifier() + "tempfile.pdf";

                    bool written = false;
                    Stopwatch writeTimer = Stopwatch.StartNew();
                    while (writeTimer.ElapsedMilliseconds < 15000 && !written)
                    {
                        try
                        {
                            File.WriteAllBytes(filePath, pdfData);
                            written = true;
                        }
                        catch (IOException e)
                        {
                            if (e.HResult != -2147024864)
                            {
                                throw;
                            }
                            else
                            {
                                Thread.Sleep(500);
                            }
                        }
                    }
                    wbPDF.Navigate(filePath);
                }
                if (mainTabs.SelectedTab.Name == "tabEspacenet")
                {
                    string countryCode = selectedItem.getIdentifier().Substring(0, 2);
                    string patIdent = selectedItem.getIdentifier().Substring(2);
                    string espacenetUrl = "https://worldwide.espacenet.com/publicationDetails/originalDocument?CC=" + countryCode + "&NR=" + patIdent + "&KC=A&FT=D&ND=3&DB=&locale=en_EP#";

                    wbEspacenet.Navigate(espacenetUrl);
                }
                history.getListViewData(historyListView, items.itemData);
            }
        }


        private void firstImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectImage(0);
            refreshFigures();
        }

        private void previousImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectPreviousImage();
            refreshFigures();
        }

        private void nextImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectNextImage();
            refreshFigures();
        }

        private void lastImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectLastImage();
            refreshFigures();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(filePath != null)
            {
                items.save(filePath);
            }
            else
            {
                this.saveAs();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveAs();
        }

        private void saveAs()
        {
            SaveFileDialog filePathDialog = new SaveFileDialog();
            filePathDialog.ShowDialog();
            filePath = filePathDialog.FileName;
            items.save(filePath);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePathDialog = new OpenFileDialog();
            filePathDialog.ShowDialog();
            filePath = filePathDialog.FileName;
            items.load(filePath);
            refreshTree();
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*string selectedIdentifier = tree.SelectedNode.Text;
            items.selectItemByIdentifier(selectedIdentifier);
            selectedItem = items.getSelectedItem();
            refreshDisplays();*/
        }

        

        private void fetchDataGoogleButton_Click(object sender, EventArgs e)
        {
            selectedItem.retrieveData("Google Patents", items.itemData);
            selectedItem = items.getSelectedItem();
            refreshDisplays();
        }

        private void addUSButton_Click(object sender, EventArgs e)
        {
            string input = patPubTextBox.Text;
            if(input.Length == 7 || input.Length == 8)
            {
                items.addItem("US Patent", input, "", Relevance.Unreviewed);
            }
            else if(input.Length == 11)
            {
                items.addItem("US Publication", input, "", Relevance.Unreviewed);
            }
            history.historyItems.Add(new historyItem("Add Single Item", input, items.itemData));
            refreshTree();
            items.selectItemByIdentifier(input);
            selectedItem = items.getSelectedItem();
            selectedItem.retrieveData("Google Patents", items.itemData);
            refreshDisplays();
        }

        private void cpcSearchButton_Click(object sender, EventArgs e)
        {
            string term = cpcSearchTerm.Text;
            items.searchCPC("Google Patents", term);
            refreshTree();
            history.getListViewData(historyListView, items.itemData);
            historyListView.Refresh();
        }

        private void setRelevanceWrapper(Relevance relevance)
        {
            selectedItem.setRelevance(relevance, items.itemData);
            refreshTree();
            if (moveToNext) { selectedIndex = selectedIndex; }
        }

        private void pbHighlyRelevant_Click(object sender, EventArgs e)
        {
            setRelevanceWrapper(Relevance.High);
        }

        private void notYetReviewedButton_Click(object sender, EventArgs e)
        {
            setRelevanceWrapper(Relevance.Unreviewed);
        }

        private void pbModeratelyRelevant_Click(object sender, EventArgs e)
        {
            setRelevanceWrapper(Relevance.Moderate);
        }

        private void pbMinimallyRelevant_Click(object sender, EventArgs e)
        {
            setRelevanceWrapper(Relevance.Minimal);
        }

        private void pbNotRelevant_Click(object sender, EventArgs e)
        {
            setRelevanceWrapper(Relevance.None);
        }

        private void cbNonRelevant_CheckedChanged(object sender, EventArgs e)
        {
            showNotRelevant = cbNonRelevant.Checked;
            refreshTree();
            if (moveToNext) { selectedIndex = selectedIndex; }
        }

        private void pbFetchAllGoogle_Click(object sender, EventArgs e)
        {
            items.fetchAll("Google Patents");
            refreshDisplays();
            refreshTree();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            selectedItem.setNotes(rtbNotes.Text, items.itemData);
            refreshDisplays();
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            selectedItem.deleteItem(items.itemData);
            selectedItem = null;
            refreshTree();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            popupAddItem addItemForm = new popupAddItem(items.itemData);
            addItemForm.Show();
            refreshTree();
            refreshDisplays();
            refreshTree();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            refreshTree();
            refreshDisplays();
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(items.itemData.Tables["items"].Rows.Count > 0)
            {
                selectedIndex = e.Node.Index;
            }
        }

        private void cbMoveToNext_CheckedChanged(object sender, EventArgs e)
        {
            moveToNext = cbMoveToNext.Checked;
        }

        private void pbFetchReferences_Click(object sender, EventArgs e)
        {
            selectedItem.retrieveReferences("Google Patents", items.itemData);
            refreshTree();
            history.getListViewData(historyListView, items.itemData);
        }

        private void cleanUpIrrelevantItemDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.removeIrrelevantData();
        }

        private void pbGetUSPTOPDF_Click(object sender, EventArgs e)
        {
            selectedItem.retrievePDF("USPTO", items.itemData);
            refreshDisplays();
        }

        private void pbGetPDFGoogle_Click(object sender, EventArgs e)
        {
            selectedItem.retrievePDF("Google Patents", items.itemData);
            refreshDisplays();
        }

        private void mainTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabs.SelectedTab.Name == "tabEspacenet")
            {
                string countryCode = selectedItem.getIdentifier().Substring(0, 2);
                string patIdent = selectedItem.getIdentifier().Substring(2);
                string espacenetUrl = "https://worldwide.espacenet.com/publicationDetails/originalDocument?CC="+countryCode+"&NR="+patIdent+"&KC=A&FT=D&ND=3&DB=&locale=en_EP#";

                wbEspacenet.Navigate(espacenetUrl);
            }
        }
    }
}
