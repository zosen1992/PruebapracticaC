﻿using System.ComponentModel.DataAnnotations;

namespace PruebaC_API.Modelos.Dto
{
    public class PruebaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public string Detalle { get; set; }
        public double Tarifa { get; set; }
        public int Ocupantes { get; set; }
        public int Distancia { get; set; }
        
        public string ImagenUrl { get; set; }

        public string Amenidad { get; set; }
    }
}
