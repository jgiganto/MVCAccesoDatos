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
        ModeloDepartamentos modelo = new ModeloDepartamentos();
        public ActionResult Index()
        {
            
            List<Departamento> lista = modelo.GetDepartamentos();
            return View(lista);
        }
        public ActionResult Detalles(int deptno)
        {
            Departamento dept = modelo.BuscarDepartamento(deptno);
            return View(dept);
        }
    }
}