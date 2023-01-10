namespace BLL.Entity
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public string? PossibleFixesMessage { get; set; }
    }
}
