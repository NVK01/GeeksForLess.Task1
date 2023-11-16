using GeeksForLess.Task1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GeeksForLess.Task1.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Catalog> Cataloges { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Catalog>()
                .HasOne(catalog => catalog.Parent)
                .WithMany(catalog => catalog.Children)
                .HasForeignKey(catalog => catalog.Id)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
