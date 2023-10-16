using DependencyInjecttionLifeTime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjecttionLifeTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        private readonly string _transientServiceId1;
        private readonly string _transientServiceId2;
        private readonly string _scopedServiceId1;
        private readonly string _scopedServiceId2;
        private readonly string _singletonServiceId1;
        private readonly string _singletonServiceId2;

        public SomeController(
            ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;

            _transientServiceId1 = _transientService1.GetId();
            _transientServiceId2 = _transientService2.GetId();

            _scopedServiceId1 = _scopedService1.GetId();
            _scopedServiceId2 = _scopedService2.GetId();

            _singletonServiceId1 = _singletonService1.GetId();
            _singletonServiceId2 = _singletonService2.GetId();
        }

        [HttpGet]
        public IActionResult GetSomeId()
        {
            return Ok(new
            {
                _transientServiceId1,
                _transientServiceId2,
                _scopedServiceId1,
                _scopedServiceId2,
                _singletonServiceId1,
                _singletonServiceId2
            });
        }
    }
}
