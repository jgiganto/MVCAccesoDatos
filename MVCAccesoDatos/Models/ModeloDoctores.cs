using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVCAccesoDatos.Models
{
    public class ModeloDoctores
    {
        String cadenaconexion;
        SqlCommand com;
        SqlConnection cn;
        DataSet ds;
        SqlDataAdapter addoc;
        
        public ModeloDoctores()
        {
            cadenaconexion = ConfigurationManager.ConnectionStrings["casa"].ConnectionString;
            com = new SqlCommand();
            cn = new SqlConnection(cadenaconexion);
            com.Connection = cn;
            addoc = new SqlDataAdapter();
            ds = new DataSet();
        }

        public List<Doctores> GetDoctores()
        {
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT * FROM DOCTOR";
            addoc.SelectCommand = com;
            addoc.Fill(this.ds, "DOCTORES");
            List<Doctores> lista = new List<Doctores>();
            foreach(DataRow f in this.ds.Tables["DOCTORES"].Rows)
            {
                Doctores doc = new Doctores();
                doc.Apellido = f["APELLIDO"].ToString();
                doc.Doctorno = f["DOCTOR_NO"].ToString();
                lista.Add(doc);
            }
            return lista;            
        }

        public Doctores BuscarDoctor(String doccod)
        {
            SqlParameter pamdoc = new SqlParameter("@PAMDOC", doccod);
            com.Parameters.Add(pamdoc);
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR_NO = @PAMDOC";
            addoc.SelectCommand = com;
            addoc.Fill(this.ds,"DOCTOR");
            DataRow fila = ds.Tables["DOCTOR"].Rows[0];
            Doctores doc = new Doctores();
            doc.Apellido = fila["APELLIDO"].ToString();
            doc.Especialidad = fila["ESPECIALIDAD"].ToString();
            doc.Salario = int.Parse(fila["SALARIO"].ToString());

            return doc;
        }
    }
}

/*
HOSPITAL_COD
DOCTOR_NO
APELLIDO
ESPECIALIDAD
SALARIO int
*/
