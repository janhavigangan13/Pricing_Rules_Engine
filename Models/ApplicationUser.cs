namespace PricingRulesApi.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!; // Admin / User
    }
}
