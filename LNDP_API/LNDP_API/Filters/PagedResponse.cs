public class PagedResponse<T> : Response<T>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public Uri? FirstPage { get; set; }
    public Uri? LastPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalEntries { get; set; }
    public Uri? NextPage { get; set; }
    public Uri? PreviousPage { get; set; }

    public PagedResponse(T data, int number, int size)
    {
        this.Page = number;
        this.Size = size;
        this.Data = data;
        this.Message = null;
        this.Succeeded = true;
        this.Errors = null;
    }
}