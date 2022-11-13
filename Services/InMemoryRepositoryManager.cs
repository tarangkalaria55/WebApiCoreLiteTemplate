using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class InMemoryRepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        public InMemoryRepositoryManager()
        {
            _lazyUserRepository = new Lazy<IUserRepository>(() => new InMemoryUserRepository());

        }
        public IUserRepository UserRepository => _lazyUserRepository.Value;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
    }
}
