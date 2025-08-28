using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.ServiceLines;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.EnergyMetrics
{
    public class EnergyCostDTO : BaseDTO
    {
        public long ID { get; set; }
        public int ServiceLineID { get; set; }
        public int TimeSegmentID { get; set; }
        public decimal Residential { get; set; }
        public decimal Commercial { get; set; }
        public decimal Industrial { get; set; }

        public virtual ServiceLineDTO? ServiceLine { get; set; }
        public virtual TimeSegmentDTO? TimeSegment { get; set; }
    }
}
