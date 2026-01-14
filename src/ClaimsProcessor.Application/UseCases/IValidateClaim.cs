using ClaimsProcessor.Application.Response;
using ClaimsProcessor.Domain;

namespace ClaimsProcessor.Application.UseCases
{
    public interface IValidateClaim
    {
        ValidateClaimResponse Execute(IEnumerable<Claim> claim);
    }
}
