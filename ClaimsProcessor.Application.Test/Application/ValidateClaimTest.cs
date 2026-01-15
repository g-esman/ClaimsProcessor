using ClaimsProcessor.Application.UseCases;
using ClaimsProcessor.Domain;

namespace ClaimsProcessor.Test.Application
{
    public class ValidateClaimTest
    {
        [Fact]
        public void Execute_should_return_total_claims_including_valid_and_invalid()
        {
            var claims = new List<Claim>
            {
                new Claim(1, "prover1", 1, "A01", "Approved"),
                new Claim(2, "prover2", 0, "A01", "Approved")
            };

            var useCase = new ValidateClaim();

            var result = useCase.Execute(claims);

            Assert.Equal(2, result.TotalClaims);
        }

        [Fact]
        public void Execute_should_return_valid_claims_including_only_valid()
        {
            var claims = new List<Claim>
            {
                new Claim(1, "prover1", 1, "A01", "Approved"),
                new Claim(2, "prover2", 2, "A01", "Approved"),
            };

            var useCase = new ValidateClaim();

            var result = useCase.Execute(claims);

            Assert.Equal(2, result.ValidClaims);
            Assert.Equal(0, result.InvalidClaims);
        }

        [Fact]
        public void Execute_should_return_invalid_claims_including_only_invalid()
        {
            var claims = new List<Claim>
            {
                new Claim(2, "prover2", -3, "A01", "Approved"),
                new Claim(3, "prover3", 0, "A01", "Approved")
            };

            var useCase = new ValidateClaim();

            var result = useCase.Execute(claims);

            Assert.Equal(2, result.InvalidClaims);
            Assert.Equal(0, result.ValidClaims);
        }

        [Fact]
        public void Execute_should_return_total_approved_amount_0()
        {
            var claims = new List<Claim>
            {
                new Claim(3, "prover3", 4, "A01", "Rejected"),
            };

            var useCase = new ValidateClaim();

            var result = useCase.Execute(claims);

            Assert.Equal(0, result.TotalApprovedAmount);
        }

        [Fact]
        public void Execute_should_return_total_approved_amount_including_only_valid_and_approved_claims()
        {
            var claims = new List<Claim>
            {
                new Claim(1,"Clinic A",(decimal)100.50,"A01","approved"),
                new Claim(2,"Clinic B",(decimal)-50,"123","Pending")
            };

            var useCase = new ValidateClaim();

            var result = useCase.Execute(claims);

            Assert.Equal((decimal)100.50, result.TotalApprovedAmount);
        }
    }
}
