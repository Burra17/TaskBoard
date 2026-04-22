namespace TaskBoard.Domain.Common;

// Generic result wrapper for operation outcomes — replaces exception-based error handling
public interface IResult
{
    bool IsSuccess { get; }
    bool IsError { get; }
    string? Error { get; }
    int StatusCode { get; }
}

public class Result<T> : IResult
{
    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;

    public T? Value { get; }
    public string? Error { get; }
    public int StatusCode { get; }

    private Result(bool isSuccess, T? value, string? error, int statusCode)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
        StatusCode = statusCode;
    }

    public static Result<T> Ok(T value)
    {
        return new Result<T>(true, value, null, 200);
    }

    public static Result<T> Fail(string error, int statusCode = 400)
    {
        return new Result<T>(false, default, error, statusCode);
    }

    public static Result<T> Created(T value)
    {
        return new Result<T>(true, value, null, 201);
    }

    public static Result<T> NoContent()
    {
        return new Result<T>(true, default, null, 204);
    }
}
