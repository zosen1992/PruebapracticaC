using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaC_API.Modelos;
using System.Collections.Generic;

namespace PruebaC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {

        public IEnumerable<Prueba>  Getprueba()
        {
            return new list<Prueba>
            {
                new Prueba{Id=1,Nombre="Esta es el primer texto"},
                new Prueba{Id=2,Nombre="Esta es el segundo texto"},
            };
        }

    }
}
