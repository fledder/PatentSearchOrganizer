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

        public MainForm()
        {
            InitializeComponent();
            items = new ItemsHandler();
            items.addItem("US Patent", "6789012", "https://example.com/9876543", "High");
            items.selectItem(0);
            selectedItem = items.getSelectedItem();
            selectedItem.retrieveData("Google Patents", this.items.itemData);
            selectedItem.retrieveReferences("Google Patents", this.items.itemData);
            selectedItem = items.getSelectedItem();
            refreshTree();
            refreshDisplays();
        }

        public void refreshTree()
        {
            items.updateTreeData(tree);
        }

        public void refreshDisplays()
        {
            itemTitle.Text = selectedItem.getTitle();
            itemAbstract.Text = selectedItem.getAbstract();
            claimsWebBrowser.Navigate("about:blank");
            claimsWebBrowser.Document.OpenNew(true);
            claimsWebBrowser.Document.Write(selectedItem.getClaims());
            Stream figureImageStream = new MemoryStream(selectedItem.getSelectedImage());
            figurePictureBox.Image = null;
            if(figureImageStream.Length > 0)
            {
                Image figureImage = Image.FromStream(figureImageStream);
                figurePictureBox.Image = figureImage;
            }
            specificationBrowser.Navigate("about:blank");
            specificationBrowser.Document.OpenNew(true);
            specificationBrowser.Document.Write(selectedItem.getDescription());
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
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedIdentifier = tree.SelectedNode.Text;
            items.selectItemByIdentifier(selectedIdentifier);
            selectedItem = items.getSelectedItem();
            refreshDisplays();
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
            if(input.Length == 7)
            {
                items.addItem("US Patent", input, "", null);
            }
            else if(input.Length == 11)
            {
                items.addItem("US Publication", input, "", null);
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
    }
}
