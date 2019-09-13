using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public interface IRefDetailsRespository : IDisposable
    {
        IEnumerable<RefDetails> GetRefDetails();
        RefDetails GetRefDetailsByID(int refDetailsID);
        List<RefDetails> GetRefDetailsByHeaderID(int headerId);
               int Insert(RefDetails refDetails);
        int Delete(RefDetails refDetails);
        int Update(RefDetails refDetails);
        void Save();
    }
}
