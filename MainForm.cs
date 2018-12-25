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
            items.addItem("US Patent", "9876543", "https://example.com/9876543", "High");
            items.selectItem(0);
            selectedItem = items.getSelectedItem();
            selectedItem.retrieveData("Google Patents", this.items.itemData);
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
            claimsWebBrowser.Document.Write(selectedItem.getClaims());
            Stream figureImageStream = new MemoryStream(selectedItem.getSelectedImage());
            Image figureImage = Image.FromStream(figureImageStream);
            figurePictureBox.Image = figureImage;
            specificationBrowser.Navigate("about:blank");
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
    }
}
