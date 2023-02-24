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
    public class IndexModel : PageModel
    {
        private readonly AlterDsRerun.Data.AlterDsRerunContext _context;

        public IndexModel(AlterDsRerun.Data.AlterDsRerunContext context)
        {
            _context = context;
        }

        public IList<Test_Ideal_Rerun_Log> Test_Ideal_Rerun_Log { get; set; }

        public async Task OnGetAsync()
        {
            Test_Ideal_Rerun_Log = await _context.Test_Ideal_Rerun_Log.ToListAsync();
            if (_context.Test_Ideal_Rerun_Log != null)
            {
                Test_Ideal_Rerun_Log = await _context.Test_Ideal_Rerun_Log.ToListAsync();
            }
        }

        Test_Ideal_Rerun_Log Temp { get; set; }
        public async Task<IActionResult> OnPostAsync(int[]? id)
        {
            for(int i = 0; i < id.Length; i++)
            {
                if (id[i] == null || _context.Test_Ideal_Rerun_Log == null)
                {
                    return NotFound();
                }
                var test_ideal_rerun_log = await _context.Test_Ideal_Rerun_Log.FindAsync(id[i]);

                if (test_ideal_rerun_log != null)
                {
                    Temp = test_ideal_rerun_log;
                    _context.Test_Ideal_Rerun_Log.Remove(Temp);
                    await _context.SaveChangesAsync();
                }
            }
           

            return RedirectToPage("./Index");
        }

    }
}
