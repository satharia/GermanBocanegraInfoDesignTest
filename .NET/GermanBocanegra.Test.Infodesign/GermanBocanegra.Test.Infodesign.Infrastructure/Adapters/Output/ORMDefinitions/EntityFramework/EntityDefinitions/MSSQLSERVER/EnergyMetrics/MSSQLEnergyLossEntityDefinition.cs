using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;
using Microsoft.EntityFrameworkCore;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.EnergyMetrics
{
    internal class MSSQLEnergyLossEntityDefinition
    {
        internal static ModelBuilder BuildEntityDefinition(ModelBuilder builder)
        {
            builder.Entity<EnergyLossEntity>().ToTable("EnergyLoss");

            builder.Entity<EnergyLossEntity>()
                .HasKey(p => p.ID);

            builder.Entity<EnergyLossEntity>()
                .Property(p => p.ID)
                .UseIdentityColumn();

            builder.Entity<EnergyLossEntity>()
                .Property(p => p.ID)
                .HasColumnType("bigint");

            builder.Entity<EnergyLossEntity>()
                .Property(p => p.ServiceLineID)
                .HasColumnType("int");

            builder.Entity<EnergyLossEntity>()
                .Property(p => p.TimeSegmentID)
                .HasColumnType("int");

            builder.Entity<EnergyLossEntity>()
                .Property(p => p.Residential)
                .HasColumnType("decimal(11,10)");

            builder.Entity<EnergyLossEntity>()
                .Property(p => p.Commercial)
                .HasColumnType("decimal(11,10)");

            builder.Entity<EnergyLossEntity>()
                .Property(p => p.Industrial)
                .HasColumnType("decimal(11,10)");

            builder.Entity<EnergyLossEntity>()
                .HasOne(entity => entity.ServiceLine)
                .WithMany(subEntity => subEntity.EnergyLosses)
                .HasForeignKey(entity => entity.ServiceLineID);

            builder.Entity<EnergyLossEntity>()
                .HasOne(entity => entity.TimeSegment)
                .WithMany(subEntity => subEntity.EnergyLosses)
                .HasForeignKey(entity => entity.TimeSegmentID);

            builder.Entity<EnergyLossEntity>()
                .HasIndex(nameof(EnergyLossEntity.ServiceLineID), nameof(EnergyLossEntity.TimeSegmentID))
                .IsUnique();

            return builder;
        }
    }
}
