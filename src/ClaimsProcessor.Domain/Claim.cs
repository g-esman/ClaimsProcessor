using System.Text.RegularExpressions;

namespace ClaimsProcessor.Domain
{
    public class Claim
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public decimal Amount { get; set; }
        public string DiagnosisCode { get; set; }
        public string Status { get; set; }

        public Claim(int id,
                    string providerName,
                    decimal amount,
                    string diagnosisCode,
                    string status)
        {
            Id = id;
            ProviderName = providerName;
            Amount = amount;
            DiagnosisCode = diagnosisCode;
            Status = status;
        }

        public bool IsValid() => this.Amount > 0 && CodeIsValid();

        public bool IsValidAndApproved() => IsValid() && string.Equals(this.Status,"Approved",StringComparison.OrdinalIgnoreCase);

        private bool CodeIsValid()
        {
            return Regex.IsMatch(
                this.DiagnosisCode,
                "^[A-Z][0-9]{2,4}$"
            );
        }
    }
}