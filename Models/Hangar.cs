using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_PrimerParcial.Utils;

namespace Proyecto_PrimerParcial.Models
{
    public class Hangar
    {
        public int HangarId { get; set; }
        public string? HangarNombre {get;set;}
        public HangarType HangarSector { get; set; }
        public bool HangarAptoMantenimiento {get;set;} = true;
        public bool HangarOficinas {get;set;} = true;
    }
}