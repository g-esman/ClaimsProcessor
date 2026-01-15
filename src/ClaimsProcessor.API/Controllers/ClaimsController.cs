using ClaimsProcessor.API.DTOs;
using ClaimsProcessor.API.Mapping;
using ClaimsProcessor.Application.UseCases;
using ClaimsProcessor.Domain;
using ClaimsProcessor.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IValidateClaim _validate;
        public ClaimsController(IValidateClaim validate)
        {
            _validate = validate;
        }

        [HttpPost(Name = "claims/validate")]
        public ValidateClaimResponseDto Validate([FromBody] IEnumerable<ClaimDto> claimsDto)
        {
            if (claimsDto.Count() == 0)
                throw new ClaimAPIException("At least one claim must be provided for validation.");

            var claimsModel = claimsDto.Select(c => ValidateClaimDtoMapping.ToModel(c));

            var response = _validate.Execute(claimsModel);

            return ValidateClaimResponseMapping.ToDto(response);
        }
    }
}
