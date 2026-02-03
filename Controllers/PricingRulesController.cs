using Microsoft.AspNetCore.Mvc;
using PricingRulesApi.DTOs;
using PricingRulesApi.Services;

namespace PricingRulesApi.Controllers
{
    [ApiController]
    [Route("api/pricing-rules")]
    public class PricingRulesController : ControllerBase
    {
        private readonly PricingRuleService _service;

        public PricingRulesController(PricingRuleService service)
        {
            _service = service;
        }
        [HttpPost("evaluate")]
        public async Task<IActionResult> Evaluate(EvaluatePricingRequestDto dto)
        {
            var result = await _service.EvaluatePrice(dto.BasePrice);
            return Ok(result);
        }
    }
}
