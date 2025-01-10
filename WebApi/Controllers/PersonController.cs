using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<PersonaController> _logger;

        public PersonaController(IPersonaService personaService,
            IUsuarioService usuarioService
            , ILogger<PersonaController> logger
            )
        {
            _personaService = personaService;
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Se solicitó obtener todas las personas.");
            var personas = _personaService.GetAll();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var persona = _personaService.GetById(id);
            return Ok(persona);
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Add([FromBody] PersonaRequest persona)
        {
            _logger.LogInformation("Se solicitó agregar una nueva persona: {Persona}", persona);

            var personaAdd = new Persona
            {
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                NumeroIdentificacion = persona.NumeroIdentificacion,
                Email = persona.Email,
                TipoIdentificacion = persona.TipoIdentificacion,
                FechaCreacion = DateTime.Now
            };
            _personaService.Add(personaAdd);

            var usuarioAdd = new Usuario
            {
                IdPersona = personaAdd.Id,
                User = persona.User,
                Pass = persona.Pass,
                FechaCreacion = DateTime.Now
            };
            _usuarioService.Add(usuarioAdd);
            return CreatedAtAction(nameof(GetById), new { id = personaAdd.Id }, persona);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Update(int id, [FromBody] Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            _personaService.Update(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            _logger.LogWarning("Se solicitó eliminar la persona con ID {Id}.", id);
            _personaService.Delete(id);
            return NoContent();
        }
    }
}
