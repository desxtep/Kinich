using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Categoria_Edad
    {
        [Key]
        public int idCategoria_Edad { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Categoria_Edad_Index", IsUnique = true)]
        [Display(Name = "Cetegoria")]
        public string NCatE { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Edad_min { get; set; }
    
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(2, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        public string Edad_max { get; set; }


    }
}
