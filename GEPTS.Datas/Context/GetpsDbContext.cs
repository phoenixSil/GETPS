using GETPS.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPTS.Datas.Context
{
    public class GetpsDbContext: DbContext
    {
        public GetpsDbContext(DbContextOptions<GetpsDbContext> options): base(options)
        {

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntite>())
            {
                entry.Entity.DateDerniereModification = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreation = DateTime.Now;
                }

            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GetpsDbContext).Assembly);
        }

        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Programmation> Programmations { get; set; }

    }
}
