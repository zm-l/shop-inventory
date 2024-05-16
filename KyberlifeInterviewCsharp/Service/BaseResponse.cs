using System.Net;

namespace KyberlifeInterviewCsharp.Service;

/// <summary>
/// Standard response format for all API calls.
///
/// You should not need to modify this class, but you are allowed to if needed.
/// </summary>
public class BaseResponse<T>
{
    public required HttpStatusCode Code { get; set; }
    public required IEnumerable<string>? Errors { get; set; }
    public T? Data { get; set; }

    private BaseResponse()
    {
    }

    public static BaseResponse<T> Success(T data)
    {
        return new BaseResponse<T>
        {
            Code = HttpStatusCode.OK,
            Errors = null,
            Data = data
        };
    }

    public static BaseResponse<T> Error(HttpStatusCode code, IEnumerable<string> errors)
    {
        return new BaseResponse<T>
        {
            Code = code,
            Errors = errors,
            Data = default
        };
    }
}