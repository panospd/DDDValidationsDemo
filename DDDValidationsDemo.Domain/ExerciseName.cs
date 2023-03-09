namespace DDDValidationsDemo.Domain
{
    public class ExerciseName
    {
        public const int MaxLength = 200;
        public const int MinLength = 3;

        public string Value { get; }

        private ExerciseName(string value)        {
            Value = value;
        }

        public static ExerciseName Create(string value)
        {
            EnsureValueIsValid(value);
            return new ExerciseName(value);
        }

        private static void EnsureValueIsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Empty or null value", nameof(value));
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"Parameter must have a max length of {MaxLength}", nameof(value));
            }

            if (value.Length < MinLength)
            {
                throw new ArgumentException($"Parameter must have a min length of {MinLength}", nameof(value));
            }
        }
    }
}