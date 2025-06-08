using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioSentinela___.NET.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Bioma = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Created = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Updated = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataUpdated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Username = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Created = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    DataCreated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Updated = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataUpdated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    RegiaoId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Created = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Updated = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataUpdated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alerta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    SensorId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Created = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Updated = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataUpdated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerta_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_SensorId",
                table: "Alerta",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_RegiaoId",
                table: "Sensor",
                column: "RegiaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Regiao");
        }
    }
}
