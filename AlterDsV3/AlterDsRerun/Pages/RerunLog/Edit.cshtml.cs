using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlterDsRerun.Data;
using AlterDsRerun.Models;

namespace AlterDsRerun.Pages.RerunLog
{
    public class EditModel : PageModel
    {
        private readonly AlterDsRerun.Data.AlterDsRerunContext _context;

        public EditModel(AlterDsRerun.Data.AlterDsRerunContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ideal_DS_Rerun_Log Ideal_DS_Rerun_Log { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ideal_DS_Rerun_Log == null)
            {
                return NotFound();
            }

            var ideal_ds_rerun_log =  await _context.Ideal_DS_Rerun_Log.FirstOrDefaultAsync(m => m.Id == id);
            if (ideal_ds_rerun_log == null)
            {
                return NotFound();
            }
            Ideal_DS_Rerun_Log = ideal_ds_rerun_log;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ideal_DS_Rerun_Log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ideal_DS_Rerun_LogExists(Ideal_DS_Rerun_Log.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Ideal_DS_Rerun_LogExists(int id)
        {
          return _context.Ideal_DS_Rerun_Log.Any(e => e.Id == id);
        }
    }
}
