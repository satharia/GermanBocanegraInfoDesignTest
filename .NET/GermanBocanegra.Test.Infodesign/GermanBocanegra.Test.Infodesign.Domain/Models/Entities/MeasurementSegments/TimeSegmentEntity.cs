using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.Entities.MeasurementSegments
{
    public class TimeSegmentEntity : BaseEntity
    {
        public int ID { get; set; }
        public DateOnly TimeSegmentDate { get; set; }

        public virtual ICollection<EnergyConsumptionEntity>? EnergyConsumptions { get; set; }
        public virtual ICollection<EnergyCostEntity>? EnergyCosts { get; set; }
        public virtual ICollection<EnergyLossEntity>? EnergyLosses { get; set; }
    }
}
