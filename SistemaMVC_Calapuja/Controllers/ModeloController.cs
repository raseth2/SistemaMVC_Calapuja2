using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaMVC_Calapuja.Models;

namespace SistemaMVC_Calapuja.Controllers
{
    public class ModeloController : Controller
    {
        //instanciar la clase
        private Modelo objModelo = new Modelo();
        // GET: Modelo
        public ActionResult Index()
        {
            return View(objModelo.Listar());
        }

        //accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objModelo.Obtener(id));
        }

        //acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Modelo() // Agregar un nuevo objeto
                : objModelo.Obtener(id)
                );
        }

        //accion Guardar
        public ActionResult Guardar(Modelo objModelo)
        {
            if (ModelState.IsValid)
            {
                objModelo.Guardar();
                return Redirect("~/Modelo");
            }
            else
            {
                return View("~/Views/Modelo/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objModelo.modelo_id = id;
            objModelo.Eliminar();
            return Redirect("~/Modelo");
        }
    }
}