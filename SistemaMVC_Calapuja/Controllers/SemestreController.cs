using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC_Calapuja.Models;

namespace SistemaMVC_Calapuja.Controllers
{
    public class SemestreController : Controller
    {
        //instanciar la clase
        private Semestre objSemestre = new Semestre();
        // GET: Semestre
        public ActionResult Index()
        {
            return View(objSemestre.Listar());
        }

        //accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objSemestre.Obtener(id));
        }

        //acccion agregar editar
        public ActionResult AgregarEditar(int id=0)
        {
            return View(
                id == 0 ? new Semestre() // Agregar un nuevo objeto
                :objSemestre.Obtener(id)
                );
        }

        //accion Guardar
        public ActionResult Guardar(Semestre objSemestre)
        {
            if (ModelState.IsValid)
            {
                objSemestre.Guardar();
                return Redirect("~/Semestre");
            }
            else
            {
                return View("~/Views/Semestre/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objSemestre.semestre_id = id;
            objSemestre.Eliminar();
            return Redirect("~/Semestre");
        }
    }
}