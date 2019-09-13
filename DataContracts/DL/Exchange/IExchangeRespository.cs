using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public interface IExchangeRespository : IDisposable
    {
        IEnumerable<Bond> GetExchange();
        Bond GetExchangeByID(int exchangeId);
        int Insert(Bond exchange);
        int Delete(Bond exchange);
        int Update(Bond exchange);
        void Save();
    }
}
