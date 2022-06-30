using Volo.Abp.Domain.Entities;

namespace InvoiceApp.Entities
{
    public class InvoiceItem : Entity<int>
    {
        public virtual string Name { get; private set; }
        public virtual double Price { get; private set; }
        public virtual int InoviceId { get;  set; }

        internal InvoiceItem(int inoviceId, string name, double price) 
        {

            InoviceId = inoviceId;
            Name = name;
            Price = price;
        }
        public InvoiceItem()
        {

        }

        public override object[] GetKeys()
        {
            return new Object[] { InoviceId };
        }

    }
}
