using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class InvoiceRepository : IInvoiceRespository, IDisposable
    {
        private TransportEntities context;
        public InvoiceRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Invoice> GetInvoice()
        {
            return context.Invoices.ToList();
        }
        public Invoice GetInvoiceByID(int id)
        {
            return context.Invoices.Find(id);
        }
        int IInvoiceRespository.Insert(Invoice invoice)
        {
            try
            {
                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return 1;
        }
        public int Delete(Invoice invoice)
        {
            Invoice currentInvoice = context.Invoices.Find(invoice.ID);
            context.Invoices.Remove(currentInvoice);
            return 1;
        }
        int IInvoiceRespository.Update(Invoice invoice)
        {
            context.Entry(invoice).State = EntityState.Modified;
            Save();
            return 1;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
