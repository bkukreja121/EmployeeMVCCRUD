using demoemployee.Models;
using demoemployee.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoemployee.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            List<Employee> employees = evm.GetAllEmployees();
            return View(employees);
        }

        public IActionResult EmployeeInfo(int id=0)
         {
            Employee employee = new Employee();

            if (id == 0)
            {
                employee.Id = 0;
            }
            else
            {
                EmployeeViewModel evm = new EmployeeViewModel();
                employee=evm.GetEmployeeByEmployeeId(id);
            }
           
            return View(employee);
        }

        [HttpPost]
        public IActionResult EmployeeInfo(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel evm = new EmployeeViewModel();

                if (employee.Id == 0)
                {
                    evm.AddEmployee(employee);
                }
                else
                {
                    evm.UpdateEmployee(employee);
                }
               

                return RedirectToAction("Index", "Site");
            }
            return View();
        }

        public IActionResult DeleteEmployee(int Id=0)
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.DeleteEmployee(Id);

            return RedirectToAction("Index", "Site");
        }
    }
}
