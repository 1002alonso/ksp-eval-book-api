
using KspEvalBook.Api.Models;
using KspEvalBook.Api.Utils;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KspEvalBook.Api.Controllers
{
    [Route("control-biblioteca/editorial/")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IGenericService<EditorialDto, Guid> _serviceEditorial;
        private readonly ILogger<EditorialController> _logger;
        

        public EditorialController(IGenericService<EditorialDto, Guid> serviceEditorial, ILogger<EditorialController> logger)
        {
            _serviceEditorial = serviceEditorial;
            _logger = logger;
        }

    
        // GET: control-biblioteca/editorial/
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Get()
        {
            List<EditorialDto> listEditorial =new List<EditorialDto>();
            MMessage message = new MMessage();
           

            try
            {
                listEditorial = _serviceEditorial.ReadAll();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageEditorial);
                message.title = MensajesConstantes.Error.TitleEditorial;
                message.mesage = MensajesConstantes.Error.MessageEditorial;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }
            return Ok(listEditorial);

        }

        // GET control-biblioteca/editorial/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            EditorialDto editorial = new EditorialDto();
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleEditorial;
            try
            {
                editorial = _serviceEditorial.Read(id);
                if (editorial == null)
                {
                    message.mesage = MensajesConstantes.Error.Message404;
                    return NotFound(message);
                }
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageReadEditorial);
                message.mesage = MensajesConstantes.Error.MessageReadEditorial;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }

            return Ok(editorial);
        }

        // POST control-biblioteca/editorial/
        [HttpPost]
        public IActionResult Post([FromBody] EditorialDto value)
        {
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleEditorial;

            try
            {
                _serviceEditorial.Create(value);
                message.mesage = MensajesConstantes.Error.Message201;
                return StatusCode(201, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessagSavedEditorial);
                message.mesage = MensajesConstantes.Error.MessagSavedEditorial;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }

            
        }

        // PUT control-biblioteca/editorial/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] EditorialDto value)
        {
            EditorialDto editorial = new EditorialDto();
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleEditorial;
            try
            {
                editorial = _serviceEditorial.Read(id);
                if (editorial == null)
                {
                    message.mesage = MensajesConstantes.Error.Message404;
                    return NotFound(message);
                
                }
                _serviceEditorial.Update(id, value);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageUpdateEditorial);
                message.mesage = MensajesConstantes.Error.MessageUpdateEditorial;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }
            return Ok();

        }

        // DELETE control-biblioteca/editorial/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            EditorialDto editorial = new EditorialDto();
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleEditorial;
            try
            {
                editorial = _serviceEditorial.Read(id);
                if (editorial == null)
                {
                    message.mesage = MensajesConstantes.Error.Message404;
                    return NotFound(message);
                    
                }
                _serviceEditorial.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageDeleteEditorial);
                message.mesage = MensajesConstantes.Error.MessageDeleteEditorial;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }

            return Ok(message);

        }
    }
}
