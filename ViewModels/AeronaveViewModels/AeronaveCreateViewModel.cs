using Proyecto_PrimerParcial.Models;
using System.ComponentModel.DataAnnotations;
using Proyecto_PrimerParcial.Utils;

namespace Proyecto_PrimerParcial.ViewModels;

public class AeronaveCreateViewModel{

        public int AeronaveId { get; set; }
        [Display(Name = "Fecha de fabricacion")]
        public DateTime AeronaveFabricacion {get;set;}

        [Display(Name = "Tipo de aeronave")]
        public string? AeronaveTipo {get; set;}

        [Display(Name = "Matricula")]
        public string? AeronaveMatricula {get; set;}


}