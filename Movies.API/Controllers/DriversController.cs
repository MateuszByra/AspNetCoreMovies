using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.Commands;

namespace Movies.API.Controllers
{
    //[Produces("application/json")]
    [Route("api/Drivers")]
    public class DriversController : Controller//ApiControllerBase
    {
        //private readonly ICommandDispatcher _commandDispatcher;

        //public DriversController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        //{
        //    _commandDispatcher = commandDispatcher;
        //}

        /*[HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            //var driver = await _driverService.GetAsync(userId);
            //if (driver == null)
            //{
            //    return NotFound();
            //}

            var driver = "Jesteśmy w Api";
            return Json(driver);
        }
        */
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok("jest w api");
        }

        //[HttpPost]
        //public IActionResult Create(string item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }

            

        //    return new ObjectResult("jest w api");
        //}
    }
}