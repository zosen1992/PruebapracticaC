using PruebaC_API.Modelos.Dto;
using System.Collections.Generic;

namespace PruebaC_API.Datos
{
    public static class PruebaStore
    {
        public static List<PruebaDto> pruebalist = new List<PruebaDto>
            {
                new PruebaDto{Id=1, Nombre="Alguien", Ocupantes=3, Distancia=50 },
                new PruebaDto{Id=2, Nombre="Alguien mas",Ocupantes=2, Distancia=40 }

            };  
    }
}   
