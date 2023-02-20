using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlterDSLib;
using System.Text.Encodings.Web;

namespace AlterDsRerun.Pages
{

    public class EditModel : PageModel
    {
        public IdealDSRerunModel idealModel = new IdealDSRerunModel();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                idealModel = IdealDSRerunService.GetItemById(IdealDSRerunService._connectionString, int.Parse(id));
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            //idealModel.id = int.Parse(Request.Form["id"]);
            idealModel.id = int.Parse(Request.Query["id"]);
            idealModel.Item = Request.Form["item"];
            //idealModel.ProcessedDate = DateTime.Parse(Request.Form["ProcessedDate"]);

            if (idealModel.Item == "" || idealModel.Item == " " || Request.Form["ProcessedDate"] == "")
            {
                errorMessage = "Missing required fields";
                return;
            }

            try
            {
                bool hasSuccessfullyAdded = IdealDSRerunService.UpdateItemById(IdealDSRerunService._connectionString,
               idealModel.id,
               idealModel.Item,
               Request.Form["ProcessedDate"]);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            successMessage = "Item has been successfully updated!";
            Response.Redirect("/Index");
        }
    }
}
