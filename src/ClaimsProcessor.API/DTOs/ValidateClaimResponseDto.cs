namespace ClaimsProcessor.API.DTOs
{
    public record ValidateClaimResponseDto
    {
        public ValidateClaimResponseDto(int validClaims, int totalClaims, int invalidClaims, decimal totalApprovedAmount)
        {
            ValidClaims = validClaims;
            TotalClaims = totalClaims;
            InvalidClaims = invalidClaims;
        }

        public int TotalClaims { get; init; }
        public int ValidClaims { get; init; }
        public int InvalidClaims { get; init; }
        public int TotalApprovedAmount { get; init; }
    }
}
