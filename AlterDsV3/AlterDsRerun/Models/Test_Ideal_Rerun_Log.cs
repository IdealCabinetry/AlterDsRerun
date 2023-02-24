using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlterDsRerun.Models
{
    public class Test_Ideal_Rerun_Log
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string? Item { get; set; }
        [BindProperty]
        public DateTime? ProcessedDate { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
    }
}
