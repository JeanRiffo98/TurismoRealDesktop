using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class ReservaDAL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Precio { get; set; }
        public string FechaReserva { get; set; }
        public int CantNoches { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public int IdPersona { get; set; }
        public int IdConjunto { get; set; }
        public int IdDepto { get; set; }

        public ReservaDAL() { }

        public ReservaDAL(int id,string codigo, int precio, string fechaReserva, int cantNoches,  string fechaEntrada, string fechaSalida, int idPersona, int idConjunto, int idDepto)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Precio = precio;
            this.FechaReserva = fechaReserva;
            this.CantNoches = cantNoches;
            this.FechaEntrada = fechaEntrada;
            this.FechaSalida = fechaSalida;
            this.IdPersona = idPersona;
            this.IdConjunto = idConjunto;
            this.IdDepto = idDepto;
        }

        public ReservaDAL(string codigo,int precio, string fechaReserva, int cantNoches, string fechaEntrada, string fechaSalida, int idPersona, int idConjunto, int idDepto)
        {
            this.Precio = precio;
            this.Codigo = codigo;
            this.FechaReserva = fechaReserva;
            this.CantNoches = cantNoches;
            this.FechaEntrada = fechaEntrada;
            this.FechaSalida = fechaSalida;
            this.IdPersona = idPersona;
            this.IdConjunto = idConjunto;
            this.IdDepto = idDepto;
        }

        public bool InsertReserva(ReservaDAL reservaDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_reserva", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_codigo", reservaDAL.Codigo);
                cmd.Parameters.Add("v_precio", reservaDAL.Precio);
                cmd.Parameters.Add("v_fecha_reserva", reservaDAL.FechaReserva);
                cmd.Parameters.Add("v_cant_noches", reservaDAL.CantNoches);
                cmd.Parameters.Add("v_fecha_entrada", reservaDAL.FechaEntrada);
                cmd.Parameters.Add("v_fecha_salida", reservaDAL.FechaSalida);
                cmd.Parameters.Add("v_id_persona", reservaDAL.IdPersona);
                cmd.Parameters.Add("v_id_conjunto", reservaDAL.IdConjunto);
                cmd.Parameters.Add("v_id_depto", reservaDAL.IdDepto);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar la reserva");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }

        //Metodo que Actualiza en la BD
        public bool UpdateReserva(ReservaDAL reservaDAl)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                cnx.Open();

                OracleCommand cmd = new OracleCommand("sp_update_reserva", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_id", reservaDAl.Id);
                cmd.Parameters.Add("v_codigo", reservaDAl.Codigo);
                cmd.Parameters.Add("v_precio", reservaDAl.Precio);
                cmd.Parameters.Add("v_fecha_reserva", reservaDAl.FechaReserva);
                cmd.Parameters.Add("v_cant_noches", reservaDAl.CantNoches);
                cmd.Parameters.Add("v_fecha_entrada", reservaDAl.FechaEntrada);
                cmd.Parameters.Add("v_fecha_salida", reservaDAl.FechaSalida);
                cmd.Parameters.Add("v_id_persona", reservaDAl.IdPersona);
                cmd.Parameters.Add("v_id_conjunto", reservaDAl.IdConjunto);
                cmd.Parameters.Add("v_id_depto", reservaDAl.IdDepto);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar la reserva");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        //Metodo que Borra en la BD
        public bool DeleteReserva(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_RESERVA", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar la reserva");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        //Metodo que Selecciona todos los Clientes de la tabla Cliente
        public DataTable GetAllReserva()
        {
            DataSet dataset = new DataSet();
            DataTable tabla = new DataTable();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_RESERVA, CODIGO, PRECIO_RESERVA, FECHA_RESERVA, CANT_NOCHES,FECHA_ENTRADA,FECHA_SALIDA,PERSONA_ID, ID_CONJUNTO_SERV,DEPTO_ID_DEPTO FROM RESERVA";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "RESERVA");


                tabla = dataset.Tables["RESERVA"];

                //OracleCommand cmd = new OracleCommand(sqlStatement,cnxDB);
                //cmd.CommandType = CommandType.Text;



                //OracleDataAdapter dataAdapter = new OracleDataAdapter(cmd);

                //dataAdapter.Fill(tabla);
                //cnxDB.Close();

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todas las reservas");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

        //Metodo que Selecciona Clientes segun Rut
        public DataTable GetReservaByCodigo(string codigo)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_RESERVA, CODIGO, PRECIO_RESERVA, FECHA_RESERVA, CANT_NOCHES,FECHA_ENTRADA,FECHA_SALIDA,PERSONA_ID, ID_CONJUNTO_SERV,DEPTO_ID_DEPTO FROM RESERVA WHERE CODIGO LIKE UPPER(:v_codigo || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_codigo", codigo);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "RESERVA");

                tabla = dataSet.Tables["RESERVA"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar reservas por codigo");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetReservaByIdDepto(int idDepto)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_RESERVA, CODIGO, PRECIO_RESERVA, FECHA_RESERVA, CANT_NOCHES,FECHA_ENTRADA,FECHA_SALIDA,PERSONA_ID, ID_CONJUNTO_SERV,DEPTO_ID_DEPTO FROM RESERVA WHERE CODIGO LIKE UPPER(:v_id_depto || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_id_depto", idDepto);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "RESERVA");

                tabla = dataSet.Tables["RESERVA"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar reservas por id de departamento");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
