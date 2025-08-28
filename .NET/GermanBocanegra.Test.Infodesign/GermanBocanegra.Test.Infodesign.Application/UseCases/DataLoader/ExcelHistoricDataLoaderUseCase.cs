using System.Data;
using ExcelDataReader;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.DTOs.ServiceLines;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.EnergyMetrics;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.MeasurementSegments;
using GermanBocanegra.Test.Infodesign.Domain.Models.Entities.ServiceLines;
using GermanBocanegra.Test.Infodesign.Domain.Models.Request.DataLoader;
using GermanBocanegra.Test.Infodesign.Domain.Models.Response.DataLoader;
using GermanBocanegra.Test.Infodesign.Domain.Ports.Input.DataLoader;
using GermanBocanegra.Test.Infodesign.Domain.Ports.Output;

namespace GermanBocanegra.Test.Infodesign.Application.UseCases.DataLoader
{
    public class ExcelHistoricDataLoaderUseCase : IHistoricDataLoaderInputPort
    {
        private const string CONSUMPTION_SHEET_NAME = "CONSUMO_POR_TRAMO";
        private const string COST_SHEET_NAME = "COSTOS_POR_TRAMO";
        private const string LOSS_SHEET_NAME = "PERDIDAS_POR_TRAMO";

        private readonly IGenericPureEntityOutputPort<EnergyConsumptionDTO, EnergyConsumptionEntity> energyConsumptionRepository;

        private readonly IGenericPureEntityOutputPort<EnergyCostDTO, EnergyCostEntity> energyCostRepository;

        private readonly IGenericPureEntityOutputPort<EnergyLossDTO, EnergyLossEntity> energyLossRepository;

        private readonly IGenericPureEntityOutputPort<TimeSegmentDTO, TimeSegmentEntity> timeSegmentRepository;

        private readonly IGenericPureEntityOutputPort<ServiceLineDTO, ServiceLineEntity> serviceLineRepository;

        public ExcelHistoricDataLoaderUseCase(
            IGenericPureEntityOutputPort<EnergyConsumptionDTO, EnergyConsumptionEntity> energyConsumptionRepository,
            IGenericPureEntityOutputPort<EnergyCostDTO, EnergyCostEntity> energyCostRepository,
            IGenericPureEntityOutputPort<EnergyLossDTO, EnergyLossEntity> energyLossRepository,
            IGenericPureEntityOutputPort<TimeSegmentDTO, TimeSegmentEntity> timeSegmentRepository,
            IGenericPureEntityOutputPort<ServiceLineDTO, ServiceLineEntity> serviceLineRepository
            )
        {
            this.energyConsumptionRepository = energyConsumptionRepository;
            this.energyCostRepository = energyCostRepository;
            this.energyLossRepository = energyLossRepository;
            this.timeSegmentRepository = timeSegmentRepository;
            this.serviceLineRepository = serviceLineRepository;
        }

        public async Task<LoadHistoricDataResponse> LoadHistoricDataFromFileAsync(LoadHistoricDataRequest request)
        {
            var response = new LoadHistoricDataResponse();

            using (var stream = File.Open(request.LocalFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    using (DataSet workSheets = reader.AsDataSet())
                    {
                        if (workSheets == null)
                        {
                            throw new SystemException();
                        }

                        var consumptionRowCount = await LoadSheetDataAsync(CONSUMPTION_SHEET_NAME, workSheets);
                        var costRowCount = await LoadSheetDataAsync(COST_SHEET_NAME, workSheets);
                        var lossRowCount = await LoadSheetDataAsync(LOSS_SHEET_NAME, workSheets);

                        response.NumberOfConsumptionRows = consumptionRowCount;
                        response.NumberOfCostRows = costRowCount;
                        response.NumberOfConsumptionRows = lossRowCount;
                    }
                }
            }

            return response;
        }

        private async Task<int> LoadSheetDataAsync(string sheetName, DataSet workSheets)
        {
            var numberOfRows = 0;
            // Key: Name in file, value: ID in DB for foreign key Constraint
            var savedLines = new Dictionary<string, int>();

            using (var specificWorkSheet = workSheets.Tables[sheetName])
            {
                if (specificWorkSheet == null)
                {
                    throw new SystemException();
                }

                foreach (var row in specificWorkSheet.Rows)
                {
                    var dataRow = (DataRow)row;

                    // Todo: Find Line in dictionary, if not present save to DB and add to dictionary
                    var lineName = (string)dataRow[0];
                    var lineID = -1;
                    if (!savedLines.ContainsKey(lineName))
                    {
                        var newLineID = await SaveLineValueToDB(lineName);
                        savedLines.Add(lineName, newLineID);
                        lineID = newLineID;
                    }
                    else
                    {
                        lineID = savedLines[lineName];
                    }

                    var saved = await SaveRowDataAsync(sheetName, dataRow);
                    if (saved)
                    {
                        numberOfRows++;
                    }
                }
            }  

            return numberOfRows;
        }

        // Returns: The Line ID
        private async Task<int> SaveLineValueToDB(string lineName)
        {
            var newLine = new ServiceLineDTO()
            {
                ServiceLineName = lineName
            };

            var newLineObject = await serviceLineRepository.Create(newLine);

            return newLineObject.ID;
        }

        // Returns: true if insert successful, false otherwise
        private async Task<bool> SaveRowDataAsync(string sheetName, DataRow row)
        {
            var saved = false;

            switch (sheetName)
            {
                case CONSUMPTION_SHEET_NAME:
                    // Todo: Insert into consumption Table
                    break;
                case COST_SHEET_NAME:
                    break;
                case LOSS_SHEET_NAME:
                    break;
            }

            return saved;
        }
    }
}
