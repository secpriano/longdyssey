namespace BLL.Entity
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public List<(string Error, string Fix)>? errorAndFixMessages { get; set; }
    }
}
