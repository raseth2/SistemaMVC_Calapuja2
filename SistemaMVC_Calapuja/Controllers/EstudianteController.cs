using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC_Calapuja.Models;


namespace SistemaMVC_Calapuja.Controllers
{
    public class EstudianteController : Controller
    {
        //instanciar la clase
        private Estudiante objEstudiante = new Estudiante();
        // GET: Estudiante
        public ActionResult Index()
        {
            return View(objEstudiante.Listar());
        }

        //accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objEstudiante.Obtener(id));
        }

        //acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Estudiante() // Agregar un nuevo objeto
                : objEstudiante.Obtener(id)
                );
        }

        //accion Guardar
        public ActionResult Guardar(Estudiante objEstudiante, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string archivo = (file.FileName).ToLower();

                file.SaveAs(Server.MapPath("~/Archivos/" + file.FileName));

                objEstudiante.foto = file.FileName;
                objEstudiante.Guardar();

                return Redirect("~/Estudiante");
            }
            else
            {
                return View("~/Views/Estudiante/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objEstudiante.estudiante_id = id;
            objEstudiante.Eliminar();
            return Redirect("~/Estudiante");
        }
    }
}