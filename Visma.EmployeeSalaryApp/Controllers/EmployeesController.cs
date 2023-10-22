using Microsoft.AspNetCore.Mvc;
using Visma.EmployeeSalaryApp.Interfaces;
using Visma.EmployeeSalaryApp.Models;
using Visma.EmployeeSalaryApp.Services;

namespace Visma.EmployeeSalaryApp.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private CalculatedEmployeeService _employeeServiceCalculated;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{employeeId:int}/shifts/{year:int}-{month:int}")]
    public ICollection<EmployeeShift> GetEmployeeShifts([FromRoute] int employeeId, [FromRoute] int year, [FromRoute] int month)
    {
         return _employeeService.GetEmployeeShifts(employeeId, year, month);
    }
    
    [HttpGet("{employeeId:int}/salary-rate")]
    public decimal GetEmployeeSalaryRate([FromRoute] int employeeId)
    {
        return _employeeService.GetEmployeeRate(employeeId);
    }


    [HttpGet("{employeeId:int}/shiftscalculated/{year:int}-{month:int}")]
    public IActionResult GetEmployeeShiftsCalculated([FromRoute] int employeeId, [FromRoute] int year, [FromRoute] int month)
    {
        try
        {
            if (year < 1900 || year > DateTime.UtcNow.Year || month < 1 || month > 12)
            {
                return BadRequest("Invalid date parameters.");
            }
            DateTime inputDate = new DateTime(year, month, 1);
            if (inputDate >= new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1))
            {
                return BadRequest("Date must be in the past.");
            }
            _employeeServiceCalculated = new CalculatedEmployeeService();
            return Ok(_employeeServiceCalculated.GetEmployeeShiftsCalculated(employeeId, year, month));
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("{employeeId:int}/shifttotal/{year:int}-{month:int}")]

    public IActionResult GetEmployeeTotalCalculated([FromRoute] int employeeId, [FromRoute] int year, [FromRoute] int month)
    {
        try
        {
            if (year < 1900 || year > DateTime.UtcNow.Year || month < 1 || month > 12)
            {
                return BadRequest("Invalid date parameters.");
            }
            DateTime inputDate = new DateTime(year, month, 1);
            if (inputDate >= new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1))
            {
                return BadRequest("Date must be in the past.");
            }
            _employeeServiceCalculated = new CalculatedEmployeeService();          
            return Ok(_employeeServiceCalculated.GetEmployeeTotalHours(employeeId, year, month));
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}