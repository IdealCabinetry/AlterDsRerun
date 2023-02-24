using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlterDsRerun.Data;
using AlterDsRerun.Models;

namespace AlterDsRerun.Pages.RerunLog
{
    public class CreateModel : PageModel
    {
        private readonly AlterDsRerun.Data.AlterDsRerunContext _context;

        public CreateModel(AlterDsRerun.Data.AlterDsRerunContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ideal_DS_Rerun_Log Ideal_DS_Rerun_Log { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ideal_DS_Rerun_Log.Add(Ideal_DS_Rerun_Log);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
