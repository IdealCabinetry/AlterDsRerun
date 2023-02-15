using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDSLib
{
    public class IdealDSRerunService : IdealDSRerunDatabase
    {
        public string GetConnectionString()
        {
            return IdealDSRerunDatabase._connectionString;
        }
        public static IdealDSRerunModel[] RetrieveAllItems(string connectionString)
        {
            return IdealDSRerunDatabase.RetrieveAllItemsDB(connectionString);
        }

        public static IdealDSRerunModel[] RetrieveAllItemsByProcessedDate(string connectionString, string date)
        {
            return IdealDSRerunDatabase.RetrieveAllItemsByProcessedDateDB(connectionString, date);
        }

        public static IdealDSRerunModel GetItemById(string connectionString, int id)
        {
            return IdealDSRerunDatabase.GetItemByIdDB(connectionString, id);
        }

        public static IdealDSRerunModel GetItemByName(string connectionString, string name)
        {
            return IdealDSRerunDatabase.GetItemByNameDB(connectionString, name);
        }

        public static bool InsertItem(string connectionString, int id, string name, string processedDate)
        {
            return IdealDSRerunDatabase.InsertItemDB(connectionString, id, name, processedDate);
        }

        public static bool RemoveItemById(string connectionString, int id)
        {
            return IdealDSRerunDatabase.DeleteItemByIdDB(connectionString, id);
        }

        public static bool RemoveItemsByIds(string connectionString, int[] id)
        {
            return IdealDSRerunDatabase.DeleteItemsByIdsDB(connectionString, id);
        }

        public static bool UpdateItemById(string connectionString, int id, string name, string dateProcessed)
        {
            return IdealDSRerunDatabase.UpdateItemByIdDB(connectionString, id, name, dateProcessed);
        }
    }
}
