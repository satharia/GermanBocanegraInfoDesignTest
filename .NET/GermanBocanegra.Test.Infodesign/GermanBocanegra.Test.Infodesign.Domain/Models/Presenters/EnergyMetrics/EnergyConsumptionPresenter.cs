using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.ServiceLines;

namespace GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.EnergyMetrics
{
    public class EnergyConsumptionPresenter : BasePresenter
    {
        public long ID { get; set; }
        public int ServiceLineID { get; set; }
        public int TimeSegmentID { get; set; }
        public int Residential { get; set; }
        public int Commercial { get; set; }
        public int Industrial { get; set; }

        public virtual ServiceLinePresenter? ServiceLine { get; set; }
        public virtual TimeSegmentPresenter? TimeSegment { get; set; }
    }
}
