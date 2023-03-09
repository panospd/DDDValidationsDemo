namespace DDDValidationsDemo.App.UseCases
{
    public enum ResponseCode
    {
        Success,
        InvalidCommand,
        ResourceNotFound
    }
    public class Maybe<T>
    {
        public T? Value { get; private set; }
        public Dictionary<string, string[]> Errors { get; } = new();
        public ResponseCode Code { get; }
        public bool IsValid => !Errors.Any();

        private Maybe(T value)
        {
            Value = value;
            Code = ResponseCode.Success;
        }

        private Maybe(Dictionary<string, string[]> errors, ResponseCode code)
        {
            Errors = errors;
            Code = code;
        }

        public static Maybe<T> Success (T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> Failure(Dictionary<string, string[]> errors, ResponseCode code = ResponseCode.InvalidCommand)
        {
            return new Maybe<T>(errors, code);
        }

        public static Maybe<T> Failure(string propName, string[] errors, ResponseCode code = ResponseCode.InvalidCommand)
        {
            return Failure(new Dictionary<string, string[]> { { propName, errors } }, code);
        }
    }
}
