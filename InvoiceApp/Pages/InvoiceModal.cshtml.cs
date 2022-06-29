using InvoiceApp.Controllers;
using InvoiceApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using static InvoiceApp.Entities.Invoice;
using  InvoiceApp.Entities;

namespace InvoiceApp.Pages
{
    public class InvoiceModalModel : AbpPageModel
    {
        public InvoiceAppDbContext Db { get; set; }
        public InvoiceModalModel(InvoiceAppDbContext db)
        {
            Db = db;
        }
        [BindProperty]
        public InvoiceDetailModel Invoice { get; set; }
        [BindProperty]
        public Line[] Line { get; set; }
        public IActionResult OnGet()
        {
            Invoice = new InvoiceDetailModel
            {
                Date = DateTime.Now,
                Refundable = true,
                Type = InvoiceType.Type3,
            };
            Line = new Line[] { new Line { Name = "Mouse", Price = 10 }, new Line { Name = "Keyboard", Price = 20 } };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var Invoices = new Invoice(Invoice.Date, "", "", Invoice.Refundable, Invoice.Type);
            foreach (var item in Invoice.Line)
            {
                Invoices.AddItem(item.Name, item.Price);
            }
           
            await Db.AddAsync(Invoices);
            await Db.SaveChangesAsync(); 
            return  RedirectToPage("/Index");

        }
    }
    public class InvoiceDetailModel
    {

        public DateTime Date { get; set; }

        public bool Refundable { get; set; }
        public InvoiceType Type { get; set; }
        [DynamicFormIgnore]
        public List<Line> Line { get; set; }

    }
}
