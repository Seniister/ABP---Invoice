using InvoiceApp.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Net.Http.Json;

namespace InvoiceApp.Services
{
    public class InvoiceServices : ApplicationService
    {
        private readonly IRepository<Invoice> InvoiceRepository;
        public InvoiceServices(IRepository<Invoice, int> invoiceRepository)
        {
            InvoiceRepository = invoiceRepository;
        }

        public async Task<List<Invoice>> GetListAsnyc()
        {
            var invoice = await InvoiceRepository.GetListAsync();
            return invoice;
        }

    }
}
