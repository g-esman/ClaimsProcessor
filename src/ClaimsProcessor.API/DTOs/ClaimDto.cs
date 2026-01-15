using System.ComponentModel.DataAnnotations;

namespace ClaimsProcessor.API.DTOs
{
    public record ClaimDto
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public string Provider { get; init; } = string.Empty;
        [Required]
        public decimal Amount { get; init; }
        [Required]
        public string DiagnosisCode { get; init; } = string.Empty;
        [Required]
        public string Status { get; init; } = string.Empty;
    }
}
