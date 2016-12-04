using _710912_LOKO.BussinessEntities;
using _710912_LOKO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _710912_LOKO.Web.Models;

namespace _710912_LOKO.Web.Controllers
{
    public class EvaluacionController : Controller
    {
        IGenericService<Evaluacion> _evaluaciones;
        IGenericService<Pregunta> _preguntas;
        IGenericService<Opcion> _opciones;

        public EvaluacionController
        (
            IGenericService<Evaluacion> evaluaciones,
            IGenericService<Pregunta> preguntas,
            IGenericService<Opcion> opciones
        )
        {
            _evaluaciones = evaluaciones;
            _preguntas = preguntas;
            _opciones = opciones;
        }

        public ActionResult Index(/*string SearchCriteria*/)
        {
            var lista=_evaluaciones.GetAll();
            return View(lista);
        }

        // GET: Evaluacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evaluacion/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult VerPreguntas(int evaluacionId)
        {
            //vm para representar los datos
            var evaluacionVM = new VMEvaluacion();
            //evaluacion
            var evaluacion = _evaluaciones.GetById(evaluacionId);

            evaluacionVM.evDescr = evaluacion.Descripcion;
            evaluacionVM.evFecha = evaluacion.Fecha;

            //preguntas de la evaluacion
            var preguntas = _preguntas.Find(x => x.EvaluacionId == evaluacionId);

            evaluacionVM.Preguntas = new List<VMPregunta>();
            try
            {
                if (preguntas.Count() > 0)
                {
                    for (int i = 0; i < preguntas.Count(); i++)
                    {
                        var preguntaVM = new VMPregunta();
                        preguntaVM.opciones = new List<string>();

                        var preguntaId = preguntas.ToList()[i].Id;
                        //opciones de la pregunta
                        var opciones = _opciones.Find(x => x.PreguntaId == preguntaId);

                        preguntaVM.preText= preguntas.ToList()[i].Texto;

                        for (int j = 0; j < opciones.Count(); j++)
                        {
                            //agregando las opciones a la pregunta
                            preguntaVM.opciones.Add(opciones.ToList()[j].Texto);
                        }
                        //agregando preguntasVM a la evaluacionVM
                        evaluacionVM.Preguntas.Add(preguntaVM);
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.mensaje = "Error";
            }
            return View(evaluacionVM);
        }

        //intento infructuoso
        //public ActionResult VerPreguntas2(int evaluacionId)
        //{
        //    var preguntas=_preguntas.Find(x => x.EvaluacionId == evaluacionId);
        //    ViewBag.Evaluacion = _evaluaciones.GetById(evaluacionId);
        //    return View(preguntas);
        //}


        //public ActionResult AgregarPregunta(int evaluacionId, VMPregunta preguntaVM)
        //{
        //    var model = new Pregunta();
        //    model.EvaluacionId = evaluacionId;
        //    foreach(var item in preguntaVM.opciones)
        //    {
        //        var opc = new Opcion();
        //        opc.PreguntaId=pregu
        //        _opciones.Add
        //    }


        //}

        //// POST: Evaluacion/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Evaluacion/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Evaluacion/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Evaluacion/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Evaluacion/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
