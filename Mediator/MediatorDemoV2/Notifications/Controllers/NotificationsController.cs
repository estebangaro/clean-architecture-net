using Microsoft.AspNetCore.Mvc;
using Notifications.Models;
using Notifications.Models.EFCore;
using Notifications.Models.NotificationHandlers;
using Notifications.Models.Services;

namespace Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        public IActionResult SaveChanges([FromQuery] Emisor emisor)
        {
            PersistenceService Service = new PersistenceService(
                new Mediator(
                    new NotificationHandler1(),
                    new NotificationHandler2(),
                    new NotificationHandler3()));

            Service.SaveChanges(emisor);
            return Ok("Saved!!!");
        }
    }
}