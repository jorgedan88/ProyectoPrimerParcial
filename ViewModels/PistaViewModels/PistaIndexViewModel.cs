using Proyecto_PrimerParcial.Models;
using System.ComponentModel.DataAnnotations;
using Proyecto_PrimerParcial.Utils;

namespace Proyecto_PrimerParcial.ViewModels;

public class PistaIndexViewModel{
        public List<Pista> pistas {get; set; } = new List<Pista>();
        public String? NameFilterPista { get; set; }
        public int PistaId { get; set; }
        [Display(Name = "Nombre")]
        public string? PistaNombre {get;set;}
        [Display(Name = "Capacidad")]
        public PistaType PistaCapacidad { get; set; }
        [Display(Name = "Iluminacion")]
        public bool PistaIluminacion {get;set;} = true;
        [Display(Name = "Aprovisionamiento")]
        public bool PistaAprovisionamiento {get;set;} = true;
        //        [Display(Name = "Tipo de aeronave")]
        // public virtual List<Hangar> Hangars {get;set;}
}
