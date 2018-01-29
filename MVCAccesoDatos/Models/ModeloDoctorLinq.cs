using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAccesoDatos.Models
{
    public class ModeloDoctorLinq
    {
        ContextoDoctorDataContext contexto;

        public ModeloDoctorLinq()
        {
            this.contexto = new ContextoDoctorDataContext();
        }
        //doctor lo pone en mayusculas pq creo la clase con mayusculas
        public List<DOCTOR> GetDoctores()
        {
            var consulta = from datos in contexto.DOCTORs
                           select datos;
            return consulta.ToList();
        }

        public DOCTOR BuscarDoctor(String doctorno)
        {
            var consulta = from datos in contexto.DOCTORs
                           where datos.DOCTOR_NO == doctorno
                           select datos;

            //podria suceder que no tivieramos doctor o que no encontrase resultados
            //para ello el metodo .Count() devolvera el nº de elementos de una consulta
            //Dos posibilidades
            //1. Comprobamos los resultados
             
            if (consulta.Count()==0){
            //hacemos algo 
            return null;
            }else{
            //2. delvolvemos el unico registro(el primero)
            return consulta.First();
             }
           
            
        }
    }
}