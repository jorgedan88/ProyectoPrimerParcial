using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_PrimerParcial.Models
{
    public class Aeronave
    {
        public int AeronaveId { get; set; }
        public DateTime AeronaveFabricacion {get;set;}
        public string? AeronaveTipo {get; set;}
        public string? AeronaveMatricula {get; set;}  
        public ICollection<Instructor> InstructorList { get; set; } = new List<Instructor>();  
    }
}