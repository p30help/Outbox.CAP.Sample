using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Consul;
using EventModels;

namespace Outbox.CAP.Sample.Controllers
{
    /// <summary>
    /// read more
    /// https://github.com/dotnetcore/CAP
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ICapPublisher _capBus;

        public UsersController(ILogger<UsersController> logger, ICapPublisher capBus)
        {
            _logger = logger;
            _capBus = capBus;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser()
        {
            var userEvent = new UserAddedEvent()
            {
                Id = Guid.NewGuid(),
                Username = "p30help"
            };

            await _capBus.PublishAsync("captest.user.useradded", userEvent);
            _logger.LogInformation("Message Published");

            return Ok();
        }



        [HttpGet]
        public async Task<IActionResult> ShowCounter()
        {
            return Ok(UserAddedSubscriber.Count);
        }
    }
}
