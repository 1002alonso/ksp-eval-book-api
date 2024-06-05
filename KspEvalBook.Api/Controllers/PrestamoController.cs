using KspEvalBook.Api.Models;
using KspEvalBook.Api.Utils;
using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KspEvalBook.Api.Controllers
{
    [Route("control-biblioteca/prestamo/")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly ILibroPrestamoService<LibroPrestamoDto, Guid> _servicePrestamoLibro;
        private readonly IGenericService<LibroDto, Guid> _serviceLibros;
        private readonly ILogger<UsuarioLibrosController> _logger;

        public PrestamoController(ILibroPrestamoService<LibroPrestamoDto, Guid> servicePrestamoLibro, ILogger<UsuarioLibrosController> logger, IGenericService<LibroDto, Guid> serviceLibros)
        {
            _servicePrestamoLibro = servicePrestamoLibro;
            _serviceLibros = serviceLibros;

            _logger = logger;
        }

        // GET: control-biblioteca/prestamo/
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET control-biblioteca/prestamo/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_servicePrestamoLibro.ReadAllIdUser(id));
        }

        // POST control-biblioteca/prestamo/
        [HttpPost]
        public IActionResult Post([FromBody] LibroPrestamoDto value)
        {
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitlePerestamoLibro;

            LibroDto findLibro = _serviceLibros.Read(value.fkLibro);
            int librosPrestados = _servicePrestamoLibro.ValidarLibro(value);
            if (findLibro.numCopias == librosPrestados)
            {
                message.mesage = MensajesConstantes.Error.MessageStockLibro404;
                message.code = "404";
                return StatusCode(404, message);
            }

            int libroAsignado=_servicePrestamoLibro.ValidarUsuarioLibro(value);

            if (libroAsignado != 0)
            {
                message.mesage = MensajesConstantes.Error.MessageUsuarioLibro404;
                message.code = "404";
                return StatusCode(404, message);
            }

           


            _servicePrestamoLibro.Create(value);
            message.mesage = MensajesConstantes.Error.Message201;
            return StatusCode(201, message);

        }

        // PUT control-biblioteca/prestamo/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] LibroPrestamoDto value)
        {
            MMessage message = new MMessage();
            message.title = MensajesConstantes.Error.TitlePerestamoLibro;
            _servicePrestamoLibro.Update(id, value);
            message.mesage = MensajesConstantes.Error.Message201;
            return StatusCode(201, message);
        }

        // DELETE control-biblioteca/prestamo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
