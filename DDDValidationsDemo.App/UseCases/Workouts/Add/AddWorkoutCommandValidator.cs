using DDDValidationsDemo.Domain;
using FluentValidation;

namespace DDDValidationsDemo.App.UseCases.Workouts.Add
{
    public sealed class AddWorkoutCommandValidator : AbstractValidator<AddWorkoutCommand>
    {
        public AddWorkoutCommandValidator()
        {
            RuleFor(w => w.Name)
                .MaximumLength(WorkoutName.MaxLength)
                .MinimumLength(WorkoutName.MinLength);

            RuleFor(w => w.Exercises)
                .Must(e => e.Count() >= Workout.MinNumberOfExercises && e.Count() <= Workout.MaxNumberOfExercises)
                .WithMessage($"Exercices must be at between {Workout.MinNumberOfExercises} and {Workout.MaxNumberOfExercises}");

            RuleForEach(w => w.Exercises)
                .MaximumLength(ExerciseName.MaxLength)
                .MinimumLength(ExerciseName.MinLength);
        }
    }
}