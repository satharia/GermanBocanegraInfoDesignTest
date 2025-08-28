using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.EnergyMetrics;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.MeasurementSegments
{
    public class TimeSegmentPresenter : BasePresenter
    {
        public int ID { get; set; }
        public DateOnly TimeSegmentDate { get; set; }

        public virtual ICollection<EnergyConsumptionPresenter>? EnergyConsumptions { get; set; }
        public virtual ICollection<EnergyCostPresenter>? EnergyCosts { get; set; }
        public virtual ICollection<EnergyLossPresenter>? EnergyLosses { get; set; }
    }
}
