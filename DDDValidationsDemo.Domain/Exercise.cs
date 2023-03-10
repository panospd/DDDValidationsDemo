namespace DDDValidationsDemo.Domain
{
    public class Exercise : IEntity
    {
        public Guid Id { get; }
        public ExerciseName Name { get; private set; }

        private Exercise(Guid id, ExerciseName name)
        {
            Id = id;
            Name = name;
        }

        public static Exercise Create(Guid id, ExerciseName name)
        {
            return new Exercise(id, name);
        }

        public void Update(ExerciseName name)
        {
            Name = name;
        }
    }
}