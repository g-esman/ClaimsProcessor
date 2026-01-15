using ClaimsProcessor.API.DTOs;
using ClaimsProcessor.Domain;

namespace ClaimsProcessor.API.Mapping
{
    public static class ValidateClaimDtoMapping
    {
        public static Claim ToModel(
            this ClaimDto dto)
        {
            return new Claim(
                dto.Id,
                dto.Provider,
                dto.Amount,
                dto.DiagnosisCode,
                dto.Status
            );
        }
    }
}
