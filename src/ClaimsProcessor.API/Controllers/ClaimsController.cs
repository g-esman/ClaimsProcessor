using ClaimsProcessor.API.DTOs;
using ClaimsProcessor.API.Mapping;
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
        public ValidateClaimResponseDto Validate(IEnumerable<ClaimDto> claimsDto)
        {
            var claimsModel = claimsDto.Select(c => ValidateClaimDtoMapping.ToModel(c));

            var response = _validate.Execute(claimsModel);

            return ValidateClaimResponseMapping.ToDto(response);
        }
    }
}
