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
            this.cadenaconexion =
            ConfigurationManager.ConnectionStrings["tajamar"].ConnectionString;
            this.com = new SqlCommand();
            this.cn = new SqlConnection(this.cadenaconexion);
            this.com.Connection = this.cn;
            this.addept = new SqlDataAdapter();
            this.ds = new DataSet();
        }

        public List<Departamento> GetDepartamentos()
        {
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = "SELECT * FROM DEPT";
            this.addept.SelectCommand = this.com;
            this.addept.Fill(this.ds,"DEPT");
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

        public Departamento BuscarDepartamento(int numero)
        {
            SqlParameter pamnum = new SqlParameter("@DEPTNO",numero);
            com.Parameters.Add(pamnum);
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT * FROM DEPT WHERE DEPT_NO=@DEPTNO";
            addept.SelectCommand = com;
            addept.Fill(ds, "DEPT");
            DataRow fila = ds.Tables["DEPT"].Rows[0];
            Departamento dept = new Departamento();
            dept.numero = int.Parse(fila["DEPT_NO"].ToString());
            dept.Nombre = fila["DNOMBRE"].ToString();
            dept.Localidad = fila["LOC"].ToString();
            return dept;

        }

           
    }
}