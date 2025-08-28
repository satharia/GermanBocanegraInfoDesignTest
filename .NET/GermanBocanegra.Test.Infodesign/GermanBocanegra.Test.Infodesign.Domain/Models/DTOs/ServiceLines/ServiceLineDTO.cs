using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.EnergyMetrics;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.ServiceLines
{
    public class ServiceLineDTO : BaseDTO
    {
        public int ID { get; set; }
        public string ServiceLineName { get; set; } = string.Empty;

        public virtual ICollection<EnergyConsumptionDTO>? EnergyConsumptions { get; set; }
        public virtual ICollection<EnergyCostDTO>? EnergyCosts { get; set; }
        public virtual ICollection<EnergyLossDTO>? EnergyLosses { get; set; }
    }
}
