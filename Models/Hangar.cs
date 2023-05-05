using System.ComponentModel.DataAnnotations;


namespace ProyectoPrimerParcial.Models
{
    public class Hangar
    {
        public int HangarId { get; set; }

        [Display(Name = "Nombre del Hangar")]
        public string NombreHangar { get; set; }

        public int NumeroHangar { get; set; }
    }
}