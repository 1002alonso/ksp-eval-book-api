
using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // <summary>
        // Retorna todas las editoriales almacenados
        // </summary>
        // GET: control-biblioteca/editorial/
        [HttpGet]
        public List<EditorialDto> Get()
        {
            return _serviceEditorial.ReadAll();
        }

        // GET control-biblioteca/editorial/5
        [HttpGet("{id}")]
        public EditorialDto Get(Guid id)
        {
            return _serviceEditorial.Read(id);
        }

        // POST control-biblioteca/editorial/
        [HttpPost]
        public void Post([FromBody] EditorialDto value)
        {
             _serviceEditorial.Create(value);
        }

        // PUT control-biblioteca/editorial/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] EditorialDto value)
        {
            _serviceEditorial.Update(id,value);

        }

        // DELETE control-biblioteca/editorial/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _serviceEditorial.Delete(id);
        }
    }
}
