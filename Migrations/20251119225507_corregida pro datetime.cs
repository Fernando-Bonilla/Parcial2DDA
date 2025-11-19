using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2DDA.Migrations
{
    /// <inheritdoc />
    public partial class corregidaprodatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Duracion",
                table: "Registros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Registros");
        }
    }
}
