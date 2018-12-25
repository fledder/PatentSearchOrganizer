using System.Data;

namespace PatentSearchOrganizer
{
}
namespace PatentSearchOrganizer
{


    partial class ItemDataset
    {
        partial class referencesDataTable
        {
        }

        partial class itemsDataTable
        {
        }

        public void addItemComponent(int itemID, string componentType, string componentStringValue)
        {
            DataRow newRow = this.Tables["itemComponents"].NewRow();
            newRow["itemID"] = itemID;
            newRow["componentType"] = componentType;
            newRow["componentStringValue"] = componentStringValue;
            this.Tables["itemComponents"].Rows.Add(newRow);
            this.Tables["itemComponents"].AcceptChanges();
        }
    }
}
namespace PatentSearchOrganizer
{


    public partial class ItemDataset
    {
    }
}
