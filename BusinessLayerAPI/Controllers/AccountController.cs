using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DataContracts;
using DataContracts.DL;

namespace BusinessLayerAPI.Controllers
{
    public class AccountController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private IUsersRepository userRepository;
        public AccountController()
        {
            this.userRepository = new UsersRepository(new TransportEntities());
        }


        [Route("GetUserDetails")]
        [HttpPost]
        public Users GetUserDetails(string userName,string password )
        {
            return userRepository.GetUserNameAndPassword(userName, password);

            //genral repositry
            return  (Users)unitOfWork.UsersRepository.Get(includeProperties: "Department");
        }



    }
}