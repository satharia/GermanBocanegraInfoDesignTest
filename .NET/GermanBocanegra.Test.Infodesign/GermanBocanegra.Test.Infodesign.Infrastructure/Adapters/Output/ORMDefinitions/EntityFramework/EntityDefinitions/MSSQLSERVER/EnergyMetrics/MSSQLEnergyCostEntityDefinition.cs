using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;
using Microsoft.EntityFrameworkCore;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.EnergyMetrics
{
    internal class MSSQLEnergyCostEntityDefinition
    {
        internal static ModelBuilder BuildEntityDefinition(ModelBuilder builder)
        {
            builder.Entity<EnergyCostEntity>().ToTable("EnergyCost");

            builder.Entity<EnergyCostEntity>()
                .HasKey(p => p.ID);

            builder.Entity<EnergyCostEntity>()
                .Property(p => p.ID)
                .UseIdentityColumn();

            builder.Entity<EnergyCostEntity>()
                .Property(p => p.ID)
                .HasColumnType("bigint");

            builder.Entity<EnergyCostEntity>()
                .Property(p => p.ServiceLineID)
                .HasColumnType("int");

            builder.Entity<EnergyCostEntity>()
                .Property(p => p.TimeSegmentID)
                .HasColumnType("int");

            builder.Entity<EnergyCostEntity>()
                .Property(p => p.Residential)
                .HasColumnType("decimal(18,10)");

            builder.Entity<EnergyCostEntity>()
                .Property(p => p.Commercial)
                .HasColumnType("decimal(18,10)");

            builder.Entity<EnergyCostEntity>()
                .Property(p => p.Industrial)
                .HasColumnType("decimal(18,10)");

            builder.Entity<EnergyCostEntity>()
                .HasOne(entity => entity.ServiceLine)
                .WithMany(subEntity => subEntity.EnergyCosts)
                .HasForeignKey(entity => entity.ServiceLineID);

            builder.Entity<EnergyCostEntity>()
                .HasOne(entity => entity.TimeSegment)
                .WithMany(subEntity => subEntity.EnergyCosts)
                .HasForeignKey(entity => entity.TimeSegmentID);

            builder.Entity<EnergyCostEntity>()
                .HasIndex(nameof(EnergyCostEntity.ServiceLineID), nameof(EnergyCostEntity.TimeSegmentID))
                .IsUnique();

            return builder;
        }
    }
}
