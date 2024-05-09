namespace SimpleProductApi.Utilities
{
    public class PaginationResponseModel<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public T Data { get; set; }
    }
}
