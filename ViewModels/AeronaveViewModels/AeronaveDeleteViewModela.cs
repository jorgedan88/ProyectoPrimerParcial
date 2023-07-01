using Proyecto_PrimerParcial.Models;
using System.ComponentModel.DataAnnotations;


namespace Proyecto_PrimerParcial.ViewModels;

public class AeronaveDeleteViewModel{
public List<Aeronave> aeronaves {get; set; } = new List<Aeronave>();

        public String? NameFilter { get; set; }

        public int AeronaveId { get; set; }
        [Display(Name = "Fecha de fabricacion")]
        public DateTime AeronaveFabricacion {get;set;}

        [Display(Name = "Tipo de aeronave")]
        public string? AeronaveTipo {get; set;}

        [Display(Name = "Matricula")]
        public string? AeronaveMatricula {get; set;}

}