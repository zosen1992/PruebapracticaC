using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaC_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pruebas",
                columns: new[] { "Id", "Amenidad", "Detalle", "Distancia", "FechaActualizacion", "Fechacreacion", "ImagenUrl", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Algun detalle", 10, new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1892), new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1883), "", "Algun Nombre", 5, 100.0 },
                    { 2, "", "Algun detalle", 10, new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1895), new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1895), "", "Algun Nombre", 5, 100.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pruebas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pruebas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
