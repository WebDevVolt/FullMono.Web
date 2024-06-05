namespace FullMono.Shared.ExceptionHelpers
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
