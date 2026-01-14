using ClaimsProcessor.Application.Response;
using ClaimsProcessor.Domain;

namespace ClaimsProcessor.Application.UseCases
{
    public class ValidateClaim : IValidateClaim
    {
        public ValidateClaimResponse Execute(IEnumerable<Claim> claim)
        {
            throw new NotImplementedException();
        }
    }
}
