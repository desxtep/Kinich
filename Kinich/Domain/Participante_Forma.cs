using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Participante_Forma
    {
        [Key]
        public int idFicha { get; set; }

        public int idUsuario { get; set; }

        public int idTorneo { get; set; }

        public int Area { get; set; }

        
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Forma_Name_Index", IsUnique = true)]
        [Display(Name = "Nombre_Forma")]
        public string Nombre_Forma { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Display(Name = "Tipo_Forma")]
        public string Tipo_Forma { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Display(Name = "Hora_Aprox")]
        public string Hora_Aprox { get; set; }

        public int Duracion { get; set; }

        public decimal Cal { get; set; }

        public int Resultado { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Torneo Torneo { get; set; }

        public virtual ICollection<Calificacion> Calificacion { get; set; }


    }
}
