using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class ConjuntoServicioDAL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Total { get; set; }
        public int IdVehiculo { get; set; }
        public int IdEstacionamiento { get; set; }
        public int IdTour { get; set; }

        public ConjuntoServicioDAL() { }
        public ConjuntoServicioDAL(int id, string codigo, string nombre,int total, int idVehiculo, int idEstacionamiento, int idTour)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Total = total;
            this.IdVehiculo = idVehiculo;
            this.IdEstacionamiento = idEstacionamiento;
            this.IdTour = idTour;
        }
        public ConjuntoServicioDAL( string codigo, string nombre, int total, int idVehiculo, int idEstacionamiento, int idTour)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Total = total;
            this.IdVehiculo = idVehiculo;
            this.IdEstacionamiento = idEstacionamiento;
            this.IdTour = idTour;
        }

        public bool InsertConjunto(ConjuntoServicioDAL conjuntoServicioDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_conjunto", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_codigo", conjuntoServicioDAL.Codigo);
                cmd.Parameters.Add("v_nombre", conjuntoServicioDAL.Nombre);
                cmd.Parameters.Add("v_total", conjuntoServicioDAL.Total);
                cmd.Parameters.Add("v_id_vehiculo", conjuntoServicioDAL.IdVehiculo);
                cmd.Parameters.Add("v_id_estacionamiento", conjuntoServicioDAL.IdEstacionamiento);
                cmd.Parameters.Add("v_id_tour", conjuntoServicioDAL.IdTour);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar el conjunto");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }

        public bool DeleteConjunto(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_CONJUNTO", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el conjunto");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }
        public DataTable GetAllConjunto()
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_CONJUNTO,CODIGO,NOMBRE,TOTAL_PAGO_SERVICIOS, ID_VEHICULO,ID_ESTACIONAMIENTO,ID_TOUR FROM CONJUNTO_SERVICIO";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "CONJUNTO_SERVICIO");


                tabla = dataset.Tables["CONJUNTO_SERVICIO"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todos los conjuntos");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetConjuntoByNombre(string codigo)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_CONJUNTO, CODIGO, NOMBRE, TOTAL_PAGO_SERVICIOS, ID_VEHICULO, ID_ESTACIONAMIENTO, ID_TOUR FROM CONJUNTO_SERVICIO WHERE NOMBRE LIKE UPPER(:v_nombre || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_nombre", codigo);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "CONJUNTO_SERVICIO");

                tabla = dataSet.Tables["CONJUNTO_SERVICIO"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar conjunto por nombre");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

    }
}
