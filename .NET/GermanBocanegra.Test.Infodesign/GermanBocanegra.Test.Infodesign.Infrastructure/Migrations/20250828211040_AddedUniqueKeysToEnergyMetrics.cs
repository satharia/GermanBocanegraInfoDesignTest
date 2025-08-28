using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueKeysToEnergyMetrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EnergyLoss_ServiceLineID",
                table: "EnergyLoss");

            migrationBuilder.DropIndex(
                name: "IX_EnergyCost_ServiceLineID",
                table: "EnergyCost");

            migrationBuilder.DropIndex(
                name: "IX_EnergyConsumption_ServiceLineID",
                table: "EnergyConsumption");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLoss_ServiceLineID_TimeSegmentID",
                table: "EnergyLoss",
                columns: new[] { "ServiceLineID", "TimeSegmentID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnergyCost_ServiceLineID_TimeSegmentID",
                table: "EnergyCost",
                columns: new[] { "ServiceLineID", "TimeSegmentID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnergyConsumption_ServiceLineID_TimeSegmentID",
                table: "EnergyConsumption",
                columns: new[] { "ServiceLineID", "TimeSegmentID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EnergyLoss_ServiceLineID_TimeSegmentID",
                table: "EnergyLoss");

            migrationBuilder.DropIndex(
                name: "IX_EnergyCost_ServiceLineID_TimeSegmentID",
                table: "EnergyCost");

            migrationBuilder.DropIndex(
                name: "IX_EnergyConsumption_ServiceLineID_TimeSegmentID",
                table: "EnergyConsumption");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLoss_ServiceLineID",
                table: "EnergyLoss",
                column: "ServiceLineID");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyCost_ServiceLineID",
                table: "EnergyCost",
                column: "ServiceLineID");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyConsumption_ServiceLineID",
                table: "EnergyConsumption",
                column: "ServiceLineID");
        }
    }
}
