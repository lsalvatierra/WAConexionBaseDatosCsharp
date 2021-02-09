using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAConexionBaseDatosCsharp.Models.DaoNotas
{
    public class AlumnoDAO
    {

        public List<Alumno> Listar()
        {
            List<Alumno> lista = new List<Alumno>();
            using (var data = new bdnotasEntities())
            {
                lista = data.Alumno.ToList();

            }
            return lista;
        }

        public Alumno Obtener(String idalumno) {
           Alumno obj = new Alumno();
            using (var data = new bdnotasEntities())
            {
                obj = data.Alumno.Where(q => q.IdAlumno == idalumno).FirstOrDefault();
            }
            return obj;
        }

        public Boolean Registrar(Alumno objalumno)
        {
            bool exito = true;
            try
            {
                using (var data = new bdnotasEntities())
                {
                    exito = data.sp_MantRegistrarAlumno(objalumno.NomAlumno, objalumno.ApeAlumno,
                        objalumno.Idesp, objalumno.PROCE) > 0 ? true : false;
          
                }
            }
            catch (Exception ex)
            {
                exito = false;

            }
            return exito;
        }

        public Boolean Actualizar(Alumno objalumno)
        {
            bool exito = true;
            try
            {
                using (var data = new bdnotasEntities())
                {
                    using (var dbContextTransaction = data.Database.BeginTransaction())
                    {
                        Alumno alumnoactual = data.Alumno.Where(q => q.IdAlumno == objalumno.IdAlumno).FirstOrDefault();
                        alumnoactual.NomAlumno = objalumno.NomAlumno;
                        alumnoactual.ApeAlumno = objalumno.ApeAlumno;
                        alumnoactual.Idesp = objalumno.Idesp;
                        alumnoactual.PROCE = objalumno.PROCE;                        
                        data.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;

            }
            return exito;
        }

        public Boolean Eliminar(String idalumno) {
            bool exito = true;
            try
            {
                using (var data = new bdnotasEntities())
                {
                    exito = data.sp_MantEliminarAlumno(idalumno) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                exito = false;

            }
            return exito;
        }
    }
}