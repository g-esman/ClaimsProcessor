using ClaimsProcessor.API.DTOs;
using ClaimsProcessor.Application.Response;

namespace ClaimsProcessor.API.Mapping
{
    public static class ValidateClaimResponseMapping
    {
        public static ValidateClaimResponseDto ToDto(
            this ValidateClaimResponse model)
        {
            return new ValidateClaimResponseDto(
                model.ValidClaims,
                model.TotalClaims,
                model.InvalidClaims,
                model.TotalApprovedAmount
            );
        }
    }
}
