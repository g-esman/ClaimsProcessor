using ClaimsProcessor.API.DTOs;
using ClaimsProcessor.Application.UseCases;
using ClaimsProcessor.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {

        private readonly ILogger<ClaimsController> _logger;
        private readonly IValidateClaim _validate;
        public ClaimsController(ILogger<ClaimsController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "claims/validate")]
        public ValidateClaimAPIResponse Validate(IEnumerable<ClaimDto> claims)
        {
            _validate.Execute(new List<Claim>());
            return new ValidateClaimAPIResponse();
        }
    }
}
