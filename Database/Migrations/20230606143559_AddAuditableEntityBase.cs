using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airbnb.Infrastructure.Persistence.Migrations
{
    public partial class AddAuditableEntityBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tipos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Tipos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Airbnbs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Airbnbs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Airbnbs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Airbnbs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Airbnbs");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Airbnbs");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Airbnbs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Airbnbs");
        }
    }
}
