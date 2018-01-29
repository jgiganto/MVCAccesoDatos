using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAccesoDatos.Models;
using MVCAccesoDatos.Controllers;

namespace MVCAccesoDatos.Controllers
{
    public class DepartamentosLinqController : Controller
    {
        ModeloDepartamentoLinq modelo;

        public DepartamentosLinqController()
        {
            modelo = new ModeloDepartamentoLinq();
        }
        public ActionResult Index()
        {
            List<DEPT> lista = modelo.GetDepartamento();
            return View(lista);
        }

        public ActionResult Detalle(int Depno)
        {
            DEPT dep = modelo.BuscarDept(Depno);
            return View(dep);
        }
    }
}