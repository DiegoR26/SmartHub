using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cod = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Taxation = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    IM = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    IE = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DecPassword = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Observations = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    SefazAccess = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Declaration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Competence = table.Column<DateTime>(type: "DATE", nullable: false),
                    Situation = table.Column<int>(type: "TEXT", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declaration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declaration_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Competence = table.Column<DateTime>(type: "DATE", nullable: false),
                    Situation = table.Column<int>(type: "TEXT", maxLength: 20, nullable: false),
                    Value = table.Column<double>(type: "DECIMAL(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slip_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Declaration_Client_Competence",
                table: "Declaration",
                columns: new[] { "ClientId", "Competence" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slip_Client_Competence",
                table: "Slip",
                columns: new[] { "ClientId", "Competence" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Declaration");

            migrationBuilder.DropTable(
                name: "Slip");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
