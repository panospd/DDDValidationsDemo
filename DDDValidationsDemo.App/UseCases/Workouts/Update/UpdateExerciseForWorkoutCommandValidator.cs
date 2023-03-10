using DDDValidationsDemo.Domain;
using FluentValidation;

namespace DDDValidationsDemo.App.UseCases.Workouts.Update
{
    public sealed class UpdateExerciseForWorkoutCommandValidator : AbstractValidator<UpdateExerciseForWorkoutCommand>
    {
        public UpdateExerciseForWorkoutCommandValidator()
        {
            RuleFor(w => w.Name)
                .MaximumLength(WorkoutName.MaxLength)
                .MinimumLength(WorkoutName.MinLength);

            RuleFor(w => w.Id).NotEmpty();
            RuleFor(w => w.ExerciseId).NotEmpty();
        }
    }
}