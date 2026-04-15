namespace TesteTecnico.Services
{
    public class Result<T>
    {
        public bool isSuccess { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
        public string Location { get; set; }

        public Result(T data)
        {
            isSuccess = true;
            Data = data;
        }

        public Result(T data, string location)
        {
            isSuccess = true;
            Data = data;
            Location = location;
        }

        public Result(string error)
        {
            isSuccess = false;
            Error = error;
        }
    }
}