using DDDValidationsDemo.Domain;
using FluentValidation;
using MediatR;

namespace DDDValidationsDemo.App.UseCases.Workouts.Update
{
    public sealed class UpdateExerciseForWorkoutCommand : IRequest<Maybe<Guid>>
    {
        public Guid Id { get; }
        public Guid ExerciseId { get; set; }
        public string Name { get; }

        public UpdateExerciseForWorkoutCommand(Guid id, Guid exerciseId, string name)
        {
            Id = id;
            Name = name;
            ExerciseId = exerciseId;
        }

        public class UpdateExerciseForWorkoutCommandHandler : BaseCommandHandler<UpdateExerciseForWorkoutCommand, Guid>
        {
            private readonly IWorkOutRepository _repo;

            public UpdateExerciseForWorkoutCommandHandler(IWorkOutRepository repo, IValidator<UpdateExerciseForWorkoutCommand> validator) 
                : base(validator)
            {
                _repo = repo;
            }

            public override async Task<Maybe<Guid>> ExecuteCommand(UpdateExerciseForWorkoutCommand command, CancellationToken cancellation)
            {
                var workout = await _repo.GetById(command.Id);

                if (workout is null)
                {
                    return Maybe<Guid>.NotFound();
                }

                if (workout.HasExercise(command.ExerciseId))
                {
                    return Maybe<Guid>.Problem("Exercise", "Exercise not found");
                }

                workout.UpdateExercise(command.ExerciseId, ExerciseName.Create(command.Name));

                await _repo.Save(workout);

                return Maybe<Guid>.Success(workout.Id);
            }
        }
    }
}