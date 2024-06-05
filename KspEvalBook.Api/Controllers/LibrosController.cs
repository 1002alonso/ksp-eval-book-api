using KspEvalBook.Api.Models;
using KspEvalBook.Api.Utils;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KspEvalBook.Api.Controllers
{
    [Route("control-biblioteca/libro/")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly IGenericService<LibroDto, Guid> _serviceLibros;
        private readonly ILogger<LibrosController> _logger;

        public LibrosController(IGenericService<LibroDto, Guid> serviceLibros, ILogger<LibrosController> logger)
        {
            _serviceLibros = serviceLibros;
            _logger = logger;
        }

        // GET: control-biblioteca/libro/
        [HttpGet]
        public IActionResult Get()
        {
            List<LibroDto> listLibros = new List<LibroDto>();
            MMessage message = new MMessage();

            try
            {
                listLibros = _serviceLibros.ReadAll();
            }
            catch (Exception ex)
            {
                
                    _logger.LogError(ex, MensajesConstantes.Error.MessageLibro);
                    message.title = MensajesConstantes.Error.TitleLibro;
                    message.mesage = MensajesConstantes.Error.MessageLibroS;
                    return StatusCode((int)HttpStatusCode.InternalServerError, message);


            }

            return Ok(listLibros);
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST control-biblioteca/libro/
        [HttpPost]
        public IActionResult Post([FromBody] LibroDto value)
        {
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleLibro;

            try
            {
                _serviceLibros.Create(value);
                message.mesage = MensajesConstantes.Error.Message201;
                return StatusCode(201, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessagSavedLibro);
                message.mesage = MensajesConstantes.Error.MessagSavedLibro;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }

        }

        // PUT control-biblioteca/libro/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] LibroDto value)
        {
            LibroDto libro = new LibroDto();
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleLibro;

            try
            {
                libro = _serviceLibros.Read(id);
                if (libro == null)
                {
                    message.mesage = MensajesConstantes.Error.Message404;
                    return NotFound(message);
                }
                _serviceLibros.Update(id, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageUpdateLibro);
                message.mesage = MensajesConstantes.Error.MessageUpdateLibro;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }
            return Ok();

        }

        // DELETE control-biblioteca/libro/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            LibroDto libro = new LibroDto();
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleLibro;

            try
            {
                libro  = _serviceLibros.Read(id);
                if (libro == null)
                {
                    message.mesage = MensajesConstantes.Error.Message404;
                    return NotFound(message);

                }
                _serviceLibros.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageDeleteLibro);
                message.mesage = MensajesConstantes.Error.MessageDeleteLibro;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }

            return Ok(message);


            }
    }
}
