using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPrimerParcial.Models
{  
    public class Instructor
    {
        public int InstructorId{get; set;}

        [Range(1,50000,ErrorMessage ="El campo debe ser un número entre 1 y 5000")]
        [Required(ErrorMessage ="Debe ingresar el Legajo de Vuelo")]
        public int LegajoVuelo {get; set;}
        
        [Required(ErrorMessage ="Debe ingresar el Nombre")]
        public string Nombre {get; set;}

        [Required(ErrorMessage ="Debe ingresar el Apellido")]
        public string Apellido {get; set;}

        [Required(ErrorMessage ="Debe ingresar el DNI")]
        public int DNI {get; set;}
        public DateTime FechaExpedicion {get; set;}
        [Range(1,3)]
        public int Experiencia{get; set;}
        public bool EnActividad {get; set;}
    }
}  

