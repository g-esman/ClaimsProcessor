using ClaimsProcessor.Application.Response;
using ClaimsProcessor.Domain;

namespace ClaimsProcessor.Application.UseCases
{
    public class ValidateClaim : IValidateClaim
    {
        public ValidateClaimResponse Execute(IEnumerable<Claim> claim)
        {
            var response = new ValidateClaimResponse();

            response.TotalClaims = claim.Count();
            response.ValidClaims = claim.Count(c => c.IsValid());
            response.InvalidClaims = response.TotalClaims - response.ValidClaims;
            response.TotalApprovedAmount = claim.Where(c => c.IsValidAndApproved()).Sum(c => c.Amount);

            return response;
        }
    }
}
