namespace DDDValidationsDemo.Domain
{
    public class Workout : IAggregateRoot
    {
        public const int MaxNumberOfExercises = 5;
        public const int MinNumberOfExercises = 2;
        public Guid Id { get; }
        public WorkoutName Name { get; }
        private readonly List<Exercise> _excerises = new();
        public IEnumerable<Exercise> Exercises => _excerises.AsReadOnly();
        public byte[] ResourceVersion { get; private set; }

        private Workout(Guid id, WorkoutName name, IEnumerable<Exercise> exercises)
        {
            Id = id;
            Name = name;
            _excerises = exercises.ToList();
        }

        public static Workout Create(Guid id, WorkoutName name, IEnumerable<Exercise> exercises)
        {
            if (exercises.Count() > MaxNumberOfExercises)
            {
                throw new ArgumentException($"Exercises must be at most {MaxNumberOfExercises}", nameof(exercises));
            }

            if (exercises.Count() < MinNumberOfExercises)
            {
                throw new ArgumentException($"Exercises must be at least {MinNumberOfExercises}", nameof(exercises));
            }

            return new Workout(id, name, exercises);
        }
    }
}