namespace MusicSchool.Application.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public ApiError? Error { get; set; }

        public static ApiResponse<T> Ok(T data) =>
            new ApiResponse<T> { Success = true, Data = data };

        public static ApiResponse<T> Fail(int code, string message) =>
            new ApiResponse<T> { Success = false, Error = new ApiError { Code = code, Message = message } };
    }
}
