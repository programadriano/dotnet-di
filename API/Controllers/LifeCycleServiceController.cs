using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifeCycleServiceController : ControllerBase
    {


        private readonly ILifecycleService _service;
        private readonly Lifecycle2Service _service2;

        public LifeCycleServiceController(ILifecycleService service, Lifecycle2Service service2)
        {
            _service = service;
            _service2 = service2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<DateTime>();
            result.Add(_service.DataAtual());
            result.Add(_service2.DataAtual());

            return Ok(result);
        }
    }
}
