using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAccesoDatos.Models;

namespace MVCAccesoDatos.Controllers
{
    public class DoctoresLinqController : Controller
    {
        MVCAccesoDatos.Models.ModeloDoctorLinq modelo;
        public DoctoresLinqController()
        {
            this.modelo = new Models.ModeloDoctorLinq();
        }

        public ActionResult Index()
        {
            List<DOCTOR> lista = modelo.GetDoctores();
            return View(lista);
        }
        public ActionResult Detalle(String doctorno)
        {
            DOCTOR doc = modelo.BuscarDoctor(doctorno);
            return View(doc);
        }
    }
}