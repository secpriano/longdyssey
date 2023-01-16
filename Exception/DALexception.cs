namespace ExceptionHandler
{
    public class DALexception : Exception
    {
        public ErrorType ErrorType { get; set; }
        public DALexception(ErrorType errorType, string errorMessage) : base(errorMessage)
        {
            ErrorType = errorType;
        }
    }
}
