using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class AcompañanteDAL
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdReserva { get; set; }

        public AcompañanteDAL() { }

        public AcompañanteDAL(int id, string rut, string nombres, string apellidos, int idReserva)
        {
            this.Id = id;
            this.Rut = rut;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.IdReserva = idReserva;
        }
        public AcompañanteDAL( string rut, string nombres, string apellidos, int idReserva)
        {
            this.Rut = rut;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.IdReserva = idReserva;
        }

        public bool InsertAcompañante(AcompañanteDAL acompañanteDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_acompañante", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_rut", acompañanteDAL.Rut);
                cmd.Parameters.Add("v_nombres", acompañanteDAL.Nombres);
                cmd.Parameters.Add("v_apellidos", acompañanteDAL.Apellidos);
                cmd.Parameters.Add("v_id_reserva", acompañanteDAL.IdReserva);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar al acompañante");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }

        //Metodo que Borra en la BD
        public bool DeleteAcompañante(string rut, int idReserva)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_ACOMPAÑANTE", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_rut", rut);
                sqlCommand.Parameters.Add("v_id_reserva", idReserva);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar al acompañante");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        //Metodo que Selecciona Clientes segun Rut
        public DataTable GetAcompañanteByIdReserva(int idReserva)
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_ACOMPANIANTE, RUT, NOMBRES,APELLIDOS,ID_RESERVA FROM ACOMPAÑANTE WHERE ID_RESERVA = :v_id_reserva";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_id_reserva", idReserva);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataset, "ACOMPAÑANTE");

                tabla = dataset.Tables["ACOMPAÑANTE"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar acompañantes por Id de Reserva");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

    }
}
