using CrudTask1.Models;
using CrudTask1.Models.Respository;
using CrudTask1.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployee empl;
        public EmployeeController(IEmployee _employee)
        {
            empl = _employee;
        }
        public IActionResult Index()
        {
            // var emp = empl.GetEmployees();
            var empr = empl.GetEmployeeViews();
            return View(empr);
        }
        public IActionResult AddDepartment()
        {
            return View();
        }
        public IActionResult Create()
        {
            var cats = empl.GetDepartments();
            ViewBag.cats = cats;
            var adds = empl.GetAddresses();
            ViewBag.adds = adds; 
            return View();
        }
        public IActionResult AddAddress()
        {
            var cts = empl.GetCities();
            var sts = empl.GetStates();
            var cyts = empl.GetCountries();
            ViewBag.cts = cts;
            ViewBag.sts = sts;
            ViewBag.cyts = cyts;
            return View();
        }
    [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            empl.PostEmployee(employee);
            return RedirectToAction("Index");
        } 
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            empl.PostDepartment(department);
            return RedirectToAction("Index");
        } 
        [HttpPost]
        public IActionResult AddAddress(AddressViewModel address)
        {
            empl.PostAddress(address);
            return RedirectToAction("Index");
        }
    
         public IActionResult Delete(int id)
        {
            empl.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    
        public  IActionResult Update(int id)
        {
           return View( empl.GetEmployeeById(id));

        }
    
        [HttpPost]

        public IActionResult Update(Employee employee)
        {
            empl.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        
            public IActionResult ShowEmployee()
        {
            return View();
        }
        public IActionResult ShowEmployeeByDepartment()
        {
            var dpt = empl.GetDepartments();
            return View(dpt);
        }
        public IActionResult ShowDepartment(int id)
        {
            var emp = empl.GetEmployeesByDepartment(id);
            return View(emp);
        }
        public IActionResult ShowEmployeeByCountry()
        {
            var cnt = empl.GetCountries();
            return View(cnt);
        } 
        public IActionResult ShowEmpByStates()
        {
            var st = empl.GetStates();
            return View(st);
        } 
        public IActionResult ShowEmpByCity()
        {
            var ct = empl.GetCities();
            return View(ct);
        }
        public IActionResult ShowEmp(int id)
        {
            var empc = empl.GetEmployeesByCity(id);
            return View(empc);
        }
    }

}
