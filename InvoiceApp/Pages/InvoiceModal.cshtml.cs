using InvoiceApp.Controllers;
using InvoiceApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using static InvoiceApp.Entities.Invoice;
using  InvoiceApp.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;

namespace InvoiceApp.Pages
{
    public class InvoiceModalModel : AbpPageModel
    {
        public InvoiceAppDbContext Db { get; set; }
        public IRepository<Invoice, int> InvoiceRep;
        public InvoiceModalModel(InvoiceAppDbContext db, IRepository<Invoice, int> invoiceRep)
        {
            Db = db;
            InvoiceRep = invoiceRep;
        }
        [BindProperty]
        public InvoiceDetailModel Invoice { get; set; }
        [BindProperty]
        public Line[] Line { get; set; }
        public bool update = false;
        public async Task<IActionResult> OnGet(int? invoiceId)
        {
            if (invoiceId != null)
            {

                try
                {
                    var queryable = await InvoiceRep.WithDetailsAsync(x => x.InvoiceItems);
                    var query = queryable.Where(x => x.Id == invoiceId);
                    var oldInvoice = query.FirstOrDefault(i => i.Id == invoiceId);

                    if (oldInvoice != null)
                    {
                        Invoice = new InvoiceDetailModel
                        {
                            Date = oldInvoice.Date,
                            Refundable = oldInvoice.Refundable,
                            Type = oldInvoice.Type,
                        };

                        var oldItems = oldInvoice.InvoiceItems;
                        Line = new Line[oldItems.Count] ;
                        var i = 0;
                        foreach (var item in oldItems)
                        {
                            Line[i] = new Line { Name = item.Name, Price = item.Price };
                            i++;
                        }
                        return Page();
                    }
                    
                }
                catch (Exception e)
                {
                    throw;
                }
                    
                

            }
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
           

            var Invoices = new Invoice(Invoice.Date, "", "", Invoice.Refundable, Invoice.Type);
            foreach (var item in Invoice.Line)
            {
                Invoices.AddItem(item.Name, item.Price);
            }
            if (Invoice.Id != null)
            {
                await InvoiceRep.UpdateAsync(Invoices);
                await Db.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            await Db.AddAsync(Invoices);
            await Db.SaveChangesAsync(); 
            return  RedirectToPage("/Index");

        }
    }
    public class InvoiceDetailModel
    {
        [DynamicFormIgnore]
        public int? Id { get; set; }
        public DateTime Date { get; set; }

        public bool Refundable { get; set; }
        public InvoiceType Type { get; set; }
        [DynamicFormIgnore]
        public List<Line> Line { get; set; }

    }
}
