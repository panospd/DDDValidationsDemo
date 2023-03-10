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

        public static Maybe<T> Problem(Dictionary<string, string[]> errors)
        {
            return new Maybe<T>(errors, ResponseCode.InvalidCommand);
        }

        public static Maybe<T> Problem(string propName, params string[] errors)
        {
            return Problem(new Dictionary<string, string[]> { { propName, errors } });
        }

        public static Maybe<T> NotFound()
        {
            return new Maybe<T>(
                new Dictionary<string, string[]>
                {
                    { "global", new string[1] { "Resource not found" } }
                },
                ResponseCode.ResourceNotFound);
        }
    }
}
