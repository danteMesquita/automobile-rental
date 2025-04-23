using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomobileRentalManagementAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableDeliveryPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NavigationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: false),
                    LicenseType = table.Column<string>(type: "text", nullable: false),
                    LicenseImageUrl = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPerson", x => x.NavigationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPerson_Cnpj",
                table: "DeliveryPerson",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPerson_LicenseNumber",
                table: "DeliveryPerson",
                column: "LicenseNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryPerson");
        }
    }
}
