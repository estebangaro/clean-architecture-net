using Microsoft.AspNetCore.Mvc;
using WebApplication_Notifications_Events.Models;

namespace WebApplication_Notifications_Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            NotificationHandler_Debug notificationHandler_Debug = new NotificationHandler_Debug();
            NotificationHandler_File notificationHandler_File = new NotificationHandler_File();
            PersistenceService persistenceService = new PersistenceService();
            persistenceService.OnSave += notificationHandler_Debug.Handle;
            persistenceService.OnSave += notificationHandler_File.Handle;
            persistenceService.Save();

            return Ok("Operación ejecutando exitosamente!");
        }
    }
}
