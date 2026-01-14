using ClaimsProcessor.Domain;

namespace ClaimsProcessor.Test.Domain
{
    public class ClaimTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void Claim_with_negative_amount_is_invalid(int amount)
        {
            var claim = new Claim(1, "prover1", amount, "A01", "Approved");

            Assert.False(claim.IsValid());
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("123")]
        [InlineData("AA123")]
        [InlineData("A12345")]
        [InlineData("AA")]
        public void Claim_with_incorrect_diagnosis_code_is_invalid(string diagnosis)
        {
            var claim = new Claim(1, "prover1", 1, diagnosis, "Approved");

            Assert.False(claim.IsValid());
        }

        [Theory]
        [InlineData(1, "A01")]
        [InlineData(44, "B123")]
        [InlineData(180, "A1234")]
        public void Claim_with_correct_diagnosis_code_and_amount_is_invalid(int amount, string diagnosis)
        {
            var claim = new Claim(1, "prover1", amount, diagnosis, "Approved");

            Assert.True(claim.IsValid());
        }
    }
}
