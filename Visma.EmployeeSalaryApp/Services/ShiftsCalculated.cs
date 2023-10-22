using Visma.EmployeeSalaryApp.Models;

namespace Visma.EmployeeSalaryApp.Services
{
    public class ShiftCalculated
    {
        public EmployeeShift Shift { get; set; }
        public decimal calculated { get; set; }

        public ShiftCalculated(EmployeeShift shift, decimal rate)
        {
            Shift = shift;
            calculated = rate;
        }
    }

}
