using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Categoria_Peso
    {
        [Key]
        public int idCategoria_Peso { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Categoria_Edad_Index", IsUnique = true)]
        [Display(Name = "NCatP")]
        public string NCatP { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Peso_min { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Peso_max { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
