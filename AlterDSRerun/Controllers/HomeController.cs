using AlterDSRerun.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AlterDSLib;

namespace AlterDSRerun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string connectionString = "data source=AW-BARTOW-SQL3;\r\n   initial catalog=inSight;persist security info=True; \r\n   Integrated Security=SSPI;";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    //ViewBag.GetAll = IdealDSRerunService.RetrieveAllItemsDB(connectionString);
        //    return View();
        //}

        public IActionResult Index(string button, int id, string name, DateTime date)
        {
            List<IdealDSRerunModel> models = new List<IdealDSRerunModel>();
            ViewBag.IsListBeingUsed = true;
            switch(button)
            {
                case "GetAllItems":
                    ViewBag.Results = IdealDSRerunService.RetrieveAllItemsDB(connectionString);
                    break;
                case "GetItemById":
                    try
                    {
                        models.Add(IdealDSRerunService.GetItemById(connectionString, id));
                        ViewBag.Results = models.ToArray();
                    } catch(Exception ex)
                    {
                        ViewBag.Results = new IdealDSRerunModel[] { new IdealDSRerunModel(0, ex.Message, DateTime.Now) };
                    }
                    break;
                case "GetItemByName":
                    models.Add(IdealDSRerunService.GetItemByName(connectionString, name));
                    ViewBag.Results = models.ToArray();
                    break;
                case "GetItemsByPD":
                    ViewBag.Results = IdealDSRerunService.RetrieveAllItemsByProcessedDate(connectionString, ConvertedDate(date));
                   // models.Add(new IdealDSRerunModel(0,ConvertedDate(date), date));
                   // ViewBag.Results = models.ToArray();
                    break;
                case "InsertItem":
                    ViewBag.IsListBeingUsed = false;
                    ViewBag.Confirmation = IdealDSRerunService.InsertItem(connectionString, id,name,date.ToString()) ? "Item Added Successfully!" : "Could Not Add Item";
                    break;
                case "RemoveItem":
                    ViewBag.IsListBeingUsed = false;
                    ViewBag.Confirmation = IdealDSRerunService.RemoveItemById(connectionString, id) ? "Item Removed Successfully!" : "Could Not Remove Item";
                    break;
                case "UpdateItem":
                    ViewBag.IsListBeingUsed = false;
                    ViewBag.Confirmation = IdealDSRerunService.UpdateItemById(connectionString, id, name, date.ToString()) ? "Item Updated Successfully!" : "Could Not Update Item";
                    try
                    {
                        models.Add(IdealDSRerunService.GetItemById(connectionString, id));
                        ViewBag.Results = models.ToArray();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Results = new IdealDSRerunModel[] { new IdealDSRerunModel(0, ex.Message, DateTime.Now) };
                    }
                    break;
                default:
                    ViewBag.Results = new IdealDSRerunModel[] {new IdealDSRerunModel(0,"None",DateTime.Now)};
                    break;
            }
            return View();
        }

        private string ConvertedDate(DateTime date)
        {
            //2/23/2023 12:00:00 AM
            string[] splitBySpace = date.ToString().Split(' ');
            string[] splitBySlashes = splitBySpace[0].Split('/');
            return splitBySlashes[2] + '-' + splitBySlashes[0] + '-' + splitBySlashes[1];
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult Test(int id)
        //{
        //    string connectionString = "data source=AW-BARTOW-SQL3;\r\n   initial catalog=inSight;persist security info=True; \r\n   Integrated Security=SSPI;";
        //    IdealDSRerunModel model = IdealDSRerunService.GetItemById(connectionString, 49459);
        //    ViewBag.Id = model.ToString();
        //    return View();
        //}
    }
}