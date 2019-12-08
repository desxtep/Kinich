using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Usuario_NickName_Index", IsUnique = true)]
        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Usuario_Correo_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        
        [Index("Usuario_Contraseña_Index", IsUnique = true)]
        [DataType(DataType.Password)]
        [Display(Name = "Constraseña")]
        public string Contraseña { get; set; }

        //Nombre,apepat,apemat,fnac,Peso,Grado,Genero,Tipo_usuario,idCategoria_Edad,idCategoria_Peso
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Usuario_Nombre_Index", IsUnique = true)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Usuario_Apepat_Index", IsUnique = true)]
        [Display(Name = "Apellido paterno")]
        public string apepat { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Usuario_Apemat_Index", IsUnique = true)]
        [Display(Name = "Apellido materno")]
        public string apemat { get; set; }

        [Index("Usuario_Contraseña_Index", IsUnique = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Constraseña")]
        public DateTime fnac { get; set; }

        public decimal Peso { get; set; }

        public int Grado { get; set; }

        [MaxLength(1, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        public string Genero { get; set; }

        public int idCategoria_Edad { get; set; }

        public int idCategoria_Peso { get; set; }

        public string TipoUsuario { get; set; }

        public virtual Categoria_Edad Categoria_Edad { get; set; }

        public virtual Categoria_Peso Categoria_Peso { get; set; }

        public virtual ICollection<Torneo> Torneos { get; set; }
    }
}
