using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_framework_one.Models;

namespace project_framework_one.Data
{
    public class project_framework_oneContext : DbContext
    {
        public project_framework_oneContext (DbContextOptions<project_framework_oneContext> options)
            : base(options)
        {
        }

        public DbSet<project_framework_one.Models.Fornecedor> Fornecedor { get; set; } = default!;

        public DbSet<project_framework_one.Models.Cliente>? Cliente { get; set; }

        public DbSet<project_framework_one.Models.Entregador>? Entregador { get; set; }

        public DbSet<project_framework_one.Models.Estoque>? Estoque { get; set; }

        public DbSet<project_framework_one.Models.Ingrediente>? Ingrediente { get; set; }

        public DbSet<project_framework_one.Models.Nota>? Nota { get; set; }

        public DbSet<project_framework_one.Models.Pagamento>? Pagamento { get; set; }

        public DbSet<project_framework_one.Models.Pedido>? Pedido { get; set; }

        public DbSet<project_framework_one.Models.Prato>? Prato { get; set; }
    }
}
