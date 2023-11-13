using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWork.Migrations
{
    /// <inheritdoc />
    public partial class CardToDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardCode = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneHome = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    PhoneMobil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    House = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AltAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerGUID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardPer = table.Column<int>(type: "int", nullable: false),
                    TurnOver = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
