namespace TesteTecnico.Services
{
    public class Result<T>
    {
        public Result(T data, bool success)
        {
            Data = data;
            isSuccess = success;
        }

        public Result(T data, bool success, string location)
        {
            Data = data;
            isSuccess = success;
            Location = location;
        }

        public Result(string error)
        {
            Error = error;
        }

        public T Data { get; set; }
        public string Error { get; set; }
        public bool isSuccess { get; set; }
        public string Location { get; set; }
    }
}