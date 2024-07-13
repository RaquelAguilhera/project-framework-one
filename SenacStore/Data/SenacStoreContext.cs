using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SenacStore.Models;

namespace SenacStore.Data
{
    public class SenacStoreContext : DbContext
    {
        public SenacStoreContext (DbContextOptions<SenacStoreContext> options)
            : base(options)
        {
        }

        public DbSet<SenacStore.Models.Product> Product { get; set; } = default!;
        public DbSet<SenacStore.Models.Seller> Seller { get; set; } = default!;
        public DbSet<SenacStore.Models.Department> Department { get; set; } = default!;
        public DbSet<SenacStore.Models.SalesRecord> SalesRecord { get; set; } = default!;
    }
}
