using DependencyInjecttionLifeTime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjecttionLifeTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public SomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult GetSomeId()
        {
            using var scope = _serviceProvider.CreateScope();

            var singletonService1 = scope.ServiceProvider.GetRequiredService<ISingletonService>();
            var singletonService2 = scope.ServiceProvider.GetRequiredService<ISingletonService>();
            var scopedService1 = scope.ServiceProvider.GetRequiredService<IScopedService>();
            var scopedService2 = scope.ServiceProvider.GetRequiredService<IScopedService>();
            var transientService1 = scope.ServiceProvider.GetRequiredService<ITransientService>();
            var transientService2 = scope.ServiceProvider.GetRequiredService<ITransientService>();

            var result = new
            {
                singletonServiceGetId1 = singletonService1.GetId(),
                singletonServiceGetId2 = singletonService2.GetId(),
                scopedServiceGetId1 = scopedService1.GetId(),
                scopedServiceGetId2 = scopedService2.GetId(),
                transientServiceGetId1 = transientService1.GetId(),
                transientServiceGetId2 = transientService2.GetId(),
            };

            return Ok(result);
        }
    }
}
