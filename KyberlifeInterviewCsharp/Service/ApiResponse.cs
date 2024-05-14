using System.Net;

namespace KyberlifeInterviewCsharp.Service;

/// <summary>
/// Standard response format for all API calls.
///
/// You should not need to modify this class.
/// </summary>
public class ApiResponse<T>
{
    public required HttpStatusCode Code { get; set; }
    public required IEnumerable<string>? Errors { get; set; }
    public T? Data { get; set; }

    private ApiResponse()
    {
    }

    public static ApiResponse<T> Success(T data)
    {
        return new ApiResponse<T>
        {
            Code = HttpStatusCode.OK,
            Errors = null,
            Data = data
        };
    }

    public static ApiResponse<T> Error(HttpStatusCode code, IEnumerable<string> errors)
    {
        return new ApiResponse<T>
        {
            Code = code,
            Errors = errors,
            Data = default
        };
    }
}