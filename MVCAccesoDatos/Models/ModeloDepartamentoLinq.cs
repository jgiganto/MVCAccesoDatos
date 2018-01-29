using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAccesoDatos.Models
{
    public class ModeloDepartamentoLinq
    {
        ContextoDoctorDataContext contexto;
        public ModeloDepartamentoLinq()
        {
            contexto = new ContextoDoctorDataContext();
        }

        public List<DEPT> GetDepartamento()
        {
            var consulta = from datos in contexto.DEPTs
                           select datos;
            return consulta.ToList();

        }

        public DEPT BuscarDept(int Depno)
                    {
            var consulta = from datos in contexto.DEPTs
                           where datos.DEPT_NO == Depno
                           select datos;

            if (consulta.Count() == 0)
            {
                //hacemos algo 
                return null;
            }
            else
            {
                //2. delvolvemos el unico registro(el primero)
                return consulta.First();
            }


        }


    }
}