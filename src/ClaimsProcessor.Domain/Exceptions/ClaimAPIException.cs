namespace ClaimsProcessor.Domain.Exceptions
{
    public class ClaimAPIException : Exception
    {
        public ClaimAPIException(string message) : base(message) { }
    }
}
