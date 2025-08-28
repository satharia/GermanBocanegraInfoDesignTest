using AutoMapper;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.ServiceLines;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.ServiceLines;

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Mappers
{
    public class AutoMapperEntityToDTOProfile : Profile
    {
        public AutoMapperEntityToDTOProfile() 
        {
            CreateMap<EnergyConsumptionEntity, EnergyConsumptionDTO>();
            CreateMap<EnergyCostEntity, EnergyCostDTO>();
            CreateMap<EnergyLossEntity, EnergyLossDTO>();
            CreateMap<TimeSegmentEntity, TimeSegmentDTO>();
            CreateMap<ServiceLineEntity, ServiceLineDTO>();
        }
    }
}
