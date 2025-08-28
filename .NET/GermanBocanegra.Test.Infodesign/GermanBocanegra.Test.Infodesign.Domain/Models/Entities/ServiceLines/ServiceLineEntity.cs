using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.Entities.ServiceLines
{
    public class ServiceLineEntity : BaseEntity
    {
        public int ID { get; set; }
        public string ServiceLineName { get; set; } = string.Empty;

        public virtual ICollection<EnergyConsumptionEntity>? EnergyConsumptions { get; set; }
        public virtual ICollection<EnergyCostEntity>? EnergyCosts { get; set; }
        public virtual ICollection<EnergyLossEntity>? EnergyLosses { get; set; }
    }
}
