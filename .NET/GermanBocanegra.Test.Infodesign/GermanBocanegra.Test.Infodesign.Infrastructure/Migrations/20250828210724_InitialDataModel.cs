using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GermanBocanegra.Test.Infodesign.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceLine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLineName = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSegment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSegmentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSegment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EnergyConsumption",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLineID = table.Column<int>(type: "int", nullable: false),
                    TimeSegmentID = table.Column<int>(type: "int", nullable: false),
                    Residential = table.Column<int>(type: "int", nullable: false),
                    Commercial = table.Column<int>(type: "int", nullable: false),
                    Industrial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyConsumption", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnergyConsumption_ServiceLine_ServiceLineID",
                        column: x => x.ServiceLineID,
                        principalTable: "ServiceLine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnergyConsumption_TimeSegment_TimeSegmentID",
                        column: x => x.TimeSegmentID,
                        principalTable: "TimeSegment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnergyCost",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLineID = table.Column<int>(type: "int", nullable: false),
                    TimeSegmentID = table.Column<int>(type: "int", nullable: false),
                    Residential = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Commercial = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Industrial = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyCost", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnergyCost_ServiceLine_ServiceLineID",
                        column: x => x.ServiceLineID,
                        principalTable: "ServiceLine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnergyCost_TimeSegment_TimeSegmentID",
                        column: x => x.TimeSegmentID,
                        principalTable: "TimeSegment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLoss",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLineID = table.Column<int>(type: "int", nullable: false),
                    TimeSegmentID = table.Column<int>(type: "int", nullable: false),
                    Residential = table.Column<decimal>(type: "decimal(11,10)", nullable: false),
                    Commercial = table.Column<decimal>(type: "decimal(11,10)", nullable: false),
                    Industrial = table.Column<decimal>(type: "decimal(11,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLoss", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnergyLoss_ServiceLine_ServiceLineID",
                        column: x => x.ServiceLineID,
                        principalTable: "ServiceLine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnergyLoss_TimeSegment_TimeSegmentID",
                        column: x => x.TimeSegmentID,
                        principalTable: "TimeSegment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnergyConsumption_ServiceLineID",
                table: "EnergyConsumption",
                column: "ServiceLineID");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyConsumption_TimeSegmentID",
                table: "EnergyConsumption",
                column: "TimeSegmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyCost_ServiceLineID",
                table: "EnergyCost",
                column: "ServiceLineID");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyCost_TimeSegmentID",
                table: "EnergyCost",
                column: "TimeSegmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLoss_ServiceLineID",
                table: "EnergyLoss",
                column: "ServiceLineID");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLoss_TimeSegmentID",
                table: "EnergyLoss",
                column: "TimeSegmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyConsumption");

            migrationBuilder.DropTable(
                name: "EnergyCost");

            migrationBuilder.DropTable(
                name: "EnergyLoss");

            migrationBuilder.DropTable(
                name: "ServiceLine");

            migrationBuilder.DropTable(
                name: "TimeSegment");
        }
    }
}
