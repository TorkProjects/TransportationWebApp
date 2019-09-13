using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
   public interface IUsersRepository :IDisposable
    {
        IEnumerable<Users> GetUsers();
        Users GetUserByID(int UserID);
        Users GetUserNameAndPassword(string UserName, string Passwod);

        int InsertUser(Users user);
        int DeleteUser(Users user);
        int UpdateUser(Users user);
        void Save();

    }
}
