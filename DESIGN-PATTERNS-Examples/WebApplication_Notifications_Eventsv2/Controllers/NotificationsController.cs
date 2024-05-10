using Microsoft.AspNetCore.Mvc;
using WebApplication_Notifications_Events.Models;

namespace WebApplication_Notifications_Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        IMediator _mediator;
        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            PersistenceService persistenceService = new PersistenceService(_mediator);
            persistenceService.Save();

            return Ok("Operación ejecutada exitosamente!");
        }
    }
}
