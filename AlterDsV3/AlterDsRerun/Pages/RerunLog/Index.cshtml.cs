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
    public class IndexModel : PageModel
    {
        private readonly AlterDsRerun.Data.AlterDsRerunContext _context;

        public IndexModel(AlterDsRerun.Data.AlterDsRerunContext context)
        {
            _context = context;
        }

        public IList<Ideal_DS_Rerun_Log> Ideal_DS_Rerun_Log { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    //if (_context.Ideal_DS_Rerun_Log != null)
        //    //{
        //    //    Ideal_DS_Rerun_Log = await _context.Ideal_DS_Rerun_Log.ToListAsync();
        //    //}
        //}

        public async Task OnGetAsync(string SearchString)
        {
            var items = from i in _context.Ideal_DS_Rerun_Log
                        select i;

            if(!String.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.Item.Contains(SearchString) || s.Id.ToString().Contains(SearchString) || s.ProcessedDate.ToString().Contains(SearchString));
            }

            Ideal_DS_Rerun_Log = await items.ToListAsync();
        }

        Ideal_DS_Rerun_Log Temp { get; set; }
        public async Task<IActionResult> OnPostAsync(int[]? id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == null || _context.Ideal_DS_Rerun_Log == null)
                {
                    return NotFound();
                }
                var test_ideal_rerun_log = await _context.Ideal_DS_Rerun_Log.FindAsync(id[i]);

                if (test_ideal_rerun_log != null)
                {
                    Temp = test_ideal_rerun_log;
                    _context.Ideal_DS_Rerun_Log.Remove(Temp);
                    await _context.SaveChangesAsync();
                }
            }


            return RedirectToPage("./Index");
        }
    }
}
