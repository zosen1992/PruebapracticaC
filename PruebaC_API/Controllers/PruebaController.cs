using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaC_API.Datos;
using PruebaC_API.Modelos;
using PruebaC_API.Modelos.Dto;
using System.Collections.Generic;

namespace PruebaC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly ILogger<PruebaController> _logger;
        private readonly ApplicationDbContext _db;
        public PruebaController(ILogger<PruebaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;   

        }

        [HttpGet]
        public ActionResult<IEnumerable<PruebaDto>> GetPrueba()
        {
            _logger.LogInformation("obtener datos");
            return Ok(_db.Pruebas.ToList()/*PruebaStore.pruebalist*/);
            /*return new List<PruebaDto>
            {
                new PruebaDto{Id=1,Nombre="Esta es el primer texto"},
                new PruebaDto{Id=2,Nombre="Esta es el segundo texto"},
            };*/
        }


        [HttpGet("id", Name = "GetPrueba")]
        [ProducesResponseType(200) /*(StatusCodes.Status200Ok)*/]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<PruebaDto> GetPrueba(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Error con " + id);
                return BadRequest();
            }

            //var prueba = PruebaStore.pruebalist.FirstOrDefault(v => v.Id == id);
             var prueba = _db.Pruebas.FirstOrDefault(v => v.Id == id);

            if(prueba == null)
                
            {
                return NotFound();
            }
            return Ok(prueba);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<PruebaDto> CrearPrueba([FromBody] PruebaDto pruebaDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (/*PruebaStore.pruebalist*/_db.Pruebas.FirstOrDefault(v => v.Nombre.ToLower() == pruebaDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La prueba con ese nombre ya existe");
                return BadRequest(ModelState);
            }

            if (pruebaDto == null)
            {
                return BadRequest();
            }
            if (pruebaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            /*pruebaDto.Id = PruebaStore.pruebalist.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            PruebaStore.pruebalist.Add(pruebaDto);*/

            /*return Ok(pruebaDto); */
            Prueba modelo = new()
            {
                /*Id = pruebaDto.Id,*/
                Nombre = pruebaDto.Nombre,
                Detalle = pruebaDto.Detalle,
                ImagenUrl = pruebaDto.ImagenUrl,
                Ocupantes = pruebaDto.Ocupantes,
                Tarifa = pruebaDto.Tarifa,
                Distancia = pruebaDto.Distancia,
                Amenidad = pruebaDto.Amenidad
            };
            _db.Pruebas.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetPrueba", new { id = pruebaDto.Id }, pruebaDto);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePrueba(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var prueba= _db.Pruebas.FirstOrDefault(v =>v.Id == id) ;
            if (prueba == null)
            {
                return NotFound();
            }
            _db.Pruebas.Remove(prueba);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult updatePrueba(int id, [FromBody] PruebaDto pruebaDto)
        {
            if (pruebaDto == null || id != pruebaDto.Id)
            {
                return BadRequest();
            }

            var prueba = _db.Pruebas.FirstOrDefault(v => v.Id == id);
            /*var prueba = PruebaStore.pruebalist.FirstOrDefault(v => v.Id == id);
            prueba.Nombre= pruebaDto.Nombre;
            prueba.Ocupantes= pruebaDto.Ocupantes;
            prueba.Distancia= pruebaDto.Distancia;
            */

            Prueba modelo = new()
            {
                Id = pruebaDto.Id,
                Nombre = pruebaDto.Nombre,
                Detalle = pruebaDto.Detalle,
                ImagenUrl = pruebaDto.ImagenUrl,
                Ocupantes = pruebaDto.Ocupantes,
                Tarifa = pruebaDto.Tarifa,
                Distancia = pruebaDto.Distancia,
                Amenidad = pruebaDto.Amenidad
            };
            _db.Pruebas.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public IActionResult updatePartialPrueba(int id, JsonPatchDocument<PruebaDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            var prueba = _db.Pruebas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            PruebaDto pruebaDto = new()
            {
                Id = prueba.Id,
                Nombre = prueba.Nombre,
                Detalle = prueba.Detalle,
                ImagenUrl = prueba.ImagenUrl,
                Ocupantes = prueba.Ocupantes,
                Tarifa = prueba.Tarifa,
                Distancia = prueba.Distancia,
                Amenidad = prueba.Amenidad
            };

            if (prueba == null) return BadRequest();
            patchDto.ApplyTo(pruebaDto, ModelState );

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prueba modelo = new()
            {
                Id = pruebaDto.Id,
                Nombre = pruebaDto.Nombre,
                Detalle = pruebaDto.Detalle,
                ImagenUrl = pruebaDto.ImagenUrl,
                Ocupantes = pruebaDto.Ocupantes,
                Tarifa = pruebaDto.Tarifa,
                Distancia = pruebaDto.Distancia,
                Amenidad = pruebaDto.Amenidad
            };

            _db.Pruebas.Update(modelo);
            _db.SaveChanges();
           
            return NoContent();
        }
    }
}
