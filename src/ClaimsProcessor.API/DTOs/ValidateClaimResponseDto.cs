namespace ClaimsProcessor.API.DTOs
{
    public record ValidateClaimResponseDto
    {
        public ValidateClaimResponseDto(int validClaims, int totalClaims, int invalidClaims, decimal totalApprovedAmount)
        {
            ValidClaims = validClaims;
            TotalClaims = totalClaims;
            InvalidClaims = invalidClaims;
            TotalApprovedAmount = totalApprovedAmount;
        }

        public int TotalClaims { get; init; }
        public int ValidClaims { get; init; }
        public int InvalidClaims { get; init; }
        public decimal TotalApprovedAmount { get; init; }
    }
}
