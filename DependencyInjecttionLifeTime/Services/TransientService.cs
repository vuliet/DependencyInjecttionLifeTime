using DependencyInjecttionLifeTime.Services.Interfaces;

namespace DependencyInjecttionLifeTime.Services
{
    public class TransientService : ITransientService
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly AppUser _appUser;
        private readonly Guid _id;
        public TransientService(IServiceProvider serviceProvider, AppUser appUser)
        {
            _id = Guid.NewGuid();
            _serviceProvider = serviceProvider;
            _appUser = appUser;
        }

        public string GetId()
        {
            //using var scope = _serviceProvider.CreateScope();
            //var appUser = scope.ServiceProvider.GetRequiredService<AppUser>();

            return $"{_id}_{_appUser.Index}";
        }
    }
}
