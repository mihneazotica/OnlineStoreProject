namespace OnlineStoreAPI.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Ai facut o prostie boss!",
                401 => "N-ai voie!",
                404 => "N-am gasit fratele meu nimic.",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change.",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        
    }
}
