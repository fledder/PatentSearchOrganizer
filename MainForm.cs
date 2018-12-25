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

        public MainForm()
        {
            InitializeComponent();
            items = new ItemsHandler();
            items.addItem("US Patent", "9876543", "https://example.com/9876543", "High");
            items.selectItem(0);
            Item selectedItem = items.getSelectedItem();
            selectedItem.retrieveData("Google Patents", this.items.itemData);
            refreshDisplays();
        }

        public void refreshDisplays()
        {
            Item selectedItem = items.getSelectedItem();
            itemTitle.Text = selectedItem.getTitle();
            itemAbstract.Text = selectedItem.getAbstract();
            itemClaims.Text = selectedItem.getClaims();
            Stream figureImageStream = new MemoryStream(selectedItem.getSelectedImage());
            Image figureImage = Image.FromStream(figureImageStream);
            figurePictureBox.Image = figureImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Item testItem = new Item(0);
            testItem.retrieveData("Google Patents", this.items.itemData);
            ;
        }
    }
}
