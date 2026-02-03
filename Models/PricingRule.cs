namespace PricingRulesApi.Models
{
    public class PricingRule
    {
        public int Id { get; set; }

        public string RuleName { get; set; } = string.Empty;

        public string RuleType { get; set; } = string.Empty;
        // Discount | Surcharge

        public decimal Value { get; set; }

        public bool IsPercentage { get; set; }

        public bool IsActive { get; set; } = true;

        public int Priority { get; set; }

        public decimal? MinBasePrice { get; set; }

        public decimal? MaxBasePrice { get; set; }

        public DateTime? EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }

        //public DateTime ValidFrom { get; set; }
        //public DateTime ValidTo { get; set; }

        //public string ConditionsJson { get; set; } = string.Empty;

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
