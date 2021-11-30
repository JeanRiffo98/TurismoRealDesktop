using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class TourDAL
    {
        public int Id { get; set; }
        public int Precio { get; set; }
        public string Lugar { get; set; }
        public string FechaHora { get; set; }
        public TourDAL() { }
        public TourDAL(int id, int precio, string lugar, string fechaHora)
        {
            this.Id = id;
            this.Precio = precio;
            this.Lugar = lugar;
            this.FechaHora = fechaHora;
        }
        public TourDAL(int precio, string lugar, string fechaHora)
        {
            this.Precio = precio;
            this.Lugar = lugar;
            this.FechaHora = fechaHora;
        }

        public bool InsertTour(TourDAL tourDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_tour", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_precio", tourDAL.Precio);
                cmd.Parameters.Add("v_lugar", tourDAL.Lugar);
                cmd.Parameters.Add("v_fecha_hora", tourDAL.FechaHora);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar el tour");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }
        public bool UpdateTour(TourDAL tourDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                cnx.Open();

                OracleCommand cmd = new OracleCommand("sp_update_tour", cnx);

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("v_id", tourDAL.Id);
                cmd.Parameters.Add("v_precio", tourDAL.Precio);
                cmd.Parameters.Add("v_lugar", tourDAL.Lugar);
                cmd.Parameters.Add("v_fecha_hora", tourDAL.FechaHora);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el tour");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public bool DeleteTour(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_TOUR", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el tour");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public DataTable GetAllTour()
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_SERV_TOUR, PRECIO_TOUR, LUGAR_COORDINACION,FECHA_HORA_COORDINACION FROM TOUR";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "TOUR");


                tabla = dataset.Tables["TOUR"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todos los tour");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetTourByLugar(string lugar)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_SERV_TOUR,PRECIO_TOUR,LUGAR_COORDINACION,FECHA_HORA_COORDINACION FROM TOUR WHERE LUGAR_COORDINACION LIKE UPPER(:v_lugar || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_lugar", lugar);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "TOUR");

                tabla = dataSet.Tables["TOUR"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar tour por lugar");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
