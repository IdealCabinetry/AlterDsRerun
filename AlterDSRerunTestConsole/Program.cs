using AlterDSLib;

public class Program
{
    public static void Main(String[] args)
    {
        string connectionString = "data source=AW-BARTOW-SQL3;\r\n   initial catalog=inSight;persist security info=True; \r\n   Integrated Security=SSPI;";
        //IdealDSRerunModel[] models = IdealDSRerunService.RetrieveAllItemsByProcessedDate(connectionString, "2022-12-02 04:36:01.693");

        //foreach (var model in models)
        //{
        //    Console.WriteLine(model.ToString());
        //}

        //IdealDSRerunModel model  = IdealDSRerunService.GetItemById(connectionString, 56767);
        //Console.WriteLine(model.ToString());

        //Console.WriteLine(IdealDSRerunService.InsertItemDB(connectionString,11113,"TESTITEM6-FL",DateTime.Now.ToString()));

        //Console.WriteLine(IdealDSRerunService.DeleteItemByIdDB(connectionString, 11111));

        //Console.WriteLine(IdealDSRerunService.UpdateItemById(connectionString,11111, "TESTITEM6789-FL", DateTime.Now.ToString()));

        //Console.WriteLine(IdealDSRerunService.DeleteItemsByIdsDB(connectionString, new int[] {11111,11112,11113}));
    }
}