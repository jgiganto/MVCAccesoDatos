using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAccesoDatos.Models;

namespace MVCAccesoDatos.Controllers
{
    public class DoctoresController : Controller
    {
        // GET: Doctores
        ModeloDoctores modelo;
        public DoctoresController()
        {
            modelo = new ModeloDoctores();
        }
        public ActionResult Index()
        {
            List<Doctores> lista = modelo.GetDoctores();
            return View(lista);
        }
        public ActionResult Detalles(String doccod)
        {
            Doctores doc = modelo.BuscarDoctor(doccod);
            return View(doc);
        }

    }


}