using EmployeeManager.BLL.Interfaces;
using EmployeeManager.Entities;
using EmployeeManager.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            var companies = _companyService.GetAll();
            return View(companies);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _companyService.Add(company);
                    return RedirectToAction("Index");
                }
                catch (UniquenessViolationException ex)
                {
                    ModelState.AddModelError(nameof(company.Name), ex.Message);
                }
            }

            return View(company);

        }

        public ActionResult Edit(int id)
        {
            var company = _companyService.Get(id);
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _companyService.Update(company);
                    return RedirectToAction("Index");
                }
                catch (UniquenessViolationException ex)
                {
                    ModelState.AddModelError(nameof(company.Name), ex.Message);
                }
            }

            return View(company);
        }

        public ActionResult Delete(int id)
        {
            var company = _companyService.Get(id);
            if (company != null)
            {
                return View(company);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Company company)
        {
            try
            {
                _companyService.Delete(company.Id);
                return RedirectToAction("Index");
            }
            catch (RelatedEntitiesExistException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(_companyService.Get(company.Id));
            }
        }
    }
}