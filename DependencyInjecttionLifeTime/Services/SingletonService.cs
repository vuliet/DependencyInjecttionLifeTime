using DependencyInjecttionLifeTime.Services.Interfaces;

namespace DependencyInjecttionLifeTime.Services
{
    public class SingletonService : ISingletonService
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly Guid _id;
        public SingletonService(IServiceProvider serviceProvider)
        {
            _id = Guid.NewGuid();
            _serviceProvider = serviceProvider;
        }

        public string GetId()
        {
            // sai neu khong dung scope (khong the resolve scoped lifetime vao singleton service)
            using var scope = _serviceProvider.CreateScope();
            var appUser = scope.ServiceProvider.GetRequiredService<AppUser>();

            return $"{_id}_{appUser.Index}";
        }
    }
}
