using IntegrationAPI.Adapters;
using IntegrationLibrary.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.SharedModel.Model;
using IntegrationLibrary.SharedModel.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{

    [Route("api2/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private INotificationsForAppService notificationService;

        public NotificationsController(INotificationsForAppService notificationService)
        {
            this.notificationService = notificationService;
        }


        [HttpGet]       // GET /api2/notifications
        public IActionResult Get()
        {
            List<NotificationsForAppDto> result = new List<NotificationsForAppDto>();
            notificationService.GetAll().ForEach(notification => result.Add(NotificationsForAppAdapter.NotificationsToDTO(notification)));
            return Ok(result);
        }

        [HttpPut]  //for update
        public IActionResult Put(NotificationsForAppDto dto)
        {
            
          NotificationsForApp notification = notificationService.Get(dto.Id);
            notification.Seen = true;
            
            if (notification == null)
            {
                return NotFound();
            }
            notificationService.Update(notification);
            return Ok();
        }

       [HttpPost]     
        public IActionResult Add(NotificationsForAppDto dto)
        {
            notificationService.Save(NotificationsForAppAdapter.NotificationsFromDTO(dto));
            return Ok();
        }

        [HttpGet("{content?}")]       // GET /api2/notifications
        public IActionResult AddNewNotification(string content)
        {
            NotificationsForAppDto nova = new NotificationsForAppDto(1, content, DateTime.Now, false);
           
             notificationService.Save(NotificationsForAppAdapter.NotificationsFromDTO(nova));
            return Ok();
        }

        [HttpDelete("{id?}")]       // DELETE /api/notifications/1
        public IActionResult Delete(int id)
        {
            NotificationsForApp notification = notificationService.Get(id);
            if (notification == null)
            {
                return NotFound();
            }
            else
            {
                notificationService.Delete(notification);
                return Ok();
            }
        }


        [HttpGet]       // GET /api2/notifications/count
        [Route("count")]
        public IActionResult GetNumberOfUnseen()
        {
            int number = 0;
            number = notificationService.GetNumberOfUnseen();
            return Ok(number);
        }
    }
}
