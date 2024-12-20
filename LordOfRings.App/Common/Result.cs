namespace LordOfRings.App.Common;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Error { get; set; }

    public Result(){}
    private Result(bool isSuccess, T data, string error)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
    }

    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(string error) => new(false, default, error);
}