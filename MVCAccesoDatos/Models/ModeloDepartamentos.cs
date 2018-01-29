using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
#region procalmacenados
/*CREATE PROCEDURE CREARDEPARTAMENTO 
(@DEPNO INT,@DNOMBRE NVARCHAR(20),@LOC NVARCHAR(20))
AS 
INSERT INTO DEPT (DEPT_NO,DNOMBRE,LOC) VALUES(@DEPNO,@DNOMBRE,@LOC)
GO
CREATE PROCEDURE MODIFICARDEPARTAMENTO
(@DEPNO INT,@DEPNO2 INT,@DNOMBRE NVARCHAR(20),@LOC NVARCHAR(20))
AS
UPDATE DEPT SET DEPT_NO = @DEPNO2,DNOMBRE = @DNOMBRE,LOC = @LOC
WHERE DEPT_NO = @DEPNO 
GO

EXEC MODIFICARDEPARTAMENTO 77,80,'CINEASTAS','MARBELLA'
 */
#endregion
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
        public void EliminarDepartamento(int numerodel)
        {
            SqlParameter pamnum = new SqlParameter("@DEPTNO", numerodel);
            com.Parameters.Add(pamnum);
            com.CommandType = CommandType.Text;
            com.CommandText = "DELETE  FROM DEPT WHERE DEPT_NO = @DEPTNO";
            addept.SelectCommand = com;
            addept.Fill(ds, "DEPT");
            com.Parameters.Clear();            

        }


        public Departamento InsertarDepartamento(Departamento departamento)
        {
            SqlParameter pamnum = new SqlParameter("@DEPNO", departamento.numero);
            SqlParameter pamnom = new SqlParameter("@DNOMBRE", departamento.Nombre);
            SqlParameter pamloc = new SqlParameter("@LOC", departamento.Localidad);
            com.Parameters.Add(pamnum);
            com.Parameters.Add(pamnom);
            com.Parameters.Add(pamloc);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "CREARDEPARTAMENTO";
            addept.SelectCommand = com;
            if (ds.Tables.Contains("DEPARTAMENTOS"))
            {
                ds.Tables["DEPARTAMENTOS"].Rows.Clear();
            }
            addept.Fill(ds, "DEPARTAMENTOS");
            com.Parameters.Clear();
            return (departamento);

        }

        public Departamento ModificarDepartamento(Departamento departamento)
        {
            SqlParameter pamnum = new SqlParameter("@DEPNO", departamento.numero);
            SqlParameter pamnumnuevo = new SqlParameter("@DEPNO2", departamento.numeronuevo);
            SqlParameter pamnom = new SqlParameter("@DNOMBRE", departamento.Nombre);
            SqlParameter pamloc = new SqlParameter("@LOC", departamento.Localidad);
            com.Parameters.Add(pamloc);
            com.Parameters.Add(pamnom);
            com.Parameters.Add(pamnumnuevo);
            com.Parameters.Add(pamnum);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "MODIFICARDEPARTAMENTO";
            addept.SelectCommand = com;
            if (ds.Tables.Contains("DEPARTAMENTOS"))
            {
                ds.Tables["DEPARTAMENTOS"].Rows.Clear();
            }
            addept.Fill(ds, "DEPARTAMENTOS");
            com.Parameters.Clear();
            return (departamento);
        }
           
    }
}
/*DELETE  FROM DEPT
WHERE DEPT_NO = 120
 * 
 * (@DEPNO INT,@DEPNO2 INT,@DNOMBRE NVARCHAR(20),@LOC NVARCHAR(20))
 * SqlParameter pamhospcod = new SqlParameter("@HOSPITALCOD", hospitalcod);
            SqlParameter pamincremento = new SqlParameter("@INCREMENTO", incremento);
            this.com.Parameters.Add(pamhospcod);
            this.com.Parameters.Add(pamincremento);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "MODIFICARSALARIO";
            this.ademp.SelectCommand = this.com;
            if (this.ds.Tables.Contains("EMPLEADOS"))
            {
                this.ds.Tables["EMPLEADOS"].Rows.Clear();
            }
            this.ademp.Fill(this.ds, "EMPLEADOS");
            this.com.Parameters.Clear();
 @DEPNO,@DNOMBRE,@LOC*/
