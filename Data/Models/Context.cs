using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NurusMES.Data.Models
{
    public class Context : DbContext
    {
        // Database işlemlerinin yapılması
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-S4O1A1P; database=DbNurusMES; integrated security=true; TrustServerCertificate=True");
        }

        public DbSet<Personel> Personels { get; set; }

        public DbSet<Makine> Makines { get; set; }

        public DbSet<Birim> Birims { get; set; }

        public DbSet<Duruslar> Duruslar{ get; set;}

        public DbSet<Arduino> Arduino { get; set; }




    }
}