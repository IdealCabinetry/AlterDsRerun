using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDSLib
{
    public abstract class SQLQueries
    {
        //protected static string GetAllItems()
        //{
        //    return "SELECT * FROM [dbo].[Test_Ideal_Rerun_Log]";
        //}
        protected static string GetAllItems()
        {
            return "SELECT * FROM [dbo].[Ideal_DS_Rerun_Log]";
        }

        //protected static string GetAllItemsByProcessedDate(string processedDate)
        //{
        //    //return $"SELECT * FROM dbo.Ideal_DS_Rerun_Log WHERE CONVERT(VARCHAR, ProcessedDate, 120) LIKE '%{processedDate}%'";
        //    return $"SELECT * FROM [dbo].[Test_Ideal_Rerun_Log] WHERE ProcessedDate >= '{processedDate}'";
        //}
        protected static string GetAllItemsByProcessedDate(string processedDate)
        {
            //return $"SELECT * FROM dbo.Ideal_DS_Rerun_Log WHERE CONVERT(VARCHAR, ProcessedDate, 120) LIKE '%{processedDate}%'";
            return $"SELECT * FROM [dbo].[Ideal_DS_Rerun_Log] WHERE ProcessedDate >= '{processedDate}'";
        }

        //protected static string GetItemById(int id)
        //{
        //    return $"SELECT * FROM [dbo].[Test_Ideal_Rerun_Log] WHERE id = {id}";
        //}
        protected static string GetItemById(int id)
        {
            return $"SELECT * FROM [dbo].[Ideal_DS_Rerun_Log] WHERE id = {id}";
        }

        //protected static string GetItemByName(string name)
        //{
        //    return $"SELECT * FROM [dbo].[Test_Ideal_Rerun_Log] WHERE item = '{name}'";
        //}
        protected static string GetItemByName(string name)
        {
            return $"SELECT * FROM [dbo].[Ideal_DS_Rerun_Log] WHERE item = '{name}'";
        }

        //protected static string InsertItem(int id, string name, string processedDate)
        //{
        //    return $@"
        //        BEGIN TRANSACTION
        //        SET IDENTITY_INSERT [dbo].[Test_Ideal_Rerun_Log] ON
        //        INSERT INTO [dbo].[Test_Ideal_Rerun_Log] (id,item,ProcessedDate)
        //        VALUES ({id}, '{name}', '{processedDate}')
        //        IF(@@ROWCOUNT = 1)
        //        COMMIT TRANSACTION
        //        ELSE
        //        ROLLBACK TRANSACTION
        //    ";
        //}
        protected static string InsertItem(int id, string name, string processedDate)
        {
            return $@"
                BEGIN TRANSACTION
                SET IDENTITY_INSERT [dbo].[Ideal_DS_Rerun_Log] ON
                INSERT INTO [dbo].[Ideal_DS_Rerun_Log] (id,item,ProcessedDate)
                VALUES ({id}, '{name}', '{processedDate}')
                IF(@@ROWCOUNT = 1)
                COMMIT TRANSACTION
                ELSE
                ROLLBACK TRANSACTION
            ";
        }
        //protected static string RemoveItemById(int id)
        //{
        //    return $@"
        //        BEGIN TRANSACTION
        //        DELETE FROM [dbo].[Test_Ideal_Rerun_Log] WHERE id = {id}
        //        IF(@@ROWCOUNT = 1)
        //        COMMIT TRANSACTION
        //        ELSE
        //        ROLLBACK TRANSACTION
        //    ";
        //}
        protected static string RemoveItemById(int id)
        {
            return $@"
                BEGIN TRANSACTION
                DELETE FROM [dbo].[Ideal_DS_Rerun_Log] WHERE id = {id}
                IF(@@ROWCOUNT = 1)
                COMMIT TRANSACTION
                ELSE
                ROLLBACK TRANSACTION
            ";
        }

        //protected static string UpdateItem(int id, string name, string dateProcessed)
        //{
        //    return $@"
        //        BEGIN TRANSACTION
        //        UPDATE [dbo].[Test_Ideal_Rerun_Log]
        //        SET item = '{name}', ProcessedDate = '{dateProcessed}'
        //        WHERE id = {id}
        //        IF(@@ROWCOUNT = 1)
        //        COMMIT TRANSACTION
        //        ELSE
        //        ROLLBACK TRANSACTION
        //    ";
        //}

        protected static string UpdateItem(int id, string name, string dateProcessed)
        {
            return $@"
                BEGIN TRANSACTION
                UPDATE [dbo].[Ideal_DS_Rerun_Log]
                SET item = '{name}', ProcessedDate = '{dateProcessed}'
                WHERE id = {id}
                IF(@@ROWCOUNT = 1)
                COMMIT TRANSACTION
                ELSE
                ROLLBACK TRANSACTION
            ";
        }
    }
}
