using Proyecto_PrimerParcial.Models;
using System.ComponentModel.DataAnnotations;
using Proyecto_PrimerParcial.Utils;

namespace Proyecto_PrimerParcial.ViewModels;

public class HangarDetailViewModel{

        public int HangarId { get; set; }
        
        [Display(Name = "Nombre")]
        public string? HangarNombre {get;set;}

        [Display(Name = "Sector")]
        public HangarType HangarSector { get; set; }

        [Display(Name = "Mantenimiento")]
        public bool HangarAptoMantenimiento {get;set;} = true;
        [Display(Name = "Oficinas")]
        public bool HangarOficinas {get;set;} = true;

        // public virtual List<Pista> Pistas {get;set;}


}
