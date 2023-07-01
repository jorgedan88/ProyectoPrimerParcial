using Proyecto_PrimerParcial.Models;
using System.ComponentModel.DataAnnotations;
using Proyecto_PrimerParcial.Utils;

namespace Proyecto_PrimerParcial.ViewModels;

public class InstructorCreateViewModel{
        public int InstructorId { get; set; }

        [Required(ErrorMessage ="Debe ingresar el Nombre del instructor")]
        [Display(Name = "Nombre")]
        public string? InstructorNombre {get; set;}

        [Required(ErrorMessage ="Debe ingresar el Apellido del instructor")]
        [Display(Name = "Apellido")]
        public string? InstructorApellido {get; set;}


        [Required(ErrorMessage ="Debe ingresar el DNI del instructor")]
        [Display(Name = "DNI")]
        public int InstructorDni {get; set;}

        [Required(ErrorMessage ="Debe ingresar el tipo de licencia")]
        [Display(Name = "Tipo de licencia")]
        public LicenciaType InstructorTipoLicencia { get; set; }

        [Required(ErrorMessage ="Debe ingresar el numero de la licencia")]
        [Display(Name = "Numero")]
        public int InstructorNumeroLicencia {get; set;}

        [Display(Name = "Fecha expedicion")]
        public DateTime InstructorExpedicion {get;set;}

        [Display(Name = "En actividad")]
        public bool InstructorEnActividad {get;set;} = true;

        [Display(Name = "Aeronave")]
        public int AeronaveId { get; set; }
        public virtual Aeronave? Aeronave { get; set; }

}