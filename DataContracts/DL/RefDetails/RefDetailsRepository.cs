using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class RefDetailsRepository : IRefDetailsRespository, IDisposable
    {
        private TransportEntities context;
        public RefDetailsRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<RefDetails> GetRefDetails()
        {
            return context.RefDetails.ToList();
        }
        public RefDetails GetRefDetailsByID(int RefDetailsID)
        {
            return context.RefDetails.Find(RefDetailsID);
        }
        public List<RefDetails> GetRefDetailsByHeaderID(int headerId)
        {
            try
            {
                return context.RefDetails.Where(z => z.HeaderID == headerId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        int IRefDetailsRespository.Insert(RefDetails refDetails)
        {
            try
            {
                context.RefDetails.Add(refDetails);
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return 1;
        }
        public int Delete(RefDetails refDetails)
        {
            RefDetails currentRefDetails = context.RefDetails.Find(refDetails.HeaderID);
            context.RefDetails.Remove(currentRefDetails);
            return 1;
        }
        int IRefDetailsRespository.Update(RefDetails refDetails)
        {
            context.Entry(refDetails).State = EntityState.Modified;
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
