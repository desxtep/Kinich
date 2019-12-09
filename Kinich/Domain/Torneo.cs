using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Torneo
    {
        [Key]
        public int idTorneo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Torneo_Name_Index", IsUnique = true)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        
        [Display(Name = "Sede")]
        public string Sede { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }

        
        public int idUsuario { get; set; }

        

        public int NoAreas { get; set; }

        public virtual Usuario Usuarios { get; set; }
        public virtual ICollection<Juez_Torneo> Juez_Torneos { get; set; }

        public virtual ICollection<Combate> Combates { get; set; }

        public virtual ICollection<Participante_Combate> Participante_Combates { get; set; }

        public virtual ICollection<Participante_Forma> Participante_Formas { get; set; }
    }
}
