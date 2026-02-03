using Microsoft.EntityFrameworkCore;
using PricingRulesApi.Data;
using PricingRulesApi.DTOs;
using PricingRulesApi.Models;

namespace PricingRulesApi.Services
{
    public class PricingRuleService
    {
        private readonly PricingDbContext _context;

        public PricingRuleService(PricingDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluatePricingResponseDto> EvaluatePrice(decimal basePrice)
        {
            decimal finalPrice = basePrice;
            var appliedRules = new List<string>();

            var today = DateTime.UtcNow.Date;

            var rules = await _context.PricingRules
                .Where(r =>
                    r.IsActive &&
                    (r.EffectiveFrom == null || r.EffectiveFrom <= today) &&
                    (r.EffectiveTo == null || r.EffectiveTo >= today) &&
                    (r.MinBasePrice == null || basePrice >= r.MinBasePrice) &&
                    (r.MaxBasePrice == null || basePrice <= r.MaxBasePrice)
                )
                .OrderBy(r => r.Priority)
                .ToListAsync();

            foreach (var rule in rules)
            {
                decimal amount = rule.IsPercentage
                    ? basePrice * rule.Value / 100
                    : rule.Value;

                if (rule.RuleType == "DISCOUNT")
                {
                    finalPrice -= amount;
                    appliedRules.Add($"Discount: {rule.RuleName}");
                }
                else if (rule.RuleType == "SURCHARGE")
                {
                    finalPrice += amount;
                    appliedRules.Add($"Surcharge: {rule.RuleName}");
                }
            }

            return new EvaluatePricingResponseDto
            {
                BasePrice = basePrice,
                FinalPrice = finalPrice,
                AppliedRules = appliedRules
            };
        }

        public async Task<PricingRule> CreateRule(CreatePricingRuleDto dto)
        {
            var rule = new PricingRule
            {
                RuleName = dto.RuleName,
                RuleType = dto.RuleType,
                Value = dto.Value,
                IsPercentage = dto.IsPercentage,
                Priority = dto.Priority,
                MinBasePrice = dto.MinBasePrice,
                MaxBasePrice = dto.MaxBasePrice,
                EffectiveFrom = dto.EffectiveFrom,
                EffectiveTo = dto.EffectiveTo,
                IsActive = true
            };

            _context.PricingRules.Add(rule);
            await _context.SaveChangesAsync();

            return rule;
        }

        public async Task<List<PricingRule>> GetAllRules()
        {
            return await _context.PricingRules
                .OrderBy(r => r.Priority)
                .ToListAsync();
        }

        public async Task DeactivateRule(int ruleId)
        {
            var rule = await _context.PricingRules.FindAsync(ruleId);
            if (rule == null) throw new Exception("Rule not found");

            rule.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
