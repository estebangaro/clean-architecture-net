﻿using Microsoft.AspNetCore.Mvc;
using Notifications.Models.EFCore;
using Notifications.Models.Services;

namespace Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        readonly IMediator _mediator;

        public NotificationsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public IActionResult SaveChanges([FromQuery] Emisor emisor)
        {
            PersistenceService Service = new PersistenceService(_mediator);

            Service.SaveChanges(emisor);
            return Ok($"Emisor #{emisor.Id} Saved!!!");
        }
    }
}