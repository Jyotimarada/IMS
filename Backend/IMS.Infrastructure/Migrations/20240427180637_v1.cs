using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(400)", nullable: false),
                    Description = table.Column<string>(type: "Text", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    BarCode = table.Column<string>(type: "Varchar(8000)", nullable: true),
                    Shared = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2024, 4, 27, 18, 6, 37, 249, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 0, 0, 0, 0))),
                    DateUpdated = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "varchar(200)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", nullable: false),
                    Title = table.Column<string>(type: "varchar(500)", nullable: true),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2024, 4, 27, 18, 6, 37, 249, DateTimeKind.Unspecified).AddTicks(4440), new TimeSpan(0, 0, 0, 0, 0))),
                    DateUpdated = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2024, 4, 27, 18, 6, 37, 249, DateTimeKind.Unspecified).AddTicks(4101), new TimeSpan(0, 0, 0, 0, 0))),
                    DateUpdated = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDevice_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDevice_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "BarCode", "DateDeleted", "DateUpdated", "Description", "Name", "Shared", "Type" },
                values: new object[,]
                {
                    { 1, "123456789", null, null, "Legion Series", "Lenovo LOQ", false, 1 },
                    { 2, "123456790", null, null, "ONE Plus Nord 5G", "ONE PLUS Nord", false, 2 },
                    { 3, "123456791", null, null, "Cisco IP phone for the cubicle", "Cisco IP phone", true, 3 }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DateDeleted", "DateUpdated", "Email", "FirstName", "LastName", "Title" },
                values: new object[,]
                {
                    { 1, null, null, "frodo.baggins@lotr.dev", "Frodo", "Baggins", "" },
                    { 2, null, null, "samwise.gamgee@lotr.dev", "Samwise", "Gamgee", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDevice_DeviceId",
                table: "EmployeeDevice",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDevice_EmployeeId",
                table: "EmployeeDevice",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDevice");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
