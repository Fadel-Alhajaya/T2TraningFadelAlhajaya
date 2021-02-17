using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VactionApi.Migrations
{
    public partial class ExtendedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Managerss",
                newName: "Id");

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

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Managerss",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MangerID",
                table: "Employeess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vactionss",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    VactionDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmployeesID = table.Column<int>(nullable: true),
                    EmpID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vactionss", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vactionss_Employeess_EmployeesID",
                        column: x => x.EmployeesID,
                        principalTable: "Employeess",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employeess_MangerID",
                table: "Employeess",
                column: "MangerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vactionss_EmployeesID",
                table: "Vactionss",
                column: "EmployeesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeess_Managerss_MangerID",
                table: "Employeess",
                column: "MangerID",
                principalTable: "Managerss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeess_Managerss_MangerID",
                table: "Employeess");

            migrationBuilder.DropTable(
                name: "Vactionss");

            migrationBuilder.DropIndex(
                name: "IX_Employeess_MangerID",
                table: "Employeess");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Managerss");

            migrationBuilder.DropColumn(
                name: "MangerID",
                table: "Employeess");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Managerss",
                newName: "id");

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
        }
    }
}
