namespace PricingRulesApi.DTOs
{
    public class EvaluatePricingResponseDto
    {
        public decimal BasePrice { get; set; }
        public decimal FinalPrice { get; set; }
        public List<string> AppliedRules { get; set; } = new();
    }
}
