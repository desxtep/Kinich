using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Juez_Torneo
    {
        [Key]
        public int Id_user_juez { get; set; }

        public int idUsuario { get; set; }

        public int idTorneo { get; set; }

        public int Area { get; set; }

        public int Autorizado { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Torneo Torneo{ get; set; }

    }
}
