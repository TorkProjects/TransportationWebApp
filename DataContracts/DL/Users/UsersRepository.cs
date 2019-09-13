using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.DL
{
    public class UsersRepository: IUsersRepository,IDisposable
    {
        private TransportEntities context;

        public UsersRepository(TransportEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Users> GetUsers()
        {
            return context.Users.ToList();
        }

        public Users GetUserByID(int UserID)
        {
            return context.Users.Find(UserID);
        }

        public Users GetUserNameAndPassword(string UserName, string Passwod)
        {
            return context.Users.Where(usr => usr.UserName == UserName && usr.Password == Passwod).FirstOrDefault();
        }

        int IUsersRepository.InsertUser(Users user)
        {
            context.Users.Add(user);
            return 1;
        }

        public int DeleteUser(Users user)
        {
            Users currentUser = context.Users.Find(user.ID);
            context.Users.Remove(currentUser);
            return 1;
        }

        int IUsersRepository.UpdateUser(Users user)
        {
            context.Entry(user).State = EntityState.Modified;
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
