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
    [Route("api/reportingStructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
       
        public ReportingStructureController(ILogger<ReportingStructureController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public IActionResult GetByEmployeeId(string id)
        {
            try
            {
                _logger.LogDebug($"Received reporting structure get request for employee with ID: '{id}'.");

                // get the ReportingStructure for the employee.
                var reportingStructure = _employeeService.GetReportingStructure(id);

                if (reportingStructure == null)
                    return NotFound();

                return Ok(reportingStructure);
            }
            catch (Exception e)
            {
                return new JsonResult(new { info = "Error recieving reporting structure", reason = $"{e.Message}" });
            }
        }
    }
}
