using Domain.Repository;
using IServices;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserAccountService> _lazyUserAccountService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyUserAccountService = new Lazy<IUserAccountService>(() => new UserAccountService(repositoryManager));
        }

        public IUserAccountService UserAccountService => _lazyUserAccountService.Value;

    }
}