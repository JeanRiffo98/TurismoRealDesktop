using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class InventarioDAL
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public string FechaIngreso { get; set; }
        public int CostoIndividual { get; set; }
        public int CostoTotal { get; set; }
        public int IdDepto { get; set; }

        public InventarioDAL() { }
        public InventarioDAL(int id, string nombre, string descripcion, string codigo, int cantidad, string fechaIngreso, int costoIndividual, int costoTotal, int idDepto)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.Cantidad = cantidad;
            this.FechaIngreso = fechaIngreso;
            this.CostoIndividual = costoIndividual;
            this.CostoTotal = costoTotal;
            this.IdDepto = idDepto;
        }

        public InventarioDAL(string nombre, string descripcion, string codigo, int cantidad, string fechaIngreso, int costoIndividual, int costoTotal, int idDepto)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.Cantidad = cantidad;
            this.FechaIngreso = fechaIngreso;
            this.CostoIndividual = costoIndividual;
            this.CostoTotal = costoTotal;
            this.IdDepto = idDepto;
        }

        public bool InsertObjeto(InventarioDAL inventarioDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_objeto", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_nombre", inventarioDAL.Nombre);
                cmd.Parameters.Add("v_descripcion", inventarioDAL.Descripcion);
                cmd.Parameters.Add("v_codigo", inventarioDAL.Codigo);
                cmd.Parameters.Add("v_cantidad", inventarioDAL.Cantidad);
                cmd.Parameters.Add("v_fecha_ingreso", inventarioDAL.FechaIngreso);
                cmd.Parameters.Add("v_costo_individual", inventarioDAL.CostoIndividual);
                cmd.Parameters.Add("v_costo_total", inventarioDAL.CostoTotal);
                cmd.Parameters.Add("v_id_depto", inventarioDAL.IdDepto);


                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar el objeto");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }

        public bool UpdateObjeto(InventarioDAL inventarioDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                cnx.Open();

                OracleCommand cmd = new OracleCommand("sp_update_objeto", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_id", inventarioDAL.Id);
                cmd.Parameters.Add("v_nombre", inventarioDAL.Nombre);
                cmd.Parameters.Add("v_descripcion", inventarioDAL.Descripcion);
                cmd.Parameters.Add("v_codigo", inventarioDAL.Codigo);
                cmd.Parameters.Add("v_cantidad", inventarioDAL.Cantidad);
                cmd.Parameters.Add("v_fecha_ingreso", inventarioDAL.FechaIngreso);
                cmd.Parameters.Add("v_costo_individual", inventarioDAL.CostoIndividual);
                cmd.Parameters.Add("v_costo_total", inventarioDAL.CostoTotal);
                cmd.Parameters.Add("v_id_depto", inventarioDAL.IdDepto);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el objeto");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        //Metodo que Borra en la BD
        public bool DeleteObjeto(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_OBJETO", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el objeto");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public DataTable GetObjetoByNombre(string nombre)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_OBJETO, NOMBRE, DESCRIPCION,CODIGO, CANTIDAD, FECHA_INGRESO, COSTO_INDIVIDUAL, COSTO_TOTAL, DEPTO_ID_DEPTO FROM OBJETO WHERE NOMBRE LIKE UPPER(:v_nombre || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_nombre", nombre);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "OBJETO");

                tabla = dataSet.Tables["OBJETO"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar objetos por nombre");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetObjetoByIdDepto(int idDepto)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_OBJETO, NOMBRE, DESCRIPCION,CODIGO, CANTIDAD, FECHA_INGRESO, COSTO_INDIVIDUAL, COSTO_TOTAL, DEPTO_ID_DEPTO FROM OBJETO WHERE DEPTO_ID_DEPTO LIKE UPPER(:v_idDepto || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_idDepto", idDepto);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "OBJETO");

                tabla = dataSet.Tables["OBJETO"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar objetos por id de departamento");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
