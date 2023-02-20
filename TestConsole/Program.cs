using AlterDSLib;
public class Program
{
    public static void Main(String[] args)
    {
        //Console.WriteLine(IdealDSRerunService.RemoveItemById(IdealDSRerunService._connectionString, 555)); 

        for(int i = 0; i < 20; i++)
        {
            IdealDSRerunService.InsertItem(IdealDSRerunService._connectionString, i, "Tester" + i, DateTime.Now.ToString());
        }
    }
}