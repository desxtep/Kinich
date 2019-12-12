using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
   
    public class Usuario
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        [Key]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Usuario_NickName_Index", IsUnique = true)]
        [Display(Name = "NombreUsuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        [Index("Usuario_Correo_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
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

        [Index("Usuario_Fecha_Index", IsUnique = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nac")]
        public DateTime fnac { get; set; }

        public decimal Peso { get; set; }

        public int Grado { get; set; }

        [MaxLength(1, ErrorMessage = "The maximun lenght for field {0} is {1} characteres")]
        public string Genero { get; set; }

        public int idCategoria_Edad { get; set; }

        public int idCategoria_Peso { get; set; }

        public string TipoUsuario { get; set; }

        public virtual Categoria_Edad Categoria_Edads { get; set; }

        public virtual Categoria_Peso Categoria_Pesos { get; set; }

        public virtual ICollection<Torneo> Torneos { get; set; }

        public virtual ICollection<Combate> Combates { get; set; }

        public virtual ICollection<Participante_Combate> Participante_Combates { get; set; }

        public virtual ICollection<Participante_Forma> Participante_Formas { get; set; }

        public virtual ICollection<Calificacion> Calificacion { get; set; }
    }
}
