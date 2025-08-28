using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.ServiceLines;
using Microsoft.EntityFrameworkCore;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.ServiceLines
{
    internal class MSSQLServiceLineEntityDefinition
    {
        internal static ModelBuilder BuildEntityDefinition(ModelBuilder builder)
        {
            builder.Entity<ServiceLineEntity>().ToTable("ServiceLine");

            builder.Entity<ServiceLineEntity>()
                .HasKey(p => p.ID);

            builder.Entity<ServiceLineEntity>()
                .Property(p => p.ID)
                .UseIdentityColumn();

            builder.Entity<ServiceLineEntity>()
                .Property(p => p.ID)
                .HasColumnType("int");

            builder.Entity<ServiceLineEntity>()
                .Property(p => p.ServiceLineName)
                .HasColumnType("varchar(25)");

            return builder;
        }
    }
}
