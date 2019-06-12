using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC_Calapuja.Models;

namespace SistemaMVC_Calapuja.Controllers
{
    public class DocenteController : Controller
    {
        //instanciar la clase
        private Docente objDocente = new Docente();
        // GET: Docente
        public ActionResult Index()
        {
            return View(objDocente.Listar());
        }

        //accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objDocente.Obtener(id));
        }

        //acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Docente() // Agregar un nuevo objeto
                : objDocente.Obtener(id)
                );
        }

        //accion Guardar
        public ActionResult Guardar(Docente objDocente)
        {
            if (ModelState.IsValid)
            {
                objDocente.Guardar();
                return Redirect("~/Docente");
            }
            else
            {
                return View("~/Views/Docente/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objDocente.docente_id = id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }
    }
}