using DDDValidationsDemo.App.UseCases;
using DDDValidationsDemo.App.UseCases.Workouts.Add;
using DDDValidationsDemo.App.UseCases.Workouts.Update;
using DDDValidationsDemo.Db;
using DDDValidationsDemo.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDDValidationsDemo.API.Controllers
{
    public class WorkoutController : ApiBaseController
    {
        private readonly IMediator _mediator;
        private readonly DbStore _store;

        public WorkoutController(IMediator mediator, DbStore store)
        {
            _mediator = mediator;
            _store = store;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddWorkoutCommand command)
        {
            return Respond(await _mediator.Send(command));
        }

        [HttpPut("exercises")]
        public async Task<IActionResult> Put(UpdateExerciseForWorkoutCommand command)
        {
            return Respond(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Respond(Maybe<IEnumerable<Workout>>.Success(_store.Workouts));
        }
    }
}