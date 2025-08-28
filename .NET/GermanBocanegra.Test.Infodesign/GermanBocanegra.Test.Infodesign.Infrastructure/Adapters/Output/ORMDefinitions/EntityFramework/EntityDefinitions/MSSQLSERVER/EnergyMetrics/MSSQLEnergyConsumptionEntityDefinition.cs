using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;
using Microsoft.EntityFrameworkCore;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.EnergyMetrics
{
    internal class MSSQLEnergyConsumptionEntityDefinition
    {
        internal static ModelBuilder BuildEntityDefinition(ModelBuilder builder)
        {
            builder.Entity<EnergyConsumptionEntity>().ToTable("EnergyConsumption");

            builder.Entity<EnergyConsumptionEntity>()
                .HasKey(p => p.ID);

            builder.Entity<EnergyConsumptionEntity>()
                .Property(p => p.ID)
                .UseIdentityColumn();

            builder.Entity<EnergyConsumptionEntity>()
                .Property(p => p.ID)
                .HasColumnType("bigint");

            builder.Entity<EnergyConsumptionEntity>()
                .Property(p => p.ServiceLineID)
                .HasColumnType("int");

            builder.Entity<EnergyConsumptionEntity>()
                .Property(p => p.TimeSegmentID)
                .HasColumnType("int");

            builder.Entity<EnergyConsumptionEntity>()
                .Property(p => p.Residential)
                .HasColumnType("int");

            builder.Entity<EnergyConsumptionEntity>()
                .Property(p => p.Commercial)
                .HasColumnType("int");

            builder.Entity<EnergyConsumptionEntity>()
                .Property(p => p.Industrial)
                .HasColumnType("int");

            builder.Entity<EnergyConsumptionEntity>()
                .HasOne(entity => entity.ServiceLine)
                .WithMany(subEntity => subEntity.EnergyConsumptions)
                .HasForeignKey(entity => entity.ServiceLineID);

            builder.Entity<EnergyConsumptionEntity>()
                .HasOne(entity => entity.TimeSegment)
                .WithMany(subEntity => subEntity.EnergyConsumptions)
                .HasForeignKey(entity => entity.TimeSegmentID);

            builder.Entity<EnergyConsumptionEntity>()
                .HasIndex(nameof(EnergyConsumptionEntity.ServiceLineID), nameof(EnergyConsumptionEntity.TimeSegmentID))
                .IsUnique();

            return builder;
        }
    }
}
