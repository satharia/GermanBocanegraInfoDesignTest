using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.MeasurementSegments;
using Microsoft.EntityFrameworkCore;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output.ORMDefinitions.EntityFramework.EntityDefinitions.MSSQLSERVER.MeasurementSegments
{
    internal class MSSQLTimeSegmentEntityDefinition
    {
        internal static ModelBuilder BuildEntityDefinition(ModelBuilder builder)
        {
            builder.Entity<TimeSegmentEntity>().ToTable("TimeSegment");

            builder.Entity<TimeSegmentEntity>()
                .HasKey(p => p.ID);

            builder.Entity<TimeSegmentEntity>()
                .Property(p => p.ID)
                .UseIdentityColumn();

            builder.Entity<TimeSegmentEntity>()
                .Property(p => p.ID)
                .HasColumnType("int");

            builder.Entity<TimeSegmentEntity>()
                .Property(p => p.TimeSegmentDate)
                .HasColumnType("date");

            return builder;
        }
    }
}
