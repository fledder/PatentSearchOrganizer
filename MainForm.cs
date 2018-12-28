using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatentSearchOrganizer
{
    public partial class MainForm : Form
    {
        private ItemsHandler items;
        private Item selectedItem;
        private string filePath;
        private bool showNotRelevant;
        private int _selectedIndex;
        private int selectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                if(tree.Nodes.Count > 0)
                {
                    tree.SelectedNode = tree.Nodes[_selectedIndex];
                    items.selectItemByIdentifier(tree.SelectedNode.Text);
                    selectedItem = items.getSelectedItem();
                    refreshDisplays();
                }
            }
        }
        private bool moveToNext;

        public MainForm()
        {
            InitializeComponent();
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
            refreshDisplays();
        }

        public void refreshTree()
        {
            items.updateTreeData(tree, showNotRelevant);
        }

        public void refreshDisplays()
        {
            if(selectedItem != null)
            {
                itemTitle.Text = selectedItem.getTitle();
                itemAbstract.Text = selectedItem.getAbstract();
                claimsWebBrowser.Navigate("about:blank");
                claimsWebBrowser.Document.OpenNew(true);
                claimsWebBrowser.Document.Write(selectedItem.getClaims());
                Stream figureImageStream = new MemoryStream(selectedItem.getSelectedImage());
                figurePictureBox.Image = null;
                if (figureImageStream.Length > 0)
                {
                    Image figureImage = Image.FromStream(figureImageStream);
                    figurePictureBox.Image = figureImage;
                }
                specificationBrowser.Navigate("about:blank");
                specificationBrowser.Document.OpenNew(true);
                specificationBrowser.Document.Write(selectedItem.getDescription());
                rtbNotes.Text = selectedItem.getNotes();
            }
        }

        private void firstImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectImage(0);
            refreshDisplays();
        }

        private void previousImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectPreviousImage();
            refreshDisplays();
        }

        private void nextImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectNextImage();
            refreshDisplays();
        }

        private void lastImageButton_Click(object sender, EventArgs e)
        {
            selectedItem.selectLastImage();
            refreshDisplays();
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
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            popupAddItem addItemForm = new popupAddItem(items.itemData);
            addItemForm.Show();
            refreshTree();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            refreshTree();
            refreshDisplays();
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectedIndex = e.Node.Index;
        }

        private void cbMoveToNext_CheckedChanged(object sender, EventArgs e)
        {
            moveToNext = cbMoveToNext.Checked;
        }

        private void pbFetchReferences_Click(object sender, EventArgs e)
        {
            selectedItem.retrieveReferences("Google Patents", items.itemData);
            refreshTree();
        }

        private void cleanUpIrrelevantItemDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.removeIrrelevantData();
        }
    }
}
