using Proyecto_PrimerParcial.Models;
using System.ComponentModel.DataAnnotations;
using Proyecto_PrimerParcial.Utils;

namespace Proyecto_PrimerParcial.ViewModels;

public class InstructorDeleteViewModel {
        public String? NameFilterIns { get; set; }
        public int InstructorId { get; set; }

        [Display(Name = "Nombre")]
        public string? InstructorNombre {get; set;}

        [Display(Name = "Apellido")]
        public string? InstructorApellido {get; set;}


        [Display(Name = "DNI")]
        public int InstructorDni {get; set;}

        [Display(Name = "Tipo de licencia")]
        public LicenciaType InstructorTipoLicencia { get; set; }

        [Display(Name = "Numero")]
        public int InstructorNumeroLicencia {get; set;}

        [Display(Name = "Fecha expedicion")]
        public DateTime InstructorExpedicion {get;set;}

        [Display(Name = "En actividad")]
        public bool InstructorEnActividad {get;set;} = true;

        [Display(Name = "Aeronave")]
        public int AeronaveId { get; set; }
        public virtual Aeronave? Aeronave { get; set; }

        public List<Instructor> instructors {get; set; } = new List<Instructor>();

}