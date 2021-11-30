using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class EstacionamientoDAL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Zona { get; set; }
        public int Piso { get; set; }
        public int Precio { get; set; }

        public EstacionamientoDAL() { }
        public EstacionamientoDAL(int id, string codigo,string zona, int piso, int precio)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Zona = zona;
            this.Piso = piso;
            this.Precio = precio;
        }
        public EstacionamientoDAL( string codigo, string zona, int piso, int precio)
        {
            this.Codigo = codigo;
            this.Zona = zona;
            this.Piso = piso;
            this.Precio = precio;
        }

        public bool InsertEstacionamiento(EstacionamientoDAL estacionamientoDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_estacionamiento", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_codigo", estacionamientoDAL.Codigo);
                cmd.Parameters.Add("v_zona", estacionamientoDAL.Zona);
                cmd.Parameters.Add("v_piso", estacionamientoDAL.Piso);
                cmd.Parameters.Add("v_precio", estacionamientoDAL.Precio);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar el estacionamiento");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }
        public bool UpdateEstacionamiento(EstacionamientoDAL estacionamientoDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                cnx.Open();

                OracleCommand cmd = new OracleCommand("sp_update_estacionamiento", cnx);

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("v_id", estacionamientoDAL.Id);
                cmd.Parameters.Add("v_codigo", estacionamientoDAL.Codigo);
                cmd.Parameters.Add("v_zona", estacionamientoDAL.Zona);
                cmd.Parameters.Add("v_piso", estacionamientoDAL.Piso);
                cmd.Parameters.Add("v_precio", estacionamientoDAL.Precio);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el estacionamiento");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public bool DeleteEstacionamiento(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_ESTACIONAMIENTO", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el estacionamiento");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public DataTable GetAllEstacionamiento()
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_SERV_ESTACIONAMIENTO,CODIGO_ESTACIONAMIENTO,ZONA, PISO, PRECIO_ESTACIONAMIENTO FROM ESTACIONAMIENTO";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "ESTACIONAMIENTO");


                tabla = dataset.Tables["ESTACIONAMIENTO"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todos los estacionamientos");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetEstacionamientoByZona(string zona)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_SERV_ESTACIONAMIENTO, CODIGO_ESTACIONAMIENTO, ZONA, PRECIO_ESTACIONAMIENTO FROM ESTACIONAMIENTO WHERE ZONA LIKE UPPER(:v_zona || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_zona", zona);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "ESTACIONAMIENTO");

                tabla = dataSet.Tables["ESTACIONAMIENTO"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar estacionamientos por zona");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
