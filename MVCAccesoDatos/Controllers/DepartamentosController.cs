using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAccesoDatos.Models;
namespace MVCAccesoDatos.Controllers
{
    public class DepartamentosController : Controller
    {
        // GET: Departamentos
        public ActionResult Index()
        {
            ModeloDepartamentos modelo = new ModeloDepartamentos();
            List<Departamento> lista = modelo.GetDepartamentos();
            return View(lista);
        }
    }
}