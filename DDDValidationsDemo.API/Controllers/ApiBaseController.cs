using DDDValidationsDemo.App.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DDDValidationsDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiBaseController : ControllerBase
    {
        protected IActionResult Respond<T>(Maybe<T> maybe)
        {
            if (maybe.IsValid)
            {
                return Ok(maybe.Value);
            }

            switch (maybe.Code)
            {
                case ResponseCode.ResourceNotFound:
                    return NotFound(maybe.Errors);
                default:
                    return BadRequest(maybe.Errors);
            }
        }
    }
}