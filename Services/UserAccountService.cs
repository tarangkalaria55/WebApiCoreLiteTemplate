using Domain.Repository;
using DTO;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IRepositoryManager _repositoryManager;
        public UserAccountService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public bool IsAuthenticated(Userdto user)
        {
            var dbuser = _repositoryManager.UserRepository.GetByUserName(user.UserName);
            if (dbuser == null)
            {
                return false;
            }
            if (dbuser.Password != user.Password)
            {
                return false;
            }

            return true;
        }

    }
}
