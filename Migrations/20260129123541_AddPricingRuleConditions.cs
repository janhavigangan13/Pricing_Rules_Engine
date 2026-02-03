using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingRulesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPricingRuleConditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveFrom",
                table: "PricingRules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveTo",
                table: "PricingRules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxBasePrice",
                table: "PricingRules",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinBasePrice",
                table: "PricingRules",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "PricingRules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectiveFrom",
                table: "PricingRules");

            migrationBuilder.DropColumn(
                name: "EffectiveTo",
                table: "PricingRules");

            migrationBuilder.DropColumn(
                name: "MaxBasePrice",
                table: "PricingRules");

            migrationBuilder.DropColumn(
                name: "MinBasePrice",
                table: "PricingRules");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "PricingRules");
        }
    }
}
