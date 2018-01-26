using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVCAccesoDatos.Models
{
    public class ModeloDepartamentos
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataAdapter addept;
        DataSet ds;

        public ModeloDepartamentos()
        {
            cadenaconexion =
            ConfigurationManager.ConnectionStrings["tajamar"].ConnectionString;
            cn = new SqlConnection(cadenaconexion);
            com.Connection = cn;
            com = new SqlCommand();
            addept = new SqlDataAdapter();
            ds = new DataSet();
        }

        public List<Departamento> GetDepartamentos()
        {
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT * FROM DEPT";
            this.addept.SelectCommand = com;
            this.addept.Fill(ds, "DEPT");
            List<Departamento> lista = new List<Departamento>();
            foreach(DataRow fila in ds.Tables["DEPT"].Rows)
            {
                Departamento dept = new Departamento();
                dept.numero = int.Parse(fila["DEPT_NO"].ToString());
                dept.Nombre = fila["DNOMBRE"].ToString();
                dept.Localidad = fila["LOC"].ToString();
                lista.Add(dept);
            }
            return lista;
        }

           
    }
}