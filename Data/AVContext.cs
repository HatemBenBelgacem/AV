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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AV.Models.Position>()
                .HasKey(ap => new {ap.AuftragId, ap.ProduktId});

            modelBuilder.Entity<AV.Models.Position>()
                .HasOne(ap => ap.Auftrag)
                .WithMany(a => a.Position)
                .HasForeignKey(ap => ap.AuftragId);

             modelBuilder.Entity<AV.Models.Position>()
                .HasOne(ap => ap.Produkt)
                .WithMany(a => a.Position)
                .HasForeignKey(ap => ap.ProduktId);
        }

    }
}
