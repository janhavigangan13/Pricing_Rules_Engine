using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingRulesApi.Migrations
{
    /// <inheritdoc />
    public partial class Updatedfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConditionsJson",
                table: "PricingRules");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PricingRules");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "PricingRules");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "PricingRules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConditionsJson",
                table: "PricingRules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PricingRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "PricingRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "PricingRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
