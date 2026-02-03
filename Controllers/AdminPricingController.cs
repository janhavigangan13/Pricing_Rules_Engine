using Microsoft.AspNetCore.Mvc;
using PricingRulesApi.DTOs;
using PricingRulesApi.Services;

namespace PricingRulesApi.Controllers
{
    [ApiController]
    [Route("api/admin/pricing")]
    public class AdminPricingController : ControllerBase
    {
        private readonly PricingRuleService _service;

        public AdminPricingController(PricingRuleService service)
        {
            _service = service;
        }

        // Admin creates rule
        [HttpPost("rules")]
        public async Task<IActionResult> CreateRule(CreatePricingRuleDto dto)
        {
            var rule = await _service.CreateRule(dto);
            return Ok(rule);
        }

        // Admin views all rules
        [HttpGet("rules")]
        public async Task<IActionResult> GetRules()
        {
            return Ok(await _service.GetAllRules());
        }

        // Admin disables rule
        [HttpPut("rules/{id}/deactivate")]
        public async Task<IActionResult> DeactivateRule(int id)
        {
            await _service.DeactivateRule(id);
            return Ok("Rule deactivated");
        }
    }
}
