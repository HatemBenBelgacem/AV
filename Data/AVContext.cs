using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AV.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace AV.Data
{
    public class AVContext : DbContext
    {
        public AVContext(DbContextOptions<AVContext> options)
            : base(options)
        {
        }

        public DbSet<Auftrag> Auftraege { get; set; } = default!;
        public DbSet<Adresse> Adressen { get; set; } = default!;
        public DbSet<Produkt> Produkte { get; set; } = default!;
        public DbSet<AV.Models.Position> Positionen { get; set; } = default!;
        public DbSet<Aufgabe> Aufgabe { get; set; } = default!;

   

    }
}
