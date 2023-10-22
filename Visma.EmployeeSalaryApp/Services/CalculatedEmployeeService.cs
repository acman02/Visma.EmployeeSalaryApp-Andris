using System.Collections.Generic;
using System.Collections.ObjectModel;
using Visma.EmployeeSalaryApp.Interfaces;
using Visma.EmployeeSalaryApp.Models;

namespace Visma.EmployeeSalaryApp.Services;


public class CalculatedEmployeeService : EmployeeService
{

    public ICollection<ShiftCalculated> GetEmployeeShiftsCalculated(int employeeId, int year, int month)
    {
        var calculatedshifts = new List<ShiftCalculated>();
        ICollection<EmployeeShift> shifts = GetEmployeeShifts(employeeId, year, month).ToList();    
        foreach (EmployeeShift shift in shifts)
        {
            TimeSpan duration = shift.ShiftEnd - shift.ShiftStart;
            calculatedshifts.Add(new ShiftCalculated(shift, Math.Round((decimal)duration.TotalHours * GetEmployeeRate(employeeId), 2)));
        }
        return calculatedshifts;
    }

    public decimal GetEmployeeTotalHours(int employeeId, int year, int month)
    {
        return (decimal)GetEmployeeShiftsCalculated(employeeId, year, month).Sum(shift => shift.calculated);
    }
 
}