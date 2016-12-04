namespace _710912_LOKO.Repository.Migrations
{
    using _710912_LOKO.BussinessEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_710912_LOKO.Repository.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_710912_LOKO.Repository.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Evaluaciones.AddOrUpdate(
              p => p.Descripcion,
              new Evaluacion
              {
                  Id=1,
                  Descripcion = "Mate",
                  Fecha=DateTime.Parse("2015/11/10")
              },
              new Evaluacion
              {
                  Id = 2,
                  Descripcion = "Encuesta",
                  Fecha = DateTime.Parse("2016/12/11")
              }
            );

            context.Preguntas.AddOrUpdate(
               p => p.Texto,
               new Pregunta
               {
                   Id = 1,
                   EvaluacionId = 1,
                   Texto = "¿Cuánto es 1+1?",
                   OpcionMarcada = "a"
               },
               new Pregunta
               {
                   Id = 2,
                   EvaluacionId = 1,
                   Texto = "¿Cuánto es 2+3?",
                   OpcionMarcada = "b"
               },
               new Pregunta
               {
                   Id = 3,
                   EvaluacionId = 2,
                   Texto = "¿Cuando es tu cumple?",
                   OpcionMarcada = "c"
               },
               new Pregunta
               {
                   Id = 4,
                   EvaluacionId = 2,
                   Texto = "¿Donde vives?",
                   OpcionMarcada = "a"
               }
             );
            context.Opciones.AddOrUpdate(
              p => p.Texto,
              new Opcion
              {
                  Id = 1,
                  Texto = "2",
                  PreguntaId = 1
              },
              new Opcion
              {
                  Id = 2,
                  Texto = "1",
                  PreguntaId = 1
              },
              new Opcion
              {
                  Id = 3,
                  Texto = "4",
                  PreguntaId = 1
              },
              new Opcion
              {
                  Id = 4,
                  Texto = "35",
                  PreguntaId = 1
              }
            );
        }
    }
}
