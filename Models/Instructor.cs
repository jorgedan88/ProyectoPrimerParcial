using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_PrimerParcial.Utils;

namespace Proyecto_PrimerParcial.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string? InstructorNombre {get; set;}
        public string? InstructorApellido {get; set;}
        public int InstructorDni {get; set;}
        public LicenciaType InstructorTipoLicencia { get; set; }
        public int InstructorNumeroLicencia {get; set;}
        public DateTime InstructorExpedicion {get;set;}
        public bool InstructorEnActividad {get;set;} = true;
        public int AeronaveId { get; set; }
        public virtual Aeronave? Aeronave { get; set; }
    }
}