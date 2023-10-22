using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visma.EmployeeSalaryApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visma.EmployeeSalaryApp.Models;

namespace Visma.EmployeeSalaryApp.Services.Tests
{
    [TestClass()]
    public class CalculatedEmployeeServiceTests
    {
        [TestMethod()]
        public void GetEmployeeShiftsCalculatedTest()
        {
            var _employeeServiceCalculated = new CalculatedEmployeeService();

            Assert.AreEqual((decimal) 60.0, _employeeServiceCalculated.GetEmployeeShiftsCalculated(1, 2023, 8).FirstOrDefault().calculated);
        }
        [TestMethod()]
        public void GetEmployeeTotalHoursTest()
        {
            var _employeeServiceCalculated = new CalculatedEmployeeService();

            Assert.AreEqual((decimal)1492.39, _employeeServiceCalculated.GetEmployeeTotalHours(1, 2023, 8));
        }
    }
}