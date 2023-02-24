using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlterDsRerun.Models;

namespace AlterDsRerun.Data
{
    public class AlterDsRerunContext : DbContext
    {
        public AlterDsRerunContext (DbContextOptions<AlterDsRerunContext> options)
            : base(options)
        {
        }

        public DbSet<AlterDsRerun.Models.Test_Ideal_Rerun_Log> Test_Ideal_Rerun_Log { get; set; } = default!;

        public DbSet<AlterDsRerun.Models.Ideal_DS_Rerun_Log> Ideal_DS_Rerun_Log { get; set; }
    }
}
