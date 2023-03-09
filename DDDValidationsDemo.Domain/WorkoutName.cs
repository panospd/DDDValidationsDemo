namespace DDDValidationsDemo.Domain
{
    public class WorkoutName : IValueObject<WorkoutName>
    {
        public const int MaxLength = 200;
        public const int MinLength = 3;
        public string Value { get; }

        private WorkoutName(string value)
        {
            Value = value;
        }

        public static WorkoutName Create(string value)
        {
            EnsureValueIsValid(value);
            return new WorkoutName(value);
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

        public bool IsEquivalentTo(WorkoutName other)
        {
            return this == other || Value == other.Value;
        }
    }
}