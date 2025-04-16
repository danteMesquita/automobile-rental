using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomobileRentalManagementAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorcycle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NavigationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    LicensePlate = table.Column<string>(type: "text", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.NavigationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NavigationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.NavigationId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NavigationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Plan = table.Column<int>(type: "integer", nullable: false),
                    IdDeliveryPerson = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMotorcycle = table.Column<Guid>(type: "uuid", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Motorcycle_IdMotorcycle",
                        column: x => x.IdMotorcycle,
                        principalTable: "Motorcycle",
                        principalColumn: "NavigationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_User_IdDeliveryPerson",
                        column: x => x.IdDeliveryPerson,
                        principalTable: "User",
                        principalColumn: "NavigationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_IdDeliveryPerson",
                table: "Location",
                column: "IdDeliveryPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Location_IdMotorcycle",
                table: "Location",
                column: "IdMotorcycle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Motorcycle");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
