using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class CustomerRepository: ICustomerRepository, IDisposable
    {
        private TransportEntities context;

        public CustomerRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Custmers> GetCustomers()
        {
            return context.Custmers.ToList();
        }

        public int InsertCustomer(Custmers customer)
        {
            context.Custmers.Add(customer);
            return 1;
        }

        public int DeleteCustomer(Custmers customer)
        {
            Custmers currentCustomer = context.Custmers.Find(customer.Id);
            context.Custmers.Remove(currentCustomer);
            return 1;

        }

        public int UpdateCustomer(Custmers customer)
        {
            context.Entry(customer).State = EntityState.Modified;
            return 1;
        }



        public Custmers GetCustomerByID(int CustomerID)
        {
            return context.Custmers.Find(CustomerID);
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
