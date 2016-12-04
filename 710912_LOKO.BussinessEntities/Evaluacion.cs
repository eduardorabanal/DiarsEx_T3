using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710912_LOKO.BussinessEntities
{
    public class Evaluacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
