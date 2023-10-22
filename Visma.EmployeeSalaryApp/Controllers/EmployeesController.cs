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
    public ICollection<ShiftCalculated> GetEmployeeShiftsCalculated([FromRoute] int employeeId, [FromRoute] int year, [FromRoute] int month)
    {
        _employeeServiceCalculated = new CalculatedEmployeeService();
        return _employeeServiceCalculated.GetEmployeeShiftsCalculated(employeeId, year, month);
    }

    [HttpGet("{employeeId:int}/shifttotal/{year:int}-{month:int}")]
    public decimal GetEmployeeTotalCalculated([FromRoute] int employeeId, [FromRoute] int year, [FromRoute] int month)
    {
        _employeeServiceCalculated = new CalculatedEmployeeService();
        return _employeeServiceCalculated.GetEmployeeTotalHours(employeeId, year, month);
    }
}