namespace ExceptionHandler
{
    public class InvalidInputException : Exception
    {
        public List<(string Error, string Fix)> ErrorAndFixMessages { get; set; }
        
        public InvalidInputException(List<(string Error, string Fix)> errorAndFixMessages) : base()
        {
            ErrorAndFixMessages = errorAndFixMessages;
        }
    }
}
