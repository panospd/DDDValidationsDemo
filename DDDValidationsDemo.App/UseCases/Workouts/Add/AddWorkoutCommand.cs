using DDDValidationsDemo.Domain;
using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace DDDValidationsDemo.App.UseCases.Workouts.Add
{
    public sealed class AddWorkoutCommand : IRequest<Maybe<Guid>>
    {
        public string Name { get; }
        public IEnumerable<string> Exercises { get; } = Enumerable.Empty<string>();

        public AddWorkoutCommand(string name, IEnumerable<string> exercises)
        {
            Name = name;
            Exercises = exercises;
        }

        public class AddWorkoutCommandHandler : BaseCommandHandler<AddWorkoutCommand, Guid>
        {
            private readonly IWorkOutRepository _repo;

            public AddWorkoutCommandHandler(IWorkOutRepository repo, IValidator<AddWorkoutCommand> validator) 
                : base(validator)
            {
                _repo = repo;
            }

            public override async Task<Maybe<Guid>> ExecuteCommand(AddWorkoutCommand command, CancellationToken cancellation)
            {
                var workoutName = WorkoutName.Create(command.Name);
                var exercises = command.Exercises
                    .Select(e => Exercise.Create(
                        Guid.NewGuid(),
                        ExerciseName.Create(e)));

                var workout = Workout.Create(Guid.NewGuid(), workoutName, exercises);

                await _repo.Save(workout);

                return Maybe<Guid>.Success(workout.Id);
            }
        }
    }
}