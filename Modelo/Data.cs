using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Empregado> Empregados { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<LinhaDeFatura> LinhasDeFatura { get; set; }
    }
}
