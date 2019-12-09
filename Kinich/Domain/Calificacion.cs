using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Calificacion
    {
        [Key]
        public int idCalif { get; set; }

        public int idFicha { get; set; }

        public int idUsuario { get; set; }

        public decimal Calificaion { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Participante_Forma Participante_Forma { get; set; }
    }
}
