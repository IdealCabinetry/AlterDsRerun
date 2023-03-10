using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlterDsRerun.Data;
using AlterDsRerun.Models;

namespace AlterDsRerun.Pages.RerunLog
{
    public class DetailsModel : PageModel
    {
        private readonly AlterDsRerun.Data.AlterDsRerunContext _context;

        public DetailsModel(AlterDsRerun.Data.AlterDsRerunContext context)
        {
            _context = context;
        }

      public Ideal_DS_Rerun_Log Ideal_DS_Rerun_Log { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ideal_DS_Rerun_Log == null)
            {
                return NotFound();
            }

            var ideal_ds_rerun_log = await _context.Ideal_DS_Rerun_Log.FirstOrDefaultAsync(m => m.Id == id);
            if (ideal_ds_rerun_log == null)
            {
                return NotFound();
            }
            else 
            {
                Ideal_DS_Rerun_Log = ideal_ds_rerun_log;
            }
            return Page();
        }
    }
}
