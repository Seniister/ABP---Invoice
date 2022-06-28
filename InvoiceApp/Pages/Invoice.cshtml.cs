using InvoiceApp.Controllers;
using InvoiceApp.Data;
using InvoiceApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using static InvoiceApp.Entities.Invoice;

namespace InvoiceApp.Pages
{
    public class InvoiceModel : PageModel
    {
        private readonly InvoiceAppDbContext _context;

        public InvoiceModel(InvoiceAppDbContext context)
        {
            _context = context;

        }

        [BindProperty]
        public InvoiceDetailModel InvoiceDModel { get; set; }
        public IActionResult OnGet()
        {
            InvoiceDModel = new InvoiceDetailModel();      
            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            /* Invoice.AddItem(InvoiceItems.Name, InvoiceItems.Price*/
            
           /* var Invoice = new Invoice(InvoiceDModel.Date, "", "", InvoiceDModel.Refundable, InvoiceDModel.Type);
                        Invoice.AddItem(InvoiceDModel.Name, InvoiceDModel.Price);*/
                        /*_context.Invoice.Add(Invoice);
            
            await _context.SaveChangesAsync();*/

            return RedirectToPage("./Index");
        }
        public class InvoiceDetailModel
        {
           
            public DateTime Date { get; set; }

            public bool Refundable { get; set; }
            public InvoiceType Type { get; set; }

            public List<Line> Line { get; set; }

        }
    }
   
}
