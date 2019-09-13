using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class TruckRepository : ITruckRespository, IDisposable
    {
        private TransportEntities context;
        public TruckRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Truck> GetTruck()
        {
            return context.Trucks.ToList();
        }
        public Truck GetTruckByID(int truckID)
        {
            return context.Trucks.Find(truckID);
        }
        int ITruckRespository.Insert(Truck truck)
        {
            try
            {
                context.Trucks.Add(truck);
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return 1;
        }
        public int Delete(Truck truck)
        {
            Truck currentTruck = context.Trucks.Find(truck.ID);
            context.Trucks.Remove(currentTruck);
            return 1;
        }
        int ITruckRespository.Update(Truck truck)
        {
            context.Entry(truck).State = EntityState.Modified;
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
