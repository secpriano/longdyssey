namespace ExceptionHandler
{
    public class ErrorResponse : Exception
    {
        public ErrorType ErrorType { get; }
        public ErrorResponse(ErrorType errorType) : base(GetErrorMessage(errorType)) 
        {
            ErrorType = errorType;
        }

        public static string GetErrorMessage(ErrorType errorType) => errorType switch
        {
            ErrorType.DatabaseConnection => "Sorry, we are unable to connect to the database at this time. Please try again later or contact our support team for assistance.",
            ErrorType.FlightsAreEmpty => "Sorry, we are unable to find any flights that match your search criteria. Please try again with different search criteria.",
            ErrorType.SeatTaken => "Sorry, the seat you have selected is no longer available. Please try again with different search criteria.",
            _ => "Unknown error",
        };
    }
}
