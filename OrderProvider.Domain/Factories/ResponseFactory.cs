using OrderProvider.Domain.Models;

namespace OrderProvider.Domain.Factories;

public class ResponseFactory<T> : ResponseFactory
{
    public static ResponseResultWithData<T> Success(T data, int statusCode = 200, string? message = null!)
    {
        return new ResponseResultWithData<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseResultWithData<T> NotFound(T data, int statusCode = 404, string? message = null!)
    {
        return new ResponseResultWithData<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseResultWithData<T> Failed(T data, int statusCode = 400, string? message = null!)
    {
        return new ResponseResultWithData<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseResultWithData<T> AlreadyExists(T data, int statusCode = 409, string? message = null!)
    {
        return new ResponseResultWithData<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }
}


public class ResponseFactory : BaseResponseFactory
{

}