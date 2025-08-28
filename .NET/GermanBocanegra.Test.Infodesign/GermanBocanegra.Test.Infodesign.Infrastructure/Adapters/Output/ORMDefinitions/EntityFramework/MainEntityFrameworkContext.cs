using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.ServiceLines;
using GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.ServiceLines;
using Microsoft.EntityFrameworkCore;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework
{
    public class MainEntityFrameworkContext : DbContext
    {
        public MainEntityFrameworkContext(DbContextOptions<MainEntityFrameworkContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<ServiceLineEntity> ServiceLines { get; set; }
        public DbSet<TimeSegmentEntity> TimeSegments { get; set; }

        public DbSet<EnergyConsumptionEntity> EnergyConsumptions { get; set; }
        public DbSet<EnergyCostEntity> EnergyCosts { get; set; }
        public DbSet<EnergyLossEntity> EnergyLosses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            LoadPostgreSQLEntityDefinitions(modelBuilder);
        }

        private void LoadPostgreSQLEntityDefinitions(ModelBuilder modelBuilder)
        {
            MSSQLServiceLineEntityDefinition.BuildEntityDefinition(modelBuilder);
            MSSQLTimeSegmentEntityDefinition.BuildEntityDefinition(modelBuilder);

            MSSQLEnergyConsumptionEntityDefinition.BuildEntityDefinition(modelBuilder);
            MSSQLEnergyCostEntityDefinition.BuildEntityDefinition(modelBuilder);
            MSSQLEnergyLossEntityDefinition.BuildEntityDefinition(modelBuilder);
        }
    }
}
