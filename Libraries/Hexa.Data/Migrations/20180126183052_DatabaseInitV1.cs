using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hexa.Data.Migrations
{
    public partial class DatabaseInitV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    AdminComment = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CustomerGuid = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FailedLoginAttempts = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCustomerRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerRoleId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCustomerRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerRoles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerRoles_CustomerRoles_CustomerRoleId",
                        column: x => x.CustomerRoleId,
                        principalTable: "CustomerRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenManager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    TokenKey = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TokenManager_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerRoles_CustomerId",
                table: "CustomerCustomerRoles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerRoles_CustomerRoleId",
                table: "CustomerCustomerRoles",
                column: "CustomerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenManager_CustomerId",
                table: "TokenManager",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCustomerRoles");

            migrationBuilder.DropTable(
                name: "TokenManager");

            migrationBuilder.DropTable(
                name: "CustomerRoles");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
