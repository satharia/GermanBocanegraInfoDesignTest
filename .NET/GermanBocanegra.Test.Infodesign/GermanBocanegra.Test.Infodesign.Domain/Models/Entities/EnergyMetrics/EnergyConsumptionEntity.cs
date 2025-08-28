using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.ServiceLines;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics
{
    public class EnergyConsumptionEntity : BaseEntity
    {
        public long ID { get; set; }
        public int ServiceLineID { get; set; }
        public int TimeSegmentID { get; set; }
        public int Residential { get; set; }
        public int Commercial { get; set; }
        public int Industrial { get; set; }

        public virtual ServiceLineEntity? ServiceLine { get; set; }
        public virtual TimeSegmentEntity? TimeSegment { get; set; }
    }
}
