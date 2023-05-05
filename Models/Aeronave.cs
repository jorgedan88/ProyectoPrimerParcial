using System.ComponentModel.DataAnnotations;

namespace ProyectoPrimerParcial.Models


{
    public class Aeronave
    {
        public int AeronaveID { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }

        [Display(Name ="Categoría")]
        public string Categoria { get; set; }

    }
}