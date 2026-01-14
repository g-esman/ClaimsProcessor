namespace ClaimsProcessor.Domain
{
    public class Claim(int id,
                string providerName,
                decimal amount,
                string diagnosisCode,
                string status)
    {
        public int Id { get; set; } = id;
        public string ProviderName { get; set; } = providerName;
        public decimal Amount { get; set; } = amount;
        public string DiagnosisCode { get; set; } = diagnosisCode;
        public string Status { get; set; } = status;
    }
}