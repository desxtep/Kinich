using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Combate
    {
        [Key]
        public int idCombate { get; set; }

        public int idTorneo { get; set; }

        public int Id_part1 { get; set; }

        public int Id_part2 { get; set; }

        [Display(Name = "Ganador")]
        public int idUsuario { get; set; }

        public int nivel { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Torneo Torneo { get; set; }
    }
}
