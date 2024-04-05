using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AV.Models;

namespace AV.Data
{
    public class AVContext : DbContext
    {
        public AVContext (DbContextOptions<AVContext> options)
            : base(options)
        {
        }

        public DbSet<Auftrag> Auftraege { get; set; } = default!;
        public DbSet<Adresse> Adressen { get; set; } = default!; 

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
        //modelBuilder.Entity<Adresse>()
          //  .HasMany(a => a.Auftrag)
           // .WithOne(a => a.Adresse)
           // .HasForeignKey(a => a.AdresseId);
       //y }   
    }
}
