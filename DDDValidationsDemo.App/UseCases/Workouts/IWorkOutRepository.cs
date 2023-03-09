using DDDValidationsDemo.Domain;

namespace DDDValidationsDemo.App.UseCases.Workouts
{
    public interface IWorkOutRepository
    {
        Task Save(Workout workout);
    }
}