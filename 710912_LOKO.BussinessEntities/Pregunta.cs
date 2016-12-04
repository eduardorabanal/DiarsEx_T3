using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710912_LOKO.BussinessEntities
{
    public class Pregunta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EvaluacionId { get; set; }
        
        public virtual Evaluacion Evaluacion { get; set; }

        [Required]
        [StringLength(250)]
        public string Texto { get; set; }

        [StringLength(100)]
        public string OpcionMarcada { get; set; }
    }
}
