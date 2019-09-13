using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class EmployeesRepository: IEmployeesRespository, IDisposable
    {
        private TransportEntities context;
        public EmployeesRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Employee> GetEmployee()
        {


            return context.Employees.ToList();
        }
        public Employee GetEmployeeByID(int EmployeeID)
        {
            return context.Employees.Find(EmployeeID);
        }
        int IEmployeesRespository.Insert(Employee employee)
        {
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return 1;
        }
        public int Delete(Employee employee)
        {
            Employee currentemployee = context.Employees.Find(employee.EmployeeId);
            context.Employees.Remove(currentemployee);
            return 1;
        }
        int IEmployeesRespository.Update(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
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
