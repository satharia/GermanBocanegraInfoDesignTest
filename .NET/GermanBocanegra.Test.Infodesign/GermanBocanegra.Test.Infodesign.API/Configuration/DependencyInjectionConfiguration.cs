using GermanBocanegra.Test.Infodesign.Application.UseCases.DataLoader;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.ServiceLines;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.ServiceLines;
using GermanBocanegra.Test.Infodesign.Domain.Ports.Input.DataLoader;
using GermanBocanegra.Test.Infodesign.Domain.Ports.Output;
using GermanBocanegra.Test.Infodesign.Infrastructure.Adapters.Output;

namespace GermanBocanegra.Test.Infodesign.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static WebApplicationBuilder ConfigureDependencies(this WebApplicationBuilder builder)
        {
            builder.ConfigureRepositories();

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IHistoricDataLoaderInputPort, ExcelHistoricDataLoaderUseCase>();

            return builder;
        }

        private static WebApplicationBuilder ConfigureRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGenericPureEntityOutputPort<EnergyConsumptionDTO, EnergyConsumptionEntity>, 
                EFGenericPureEntityOutputAdapter<EnergyConsumptionDTO, EnergyConsumptionEntity>>();
            builder.Services.AddScoped<IGenericPureEntityOutputPort<EnergyCostDTO, EnergyCostEntity>,
                EFGenericPureEntityOutputAdapter<EnergyCostDTO, EnergyCostEntity>>();
            builder.Services.AddScoped<IGenericPureEntityOutputPort<EnergyLossDTO, EnergyLossEntity>,
                EFGenericPureEntityOutputAdapter<EnergyLossDTO, EnergyLossEntity>>();
            builder.Services.AddScoped<IGenericPureEntityOutputPort<TimeSegmentDTO, TimeSegmentEntity>,
                EFGenericPureEntityOutputAdapter<TimeSegmentDTO, TimeSegmentEntity>>();
            builder.Services.AddScoped<IGenericPureEntityOutputPort<ServiceLineDTO, ServiceLineEntity>,
                EFGenericPureEntityOutputAdapter<ServiceLineDTO, ServiceLineEntity>>();

            return builder;
        }
    }
}
