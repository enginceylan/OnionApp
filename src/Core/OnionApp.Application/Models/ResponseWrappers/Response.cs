namespace OnionApp.Application.Models.ResponseWrappers
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }

        public Response()
        {

        }
        public Response(T data, int statusCode)
        {
            Succeeded = true;
            Data = data;
            ErrorMessages = null;
            StatusCode = statusCode;
        }

        public Response(List<string> errorMessages, int statusCode)
        {
            Succeeded = false;
            Data = null;
            ErrorMessages = errorMessages;
            StatusCode = statusCode;
        }

        public Response(string errorMessage, int statusCode)
        {
            Succeeded = false;
            Data = null;
            ErrorMessages = new List<string> { errorMessage };
            StatusCode = statusCode;
        }
    }
}
