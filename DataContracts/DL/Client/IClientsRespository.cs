using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public interface IClientsRespository : IDisposable
    {
        IEnumerable<Clients> GetClients();
        Clients GetClientByID(int ClientId);
        int Insert(Clients client);
        int Delete(Clients client);
        int Update(Clients client);
        void Save();
    }
}
