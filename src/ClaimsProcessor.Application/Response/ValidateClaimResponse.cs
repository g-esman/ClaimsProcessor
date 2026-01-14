namespace ClaimsProcessor.Application.Response
{
    public class ValidateClaimResponse
    {
        public int TotalClaims { get; set; }
        public int ValidClaims { get; set; }
        public int InvalidClaims { get; set; }
        public decimal TotalApprovedAmount { get; set; }
    }
}
