using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
   public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Custmers> GetCustomers();
        Custmers GetCustomerByID(int UserID);
        int InsertCustomer(Custmers customer);
        int DeleteCustomer(Custmers customer);
        int UpdateCustomer(Custmers customer);
        void Save();

    }
}
