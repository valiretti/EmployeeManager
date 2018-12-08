using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.BLL.Interfaces;
using EmployeeManager.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;

        public EmployeeController(IEmployeeService employeeService, ICompanyService companyService)
        {
            _employeeService = employeeService;
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            var employees = _employeeService.GetAll();
            return View(employees);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            FillComboBoxes();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeService.Get(id);
            FillComboBoxes();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            _employeeService.Delete(employee.Id);
            return RedirectToAction("Index");
        }

        private void FillComboBoxes()
        {
            SelectList companies = new SelectList(_companyService.GetAll(), "Id", "Name");
            ViewBag.Companies = companies;
            SelectList positions = new SelectList(new[] { "Developer", "QA", "BA", "Manager" });
            ViewBag.Positions = positions;
        }
    }
}