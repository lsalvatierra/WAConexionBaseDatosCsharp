using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAConexionBaseDatosCsharp.Models.DaoNotas;
using WAConexionBaseDatosCsharp.Models;


namespace WAConexionBaseDatosCsharp.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            ViewBag.lstalumno = new AlumnoDAO().Listar();
            return View();
        }

        public ActionResult Nuevo(String idalumno)
        {
            if (idalumno != "") {
                ViewBag.alumno = new AlumnoDAO().Obtener(idalumno);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(String txtnombre, String txtapellido, String txtespecialidad, String txtprocedencia, String idalumno) {
            Boolean rpta = true;
            Alumno objalumno = new Alumno();
            objalumno.NomAlumno = txtnombre;
            objalumno.ApeAlumno = txtapellido;
            objalumno.Idesp = txtespecialidad;
            objalumno.PROCE = txtprocedencia;
            objalumno.IdAlumno = idalumno;
            if (idalumno == "")
            {
                rpta = new AlumnoDAO().Registrar(objalumno);
            }
            else {
                rpta = new AlumnoDAO().Actualizar(objalumno);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Obtener(String idalumno)
        {
            if (idalumno != "")
            {
                ViewBag.alumno = new AlumnoDAO().Obtener(idalumno);
            }
            return View();
        }
        public ActionResult Eliminar(String idalumno)
        {
            Boolean rpta = new AlumnoDAO().Eliminar(idalumno);
            return RedirectToAction("Index");
        }


    }
}