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
        [HttpPost]
        public ActionResult Index(Departamento departamento)
        {
            modelo.InsertarDepartamento(departamento);
            List<Departamento> lista = modelo.GetDepartamentos();



            ViewBag.Mensaje = "INSERTADO DEPARTAMENTO CON NOMBRE: " + departamento.Nombre +
                ", LOCALIDAD: " + departamento.Localidad + " Y NUMERO: " + departamento.numero;
             
            return View(lista);
        }
        public ActionResult Eliminar( )
        {
    
            return View( );
        }
        [HttpPost]
        public ActionResult Eliminar(int numerodel)
        {
            modelo.EliminarDepartamento(numerodel);
         
            return View();
        }

        public ActionResult Detalles(int deptno)
        {
            Departamento dept = modelo.BuscarDepartamento(deptno);
            return View(dept);
        }
        [HttpPost]
        public ActionResult Detalles(Departamento departamento)
        {
            modelo.ModificarDepartamento(departamento);
            Departamento dept = modelo.BuscarDepartamento(departamento.numeronuevo);
            return View(dept);

        }
        
    }
}
/*int numero,int numeronuevo,String Nombre,String Localidad*/
