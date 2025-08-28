using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.EnergyMetrics;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.MeasurementSegments
{
    public class TimeSegmentDTO : BaseDTO
    {
        public int ID { get; set; }
        public DateOnly TimeSegmentDate { get; set; }

        public virtual ICollection<EnergyConsumptionDTO>? EnergyConsumptions { get; set; }
        public virtual ICollection<EnergyCostDTO>? EnergyCosts { get; set; }
        public virtual ICollection<EnergyLossDTO>? EnergyLosses { get; set; }
    }
}
