using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlterDsRerun.Data;
using AlterDsRerun.Models;

namespace AlterDsRerun.Pages.Test
{
    public class DetailsModel : PageModel
    {
        private readonly AlterDsRerun.Data.AlterDsRerunContext _context;

        public DetailsModel(AlterDsRerun.Data.AlterDsRerunContext context)
        {
            _context = context;
        }

      public Test_Ideal_Rerun_Log Test_Ideal_Rerun_Log { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Test_Ideal_Rerun_Log == null)
            {
                return NotFound();
            }

            var test_ideal_rerun_log = await _context.Test_Ideal_Rerun_Log.FirstOrDefaultAsync(m => m.Id == id);
            if (test_ideal_rerun_log == null)
            {
                return NotFound();
            }
            else 
            {
                Test_Ideal_Rerun_Log = test_ideal_rerun_log;
            }
            return Page();
        }
    }
}
