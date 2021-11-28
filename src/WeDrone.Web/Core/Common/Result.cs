namespace WeDrone.Web.Core.Common
{
    public class Result<T>
    {
        public T Payload { get; }
        public string FailureReason { get; }
        public bool IsSuccess => String.IsNullOrEmpty(FailureReason);

        private Result(string reason)
        {
            FailureReason = reason;
        }
        private Result(T payload)
        {
            Payload = payload;
        }

        public static Result<T> Fail(string reason)
        {
            return new Result<T>(reason);
        }
        public static Result<T> Success(T payload)
        {
            return new Result<T>(payload);
        }
        public static implicit operator bool(Result<T> result)
        {
            return result.IsSuccess;
        }


    }
}
