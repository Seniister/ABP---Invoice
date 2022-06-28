using Volo.Abp.Domain.Entities;

namespace InvoiceApp.Entities
{
    public class Invoice : AggregateRoot<int>
    {
        public DateTime Date { get; protected set; }
        public string? ImgUrl { get; protected set; }
        public string? FileUrl { get; protected set; }
        public bool Refundable { get; protected set; }
        public virtual List<InvoiceItem> InvoiceItems { get; protected set; }
        public InvoiceType Type { get; protected set; }
        public enum InvoiceType
        {
            Type1,
            Type2,
            Type3,
        }


        public Invoice(DateTime dateTime, string? imgUrl, string? fileUrl, bool refundable, InvoiceType type)
        {
            Date = dateTime;
            ImgUrl = imgUrl;
            FileUrl = fileUrl;
            Refundable = refundable;
            Type = type;

            InvoiceItems = new List<InvoiceItem>();
        }


        protected Invoice()
        {

        }


        public virtual void AddItem(string name, double price)
        {
            InvoiceItems.Add(new InvoiceItem( this.Id, name, price));
        }
    }

}
