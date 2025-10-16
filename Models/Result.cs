namespace CRUD_APIs.Models;

public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Data { get; private set; }
        public List<string> Errors { get; private set; }

        private Result(bool isSuccess, T data, List<string> errors)
        {
            IsSuccess = isSuccess;
            Data = data;
            Errors = errors ?? new List<string>();
        }

        // Factory method for successful result
        public static Result<T> Success(T data) => new Result<T>(true, data, null);

        // Factory method for failed result
        public static Result<T> Failure(params string[] errors) => new Result<T>(false, default, errors.ToList());

        // Factory method for failed result with a single error
        public static Result<T> Failure(string error) => new Result<T>(false, default, new List<string> { error });
    }

    // Non-generic Result for operations that don't return data
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        private Result(bool isSuccess, List<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<string>();
        }

        public static Result Success() => new Result(true, null);
        public static Result Failure(params string[] errors) => new Result(false, errors.ToList());
        public static Result Failure(string error) => new Result(false, new List<string> { error });
    }