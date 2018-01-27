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
        ModeloDepartamentos modelo;
        public DepartamentosController()
        {
            modelo = new ModeloDepartamentos();
        }
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
        [HttpPost]
        public ActionResult Index(Departamento departamento)
        {
            modelo.InsertarDepartamento(departamento);
            List<Departamento> lista = modelo.GetDepartamentos();

            ViewBag.Mensaje = "NOMBRE " + departamento.Nombre +
                " LOCALIDAD " + departamento.Localidad + " NUMERO " + departamento.numero;
            return View(lista);
        }
    }
}
