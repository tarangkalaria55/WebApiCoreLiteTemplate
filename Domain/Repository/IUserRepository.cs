using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        User? GetByUserName(string UserName);

        void Insert(User user);

        void Remove(User user);
    }
}
