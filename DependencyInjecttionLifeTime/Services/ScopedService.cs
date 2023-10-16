using DependencyInjecttionLifeTime.Services.Interfaces;

namespace DependencyInjecttionLifeTime.Services
{
    public class ScopedService : IScopedService
    {

        private readonly AppUser _appUser;
        private readonly Guid _id;
        public ScopedService(AppUser appUser)
        {
            _id = Guid.NewGuid();
            _appUser = appUser;
        }

        public string GetId()
        {
            return $"{_id}_{_appUser.Index}";
        }
    }
}
