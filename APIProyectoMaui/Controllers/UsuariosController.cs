using APIProyectoMaui.Models;
using APIProyectoMaui.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyectoMaui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosDBContext _db;

        public UsuariosController(UsuariosDBContext db)
        {
            _db = db;
        }

        // GET: api/<ValuesController>
        /*[HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Usuarios>iniciarSesions = _db.ToList();
            return Ok(iniciarSesions);
        }*/

        [HttpGet]
        [Route("{user}/{password}")]
        public async Task<IActionResult> Login(String user, String password)
        {
            Usuarios iniciarSesions = await _db.Usuarios.Where(x => x.Correo == user && x.Contrasena == password).FirstOrDefaultAsync();
            return Ok(iniciarSesions);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        [Route("Registrarse")]
        public Usuarios Registrarse([FromBody] Usuarios usuario)
        {
            try
            {
                _db.Usuarios.Add(usuario);
                _db.SaveChanges();
                return usuario;
            }
            catch (Exception)
            {

                throw;

            }
        }

        [HttpGet]
        [Route("{user}")]
        public async Task<IActionResult> ObtenerUsuarioPorCorreo(String user)
        {
            Usuarios correo = await _db.Usuarios.Where(x => x.Correo == user).FirstOrDefaultAsync();

            return Ok(correo);
            /*try
            {
                var usuario = _db.Usuarios.FirstOrDefault(u => u.Correo == user);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound(); // Puedes devolver un código 404 si el usuario no se encuentra
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones según tus necesidades
                return StatusCode(500, "Error interno del servidor");
            }*/
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}