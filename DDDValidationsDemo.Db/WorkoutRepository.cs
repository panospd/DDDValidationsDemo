using DDDValidationsDemo.App.UseCases.Workouts;
using DDDValidationsDemo.Domain;

namespace DDDValidationsDemo.Db
{
    public class WorkoutRepository : BaseRepository, IWorkOutRepository
    {
        public WorkoutRepository(DbStore dbStore) 
            : base(dbStore)
        {
        }

        public Task Save(Workout workout)
        {
            Store.Workouts.Add(workout);
            return Task.CompletedTask;
        }
    }

    public abstract class BaseReadonlyRepository<T> where T : IEntity
    {
        public IQueryable<T> Items { get; }

        public BaseReadonlyRepository(DbStore store)
        {
            Items = GetQueryable(store);
        }

        public abstract IQueryable<T> GetQueryable(DbStore store);
    }
}