using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace InvoiceApp.Entities
{
    public class Invoice : AggregateRoot<int>
    {
        public DateTime Date { get;  set; }
        public string? ImgUrl { get;  set; }
        public string? FileUrl { get;  set; }
        public bool Refundable { get;  set; }
        public virtual List<InvoiceItem> InvoiceItems { get;  set; }
        public InvoiceType Type { get;  set; }
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
        public virtual void UpdateItem(InvoiceItem oldItem,string name,double price)
        {
            InvoiceItems.ReplaceOne(oldItem, new InvoiceItem(name, price));
        }
    }

}
