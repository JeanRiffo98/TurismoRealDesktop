using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class MantencionDAL
    {
        public int Id { get; set; }
        public string EnMantencion { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int Costo { get; set; }
        public int IdDepto { get; set; }

        public MantencionDAL() { }
        public MantencionDAL(int id, string enMantencion, string codigo,string descripcion, string fechaInicio, string fechaFin, int costo, int idDepto)
        {
            this.Id = id;
            this.EnMantencion = enMantencion;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Costo = costo;
            this.IdDepto = idDepto;
        }
        public MantencionDAL(string enMantencion, string codigo,string descripcion, string fechaInicio, string fechaFin, int costo, int idDepto) 
        {
            this.EnMantencion = enMantencion;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Costo = costo;
            this.IdDepto = idDepto;
        }

        public bool InsertMantencion(MantencionDAL mantencionDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_mantencion", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_enMantencion", mantencionDAL.EnMantencion);
                cmd.Parameters.Add("v_codigo", mantencionDAL.Codigo);
                cmd.Parameters.Add("v_descripcion", mantencionDAL.Descripcion);
                cmd.Parameters.Add("v_fechaInicio", mantencionDAL.FechaInicio);
                cmd.Parameters.Add("v_fechaFin", mantencionDAL.FechaFin);
                cmd.Parameters.Add("v_costo", mantencionDAL.Costo);
                cmd.Parameters.Add("v_idDepto", mantencionDAL.IdDepto);


                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar la mantención");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }

        //Metodo que Actualiza en la BD
        public bool UpdateMantencion(MantencionDAL mantencionDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                cnx.Open();

                OracleCommand cmd = new OracleCommand("sp_update_mantencion", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_id", mantencionDAL.Id);
                cmd.Parameters.Add("v_enMantencion", mantencionDAL.EnMantencion);
                cmd.Parameters.Add("v_codigo", mantencionDAL.Codigo);
                cmd.Parameters.Add("v_descripcion", mantencionDAL.Descripcion);
                cmd.Parameters.Add("v_fechaInicio", mantencionDAL.FechaInicio);
                cmd.Parameters.Add("v_fechaFin", mantencionDAL.FechaFin);
                cmd.Parameters.Add("v_costo", mantencionDAL.Costo);
                cmd.Parameters.Add("v_idDepto", mantencionDAL.IdDepto);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar la mantencion");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public bool DeleteMantencion(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_MANTENCION", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar la mantencion");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }
        public DataTable GetMantencionByCodigo(string codigo)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_MANTENCION, EN_MANTENCION, CODIGO, DESC_MANTENCION, FECHA_INICIO, FECHA_FIN, COSTO_MANTENCION, DEPTO_ID_DEPTO FROM MANTENCION WHERE CODIGO LIKE UPPER(:v_codigo || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_codigo", codigo);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "MANTENCION");

                tabla = dataSet.Tables["MANTENCION"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar mantenciones por código");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetMantencionByIdDepto(int idDepto)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_MANTENCION, EN_MANTENCION, CODIGO, DESC_MANTENCION, FECHA_INICIO, FECHA_FIN, COSTO_MANTENCION, DEPTO_ID_DEPTO FROM MANTENCION WHERE DEPTO_ID_DEPTO LIKE UPPER(:v_idDepto || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_idDepto", idDepto);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "MANTENCION");

                tabla = dataSet.Tables["MANTENCION"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar mantenciones por id de departamento");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }


    }
}
