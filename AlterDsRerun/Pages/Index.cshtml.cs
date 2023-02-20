using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlterDSLib;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlterDsRerun.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<IdealDSRerunModel> _idealDSRerunModels { get; set; } = IdealDSRerunService.RetrieveAllItems(IdealDSRerunService._connectionString).ToList();



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnPost(List<IdealDSRerunModel> _idealDSRerunModels)
        {
            foreach(IdealDSRerunModel model in _idealDSRerunModels)
            {
                if(model.IsChecked)
                {
                    IdealDSRerunService.RemoveItemById(IdealDSRerunService._connectionString, model.id);
                }
               
                //System.Diagnostics.Debug.WriteLine(model.id);
            }

            Response.Redirect("/Index");
        }

        public void OnGet()
        {
            _idealDSRerunModels = IdealDSRerunService.RetrieveAllItems(IdealDSRerunService._connectionString).ToList();
            string searchData = Request.Query["search"];
            if (searchData == null)
            {
                try
                {
                    _idealDSRerunModels = IdealDSRerunService.RetrieveAllItems(IdealDSRerunService._connectionString).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;
            }

            try
            {
                _idealDSRerunModels = IdealDSRerunService.RetrieveAllItems(IdealDSRerunService._connectionString).ToList();
                List<IdealDSRerunModel> models = new List<IdealDSRerunModel>();
                foreach (var model in _idealDSRerunModels)
                {
                    if (model.id.ToString().Contains(searchData) ||
                        model.Item.Contains(searchData) ||
                        model.ProcessedDate.ToString().Contains(searchData))
                    {
                        models.Add(model);
                    }

                }
                _idealDSRerunModels.Clear();
                _idealDSRerunModels = models;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;

        }

        
    }
}