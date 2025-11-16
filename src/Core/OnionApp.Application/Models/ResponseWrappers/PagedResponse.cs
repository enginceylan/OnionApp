namespace OnionApp.Application.Models.ResponseWrappers
{
    public class PagedResponse<T> : Response<T> where T : class
    {
        public int? CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int? PageSize { get; private set; }
        public int TotalCount { get; private set; }

        //public bool HasPrevious 
        //{ 
        //    get
        //    {
        //        return CurrentPage > 1;
        //    }
        //}

        // yukarıdaki yazım tekniği ile aş. aynı kapıya çıkar : 
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedResponse(string error):base(error,500)
        {
            
        }
        public PagedResponse(List<string> errors) : base(errors,500)
        {
            
        }

        public PagedResponse(T data, int count, int? pageNumber, int? pageSize):base(data,200)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
