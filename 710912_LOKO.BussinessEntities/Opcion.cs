using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710912_LOKO.BussinessEntities
{
    public class Opcion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Texto { get; set; }

        [Required]
        public int PreguntaId { get; set; }
        public virtual Pregunta Pregunta { get; set; }
    }
}
