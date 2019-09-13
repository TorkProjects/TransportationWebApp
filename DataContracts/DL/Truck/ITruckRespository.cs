using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public interface ITruckRespository : IDisposable
    {
        IEnumerable<Truck> GetTruck();
        Truck GetTruckByID(int truckID);
        int Insert(Truck truck);
        int Delete(Truck truck);
        int Update(Truck truck);
        void Save();
    }
}
