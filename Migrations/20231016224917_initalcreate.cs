using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QualifiTest.Migrations
{
    /// <inheritdoc />
    public partial class initalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "CustomerAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinSalaryRange = table.Column<double>(type: "float", nullable: false),
                    MaxSalaryRange = table.Column<double>(type: "float", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProducts_LoanProductType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "LoanProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanProductCustomerHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    LoanProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProductCustomerHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProductCustomerHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanProductCustomerHistories_LoanProducts_LoanProductId",
                        column: x => x.LoanProductId,
                        principalTable: "LoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoanProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Credit Card" },
                    { 2, "Buy Now Pay Later" },
                    { 3, "Car Finance" },
                    { 4, "Loan Shark" }
                });

            migrationBuilder.InsertData(
                table: "LoanProducts",
                columns: new[] { "Id", "MaxSalaryRange", "MinSalaryRange", "Name", "TypeId" },
                values: new object[,]
                {
                    { 1, 20000.0, 10000.0, "Balance Transfer Card", 1 },
                    { 2, 50000.0, 15000.0, "Interest Free Card", 1 },
                    { 3, 100000000.0, 1000000.0, "Millionaire Card", 1 },
                    { 4, 50000.0, 10000.0, "BNPL Finance", 2 },
                    { 5, 750000.0, 250000.0, "Car Finance 5%", 3 },
                    { 6, 1000000.0, 1.0, "Loan Shark Agreement", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductCustomerHistories_CustomerId",
                table: "LoanProductCustomerHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductCustomerHistories_LoanProductId",
                table: "LoanProductCustomerHistories",
                column: "LoanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProducts_TypeId",
                table: "LoanProducts",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanProductCustomerHistories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LoanProducts");

            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "LoanProductType");
        }
    }
}
