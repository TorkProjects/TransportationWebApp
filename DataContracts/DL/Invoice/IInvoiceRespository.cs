using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public interface IInvoiceRespository : IDisposable
    {
        IEnumerable<Invoice> GetInvoice();
        Invoice GetInvoiceByID(int id);
        int Insert(Invoice invoice);
        int Delete(Invoice invoice);
        int Update(Invoice invoice);
        void Save();
    }
}
