using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlterDSLib;
namespace AlterDsRerun.Pages
{
    public class CreateModel : PageModel
    {
        public IdealDSRerunModel idealModel = new IdealDSRerunModel();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            idealModel = new IdealDSRerunModel();
            idealModel.id = int.Parse(Request.Form["id"]);
            idealModel.Item = Request.Form["item"];
            //idealModel.ProcessedDate = DateTime.Parse(Request.Form["ProcessedDate"]);

            if (idealModel.id == 0 || idealModel.Item == "" || idealModel.Item == " ")
            {
                errorMessage = "Missing required fields";
                return;
            }

            try
            {
                bool hasSuccessfullyAdded = IdealDSRerunService.InsertItemDB(IdealDSRerunService._connectionString,
               idealModel.id,
               idealModel.Item,
               Request.Form["ProcessedDate"]);
            } catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            successMessage = "Item has been successfully added!";
            Response.Redirect("/Index");
           
        }
    }
}
