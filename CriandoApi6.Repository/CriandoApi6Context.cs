using CriandoApi6.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriandoApi6.Repository
{
    public class CriandoApi6Context : DbContext
    {
        public CriandoApi6Context(DbContextOptions<CriandoApi6Context> options) : base(options) { }

        public DbSet<TabAlunos> TabAlunos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabAlunos>().ToTable("TabAlunos");
        }
    }
}
