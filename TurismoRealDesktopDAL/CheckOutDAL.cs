using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class CheckOutDAL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public byte[] Firma { get; set; }
        public string Fecha { get; set; }
        public int IdPersona { get; set; }
        public string Llaves { get; set; }

        public CheckOutDAL() { }
        public CheckOutDAL(int id, string codigo, byte[] firma, string fecha, int idPersona, string llaves)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Firma = firma;
            this.Fecha = fecha;
            this.IdPersona = idPersona;
            this.Llaves = llaves;
        }

        public CheckOutDAL(string codigo, byte[] firma, string fecha, int idPersona, string llaves)
        {
            this.Codigo = codigo;
            this.Firma = firma;
            this.Fecha = fecha;
            this.IdPersona = idPersona;
            this.Llaves = llaves;
        }

        public bool InsertCheckOut(CheckOutDAL checkOutDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_check_out", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_codigo", checkOutDAL.Codigo);
                cmd.Parameters.Add("v_firma", checkOutDAL.Firma);
                cmd.Parameters.Add("v_fecha", checkOutDAL.Fecha);
                cmd.Parameters.Add("v_id_persona", checkOutDAL.IdPersona);
                cmd.Parameters.Add("v_llaves", checkOutDAL.Llaves);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar el check out");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }
        public bool DeleteCheckOut(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_CHECK_OUT", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el check out");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }
        public DataTable GetAllCheckOut()
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_CHECKOUT, FIRMA_CLIENTE,FECHA_CHECKOUT, PERSONA_ID, LLAVES, CODIGO FROM CHECK_OUT";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "CHECK_OUT");


                tabla = dataset.Tables["CHECK_OUT"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todos los check out");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetCheckOutByCodigo(string codigo)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_CHECKOUT, FIRMA_CLIENTE,FECHA_CHECKOUT, PERSONA_ID, LLAVES, CODIGO FROM CHECK_OUT WHERE CODIGO LIKE UPPER(:v_codigo)";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_codigo", codigo);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "CHECK_OUT");

                tabla = dataSet.Tables["CHECK_OUT"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar check out por codigo");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
