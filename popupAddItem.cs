using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatentSearchOrganizer
{
    public partial class popupAddItem : Form
    {
        private ItemDataset dataset;

        public popupAddItem(ItemDataset datasetInput)
        {
            InitializeComponent();
            dataset = datasetInput;
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataset.Tables["items"].NewRow();
            newRow["type"] = tbType.Text;
            newRow["identifier"] = tbIdentifier.Text;
            newRow["fetchLink"] = tbLink.Text;
            dataset.Tables["items"].Rows.Add(newRow);
            dataset.Tables["items"].AcceptChanges();

            int itemID = (from item in dataset.items where item.identifier == tbIdentifier.Text select item.id).First();

            dataset.addItemComponent(itemID, "Title", tbTitle.Text);
            dataset.addItemComponent(itemID, "Abstract", rtbAbstract.Text);
            dataset.addItemComponent(itemID, "Claims", rtbClaims.Text);
            dataset.addItemComponent(itemID, "Description", rtbDescription.Text);

            this.Close();
        }
    }
}
