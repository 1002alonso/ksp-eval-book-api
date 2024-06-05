using KspEvalBook.Api.Models;
using KspEvalBook.Api.Utils;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KspEvalBook.Api.Controllers
{
    [Route("control-biblioteca/usuario-libro/")]
    [ApiController]
    public class UsuarioLibrosController : ControllerBase
    {
        private readonly IGenericService<LibroUsuarioDto, Guid> _serviceUserLibro;
        private readonly ILogger<UsuarioLibrosController> _logger;

        public UsuarioLibrosController(IGenericService<LibroUsuarioDto, Guid> serviceUserLibro, ILogger<UsuarioLibrosController> logger)
        {
            _serviceUserLibro = serviceUserLibro;
            _logger = logger;
        }

        // GET: control-biblioteca/usuario-libro/
        [HttpGet]
        public IActionResult Get()
        {
            List<LibroUsuarioDto> listUserLibro = new List<LibroUsuarioDto>();
            MMessage message = new MMessage();

            try
            {
                listUserLibro = _serviceUserLibro.ReadAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageUssuarioLibro);
                message.title = MensajesConstantes.Error.TitleUssuarioLibro;
                message.mesage = MensajesConstantes.Error.MessageUssuarioLibro;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);


            }
            return Ok(listUserLibro);
        }

        // GET control-biblioteca/usuario-libro/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST control-biblioteca/usuario-libro/
        [HttpPost]
        public IActionResult Post([FromBody] LibroUsuarioDto value)
        {
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleUssuarioLibro;

            try
            {
                _serviceUserLibro.Create(value);
                message.mesage = MensajesConstantes.Error.Message201;
                return StatusCode(201, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessagSavedUsuarioLibro);
                message.mesage = MensajesConstantes.Error.MessagSavedUsuarioLibro;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);


            }
        }

        // PUT control-biblioteca/usuario-libro/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] LibroUsuarioDto value)
        {
            LibroUsuarioDto usuarioLibros = new LibroUsuarioDto();
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleUssuarioLibro;

            try
            {
                usuarioLibros = _serviceUserLibro.Read(id);
                if (usuarioLibros == null)
                {
                    message.mesage = MensajesConstantes.Error.Message404;
                    return NotFound(message);
                }
                _serviceUserLibro.Update(id, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageUpdateUsuarioLibro);
                message.mesage = MensajesConstantes.Error.MessageUpdateUsuarioLibro;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);
            }
            return Ok();

        }

        // DELETE control-biblioteca/usuario-libro/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            LibroUsuarioDto libroUsuario = new LibroUsuarioDto();
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitleEditorial;

            try
            {
                libroUsuario= _serviceUserLibro.Read(id);
                if (libroUsuario == null)
                {
                    message.mesage = MensajesConstantes.Error.Message404;
                    return NotFound(message);

                }
                _serviceUserLibro.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MensajesConstantes.Error.MessageDeleteUsuarioLibro);
                message.mesage = MensajesConstantes.Error.MessageDeleteUsuarioLibro;
                return StatusCode((int)HttpStatusCode.InternalServerError, message);

            }

            return Ok(message);

        }
    }
}
