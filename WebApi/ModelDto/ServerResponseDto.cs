namespace WebApi.ModelDto
{
    public class ServerResponseDto<T> where T : class
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public T response { get; set; } = null;
    }
}
