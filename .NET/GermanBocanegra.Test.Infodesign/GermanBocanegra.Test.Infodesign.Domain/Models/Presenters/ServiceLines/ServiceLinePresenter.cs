using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.EnergyMetrics;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.ServiceLines
{
    public class ServiceLinePresenter : BasePresenter
    {
        public int ID { get; set; }
        public string ServiceLineName { get; set; } = string.Empty;

        public virtual ICollection<EnergyConsumptionPresenter>? EnergyConsumptions { get; set; }
        public virtual ICollection<EnergyCostPresenter>? EnergyCosts { get; set; }
        public virtual ICollection<EnergyLossPresenter>? EnergyLosses { get; set; }
    }
}
