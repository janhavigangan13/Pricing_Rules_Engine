namespace PricingRulesApi.DTOs
{
    public class CreatePricingRuleDto
    {
        public string RuleName { get; set; }
        public string RuleType { get; set; }
        public decimal Value { get; set; }
        public bool IsPercentage { get; set; }
        public int Priority { get; set; }

        public decimal? MinBasePrice { get; set; }
        public decimal? MaxBasePrice { get; set; }

        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
