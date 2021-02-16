using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VactionApi.Migrations
{
    public partial class ExtendedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Managerss",
                table: "Managerss");

            migrationBuilder.RenameTable(
                name: "Managerss",
                newName: "Manger");

            migrationBuilder.RenameColumn(
                name: "vacations",
                table: "Employeess",
                newName: "Vacations");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Employeess",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Employeess",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employeess",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Manger",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "MangerID",
                table: "Employeess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Manger",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manger",
                table: "Manger",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Vacation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VactionDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployeesID = table.Column<int>(nullable: true),
                    EmpID = table.Column<int>(nullable: false),
                    MangerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vacation_Employeess_EmployeesID",
                        column: x => x.EmployeesID,
                        principalTable: "Employeess",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacation_Manger_MangerId",
                        column: x => x.MangerId,
                        principalTable: "Manger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employeess_MangerID",
                table: "Employeess",
                column: "MangerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_EmployeesID",
                table: "Vacation",
                column: "EmployeesID");

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_MangerId",
                table: "Vacation",
                column: "MangerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeess_Manger_MangerID",
                table: "Employeess",
                column: "MangerID",
                principalTable: "Manger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeess_Manger_MangerID",
                table: "Employeess");

            migrationBuilder.DropTable(
                name: "Vacation");

            migrationBuilder.DropIndex(
                name: "IX_Employeess_MangerID",
                table: "Employeess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manger",
                table: "Manger");

            migrationBuilder.DropColumn(
                name: "MangerID",
                table: "Employeess");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Manger");

            migrationBuilder.RenameTable(
                name: "Manger",
                newName: "Managerss");

            migrationBuilder.RenameColumn(
                name: "Vacations",
                table: "Employeess",
                newName: "vacations");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Employeess",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employeess",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employeess",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Managerss",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managerss",
                table: "Managerss",
                column: "id");
        }
    }
}
