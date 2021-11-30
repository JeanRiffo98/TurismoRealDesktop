using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class VehiculoTransporteDAL
    {
        public int Id { get; set; }
        public int Precio { get; set; }
        public string LugarCoordinacion { get; set; }
        public string Patente { get; set; }
        public string FechaHora { get; set; }
        public VehiculoTransporteDAL() { }
        public VehiculoTransporteDAL(int id, int precio, string lugarCoordinacion,string patente, string fechaHora)
        {
            this.Id = id;
            this.Precio = precio;
            this.LugarCoordinacion = lugarCoordinacion;
            this.Patente = patente;
            this.FechaHora = fechaHora;
        }
        public VehiculoTransporteDAL( int precio, string lugarCoordinacion, string patente, string fechaHora)
        {
            this.Precio = precio;
            this.LugarCoordinacion = lugarCoordinacion;
            this.Patente = patente;
            this.FechaHora = fechaHora;
        }

        public bool InsertVehiculoTransporte(VehiculoTransporteDAL vehiculoTransporteDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_vehiculo_transporte", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_precio", vehiculoTransporteDAL.Precio);
                cmd.Parameters.Add("v_lugar_coordinacion", vehiculoTransporteDAL.LugarCoordinacion);
                cmd.Parameters.Add("v_patente", vehiculoTransporteDAL.Patente);
                cmd.Parameters.Add("v_fecha_hora", vehiculoTransporteDAL.FechaHora);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar el vehículo");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }
        public bool UpdateVehiculo(VehiculoTransporteDAL vehiculoTransporteDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                cnx.Open();

                OracleCommand cmd = new OracleCommand("sp_update_vehiculo_transporte", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_id", vehiculoTransporteDAL.Id);
                cmd.Parameters.Add("v_precio", vehiculoTransporteDAL.Precio);
                cmd.Parameters.Add("v_lugar_coordinacion", vehiculoTransporteDAL.LugarCoordinacion);
                cmd.Parameters.Add("v_patente", vehiculoTransporteDAL.Patente);
                cmd.Parameters.Add("v_fecha_hora", vehiculoTransporteDAL.FechaHora);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el vehículo");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public bool DeleteVehiculo(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_VEHICULO_TRANSPORTE", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el vehículo");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }
        public DataTable GetAllVehiculo()
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_SERV_VEHICULO, PRECIO_TRANSPORTE, LUGAR_COORDINACION, PATENTE_VEHICULO,FECHA_HORA_COORDINACION FROM VEHICULO_TRANSPORTE";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "VEHICULO_TRANSPORTE");


                tabla = dataset.Tables["VEHICULO_TRANSPORTE"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todos los vehiculos");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetVehículoByLugar(string lugar)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_SERV_VEHICULO, PRECIO_TRANSPORTE,LUGAR_COORDINACION,PATENTE_VEHICULO,FECHA_HORA_COORDINACION FROM VEHICULO_TRANSPORTE WHERE LUGAR_COORDINACION LIKE UPPER(:v_lugar || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_lugar", lugar);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "VEHICULO_TRANSPORTE");

                tabla = dataSet.Tables["VEHICULO_TRANSPORTE"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar vehiculos por lugar");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
