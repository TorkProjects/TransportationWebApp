using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class ExchangeRepository : IExchangeRespository, IDisposable
    {
        
        private TransportEntities context;
        public ExchangeRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Bond> GetExchange()
        {
            return context.Bonds.ToList();
        }
        public Bond GetExchangeByID(int ID)
        {
            return context.Bonds.Find(ID);
        }
        int IExchangeRespository.Insert(Bond bond)
        {
            try
            {
                context.Bonds.Add(bond);
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return 1;
        }
        public int Delete(Bond client)
        {
            Clients currentclient = context.Clients.Find(client.ClientID);
            context.Clients.Remove(currentclient);
            return 1;
        }
        int IExchangeRespository.Update(Bond clients)
        {
            context.Entry(clients).State = EntityState.Modified;
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
