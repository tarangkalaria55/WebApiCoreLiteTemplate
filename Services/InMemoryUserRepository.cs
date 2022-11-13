using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User>? users = null;

        public User? GetByUserName(string UserName)
        {
            if (users == null)
            {
                users = new List<User>();
                users.Add(new User { ID = Guid.NewGuid(), UserName = "test", Password = "1234" });
            }
            return users.Where(x => x.UserName == UserName).FirstOrDefault();

        }


        public void Insert(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }
    }
}
