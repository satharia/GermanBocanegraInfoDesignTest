using AutoMapper;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.ServiceLines;
using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters.ServiceLines;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Mappers
{
    public class AutoMapperDTOToPresenterProfile : Profile
    {
        public AutoMapperDTOToPresenterProfile() 
        {
            CreateMap<EnergyConsumptionDTO, EnergyConsumptionPresenter>();
            CreateMap<EnergyCostDTO, EnergyCostPresenter>();
            CreateMap<EnergyLossDTO, EnergyLossPresenter>();
            CreateMap<TimeSegmentDTO, TimeSegmentPresenter>();
            CreateMap<ServiceLineDTO, ServiceLinePresenter>();
        }
    }
}
