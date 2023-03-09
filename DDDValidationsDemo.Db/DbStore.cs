using DDDValidationsDemo.Domain;

namespace DDDValidationsDemo.Db
{
    public class DbStore
    {
        public List<Workout> Workouts { get; set; } = new();
    }
}