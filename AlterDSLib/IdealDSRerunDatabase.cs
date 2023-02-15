using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AlterDSLib
{
    public abstract class IdealDSRerunDatabase : SQLQueries
    {
        public static string _connectionString 
        { 
            get 
            { 
                return "data source=AW-BARTOW-SQL3;\r\n   initial catalog=inSight;persist security info=True; \r\n   Integrated Security=SSPI;";
            }
        }
        
        public static bool HasConnection(string connectionString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static IdealDSRerunModel[] RetrieveAllItemsDB(string connectionString)
        {
            List<IdealDSRerunModel> models = new List<IdealDSRerunModel>();
            if(HasConnection(connectionString))
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQLQueries.GetAllItems(), conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            models.Add(new IdealDSRerunModel((int)reader[0], (string)reader[1], (DateTime)reader[2]));
                        }
                    }
                }
                
            }

            return models.ToArray();
        }

        public static IdealDSRerunModel[] RetrieveAllItemsByProcessedDateDB(string connectionString, string date)
        {
            List<IdealDSRerunModel> models = new List<IdealDSRerunModel>();
            if (HasConnection(connectionString))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQLQueries.GetAllItemsByProcessedDate(date), conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            models.Add(new IdealDSRerunModel((int)reader[0], (string)reader[1], (DateTime)reader[2]));
                        }
                    }
                }

            }

            return models.ToArray();
        }

        public static IdealDSRerunModel GetItemByIdDB(string connectionString, int id)
        {
            IdealDSRerunModel model = null;
            if (HasConnection(connectionString))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQLQueries.GetItemById(id), conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new IdealDSRerunModel((int)reader[0], (string)reader[1], (DateTime)reader[2]);
                        }
                    }
                }

            }

            return model;
        }

        public static IdealDSRerunModel GetItemByNameDB(string connectionString, string name)
        {
            IdealDSRerunModel model = null;
            if (HasConnection(connectionString))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(SQLQueries.GetItemByName(name), conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new IdealDSRerunModel((int)reader[0], (string)reader[1], (DateTime)reader[2]);
                        }
                    }
                }

            }

            return model;
        }

        public static bool InsertItemDB(string connectionString, int id, string name, string processedDate)
        {
            if(HasConnection(connectionString))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand(SQLQueries.InsertItem(id, name, processedDate), conn);
                        command.ExecuteNonQuery();
                        return true;
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }

        public static bool DeleteItemByIdDB(string connectionString, int id)
        {
            if (HasConnection(connectionString))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand(SQLQueries.RemoveItemById(id), conn);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }

        public static bool DeleteItemsByIdsDB(string connectionString, int[] id)
        {
            if (HasConnection(connectionString))
            {
                try
                {
                    foreach(int item in id)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlCommand command = new SqlCommand(SQLQueries.RemoveItemById(item), conn);
                            command.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }

        public static bool UpdateItemByIdDB(string connectionString, int id, string name, string processedDate)
        {
            if (HasConnection(connectionString))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand(SQLQueries.UpdateItem(id,name,processedDate), conn);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return false;
        }
    }
}
