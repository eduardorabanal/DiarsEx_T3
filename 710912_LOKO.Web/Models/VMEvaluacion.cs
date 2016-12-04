using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _710912_LOKO.Web.Models
{
    public class VMEvaluacion
    {
        //datos compartidos por todas las preguntas
        public string evDescr { get; set; }
        public DateTime evFecha { get; set; }
        //lista de pregunas
        public List<VMPregunta> Preguntas { get; set; }
    }
    public class VMPregunta
    {
        //texto de la pregunta
        public string preText { get; set; }
        //lista de opciones
        public List<string> opciones { get; set; }
    }
}