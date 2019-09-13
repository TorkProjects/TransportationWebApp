using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public interface IEmployeesRespository : IDisposable
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeByID(int EmployeeID);
        int Insert(Employee employee);
        int Delete(Employee employee);
        int Update(Employee employee);
        void Save();
    }
}
