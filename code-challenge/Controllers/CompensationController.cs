using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    /// This controller's Action Methods are called for any requests received regarding an employee's compensation.
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        /// This action method is called to get Compensation for an particular employee
        [HttpGet("employee/{id}")]
        public IActionResult GetCompensationByEmployeeId(string id)
        {
            try
            {
                _logger.LogDebug($"Received compensation get request for employee with ID: '{id}'");

                var compensation = _compensationService.GetByEmployeeId(id);

                if (compensation == null || compensation.Count == 0)
                {
                    return NotFound();
                }

                return Ok(compensation);
            }
            catch (Exception e)
            {
                return new JsonResult(new { info = "Error getting Compensation", reason = $"{e.Message}" });
            }
        }

        /// The POST Action Method is to create a new Compensation for an Employee.
        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            try
            {
                _logger.LogDebug($"Received compensation create request for '{compensation.employee.FirstName} {compensation.employee.LastName}'");

                _compensationService.Create(compensation);

                return CreatedAtRoute(new { id = compensation.employee.EmployeeId }, compensation);
            }
            catch (Exception e)
            {
                return new JsonResult(new { info = "Error while creating new Compensation", reason = $"{e.Message}" });
            }
        }
    }
}
