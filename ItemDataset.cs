using System.Data;
using System.Linq;

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

        public void addItemRelation(int fromID, int toID, string type)
        {
            DataRow newRow = this.Tables["references"].NewRow();
            newRow["fromID"] = fromID;
            newRow["toID"] = toID;
            newRow["type"] = type;
            this.Tables["references"].Rows.Add(newRow);
            this.Tables["references"].AcceptChanges();
        }

        public void addItemRelationIdentifiers(string fromIdentifier, string toIdentifier, string type)
        {
            int fromID = (from item in this.items where item.identifier == fromIdentifier select item.id).First();
            int toID = (from item in this.items where item.identifier == toIdentifier select item.id).First();
            addItemRelation(fromID, toID, type);
        }
    }
}
namespace PatentSearchOrganizer
{


    public partial class ItemDataset
    {
    }
}
