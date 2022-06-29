using InvoiceApp.Entities;
using InvoiceApp.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Domain.Repositories;

namespace InvoiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Invoice, int> InvoiceRepository;
        public HomeController(IRepository<Invoice, int> InvoiceRepository)
        {
            this.InvoiceRepository = InvoiceRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            var invoice = await InvoiceRepository.GetListAsync();
            return Json(new { invoice});
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceDetailModel Invoice)
        {
            
                return Json(new
           {
               Invoice,
           });
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    
    public class Line{
        [Required]
        [Placeholder("Enter item name..")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Placeholder("Enter item Price..")]
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}
