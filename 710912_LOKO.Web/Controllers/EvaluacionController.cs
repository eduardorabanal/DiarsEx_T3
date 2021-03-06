﻿using _710912_LOKO.BussinessEntities;
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

        public ActionResult AgregarPregunta(int evaluacionId)
        {
            ViewBag.Evaluacion = _evaluaciones.GetById(evaluacionId);

            var model = new Pregunta();
            model.EvaluacionId = evaluacionId;
            model.Opciones = new List<Opcion>();
            return View();
        }
        [HttpPost]
        public ActionResult AgregarPregunta(Pregunta model)
        {
            if (ModelState.IsValid)
            {
                _preguntas.Add(model);
                return RedirectToAction("VerPreguntasJOINS",new { evaluacionId = model.EvaluacionId });
            }
            return View(model);
        }

        public ActionResult EditarPregunta(int preguntaId)
        {
            var model = _preguntas.GetById(preguntaId);
            //var model = new Pregunta();
            //model.EvaluacionId = evaluacionId;
            //model.Opciones = new List<Opcion>();
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarPregunta(Pregunta model)
        {
            if (ModelState.IsValid)
            {
                foreach(var opc in model.Opciones)
                {
                    opc.PreguntaId = model.Id;
                    _opciones.Edit(opc);
                }
                _preguntas.Edit(model);
                return RedirectToAction("VerPreguntasJOINS", new { evaluacionId = model.EvaluacionId });
            }
            return View(model);
        }

        //más facil, usando joins
        public ActionResult VerPreguntasJOINS(int evaluacionId)
        {
            var evaluacion =
                from e in _evaluaciones.GetAll()
                join p in _preguntas.GetAll() on e.Id equals p.EvaluacionId
                    //falta validar cuando no hay preguntas
                    //into ep
                    //from pregunta in ep.DefaultIfEmpty()
                join o in _opciones.GetAll() on p.Id equals o.PreguntaId
                    //validado cuando no hay opciones
                    into po
                    from opc in po.DefaultIfEmpty()
                where e.Id == evaluacionId
                select e;

            //var loj = (from prsn in db.People
            //           join co in db.Companies on prsn.Person_ID equals co.Person_ID 
            //            into comps
            //            from y in comps.DefaultIfEmpty()
            //           join prod in db.Products on prsn.Person_ID equals prod.Person_ID
            //            into prods
            //            from x in prods.DefaultIfEmpty()
            //           select new { Person = prsn.NAME, Company = y.NAME, Product = x.NAME })

            return View(evaluacion.First());
        }

        //usando ViewModel
        public ActionResult VerPreguntasVM(int evaluacionId)
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
