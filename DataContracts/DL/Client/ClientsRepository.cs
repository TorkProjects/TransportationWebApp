using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class ClientsRepository : IClientsRespository, IDisposable
    {
        private TransportEntities context;
        public ClientsRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Clients> GetClients()
        {
            return context.Clients.ToList();
        }
        public Clients GetClientByID(int ClientId)
        {
            return context.Clients.Find(ClientId);
        }
        int IClientsRespository.Insert(Clients client)
        {
            try
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return 1;
        }
        public int Delete(Clients client)
        {
            Clients currentclient = context.Clients.Find(client.ClientID);
            context.Clients.Remove(currentclient);
            return 1;
        }
        int IClientsRespository.Update(Clients clients)
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
