using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZombieParty.Migrations
{
    /// <inheritdoc />
    public partial class Huntinglogss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HuntingLogs",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Nettoyage complet des entrepôts abandonnés près du port.", "Zone Industrielle" },
                    { 2, "Rapport de patrouille nocturne et sécurisation du périmètre.", "Secteur Nord" },
                    { 3, "Recherche de survivants et élimination d'une petite horde errante.", "Forêt Sombre" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HuntingLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HuntingLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HuntingLogs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
