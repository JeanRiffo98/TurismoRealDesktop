using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class MultaDAL
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public int IdCheckOut {get; set;}
        public string Codigo { get; set; }
        public string Estado { get; set; }

        public MultaDAL() { }
        public MultaDAL(int id, string descripcion, int costo, int idCheckOut, string codigo, string estado)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.IdCheckOut = idCheckOut;
            this.Codigo = codigo;
            this.Estado = estado;
        }
        public MultaDAL(string descripcion, int costo, int idCheckOut, string codigo, string estado)
        {
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.IdCheckOut = idCheckOut;
            this.Codigo = codigo;
            this.Estado = estado;
        }

        public bool InsertMulta(MultaDAL multaDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_multa", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_descripcion", multaDAL.Descripcion);
                cmd.Parameters.Add("v_costo", multaDAL.Costo);
                cmd.Parameters.Add("v_id_check_out", multaDAL.IdCheckOut);
                cmd.Parameters.Add("v_codigo", multaDAL.Codigo);
                cmd.Parameters.Add("v_estado", multaDAL.Estado);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar la multa");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }
        public bool DeleteMulta(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_MULTA", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar la multa");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }
        public DataTable GetAllMulta()
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_MULTA, DESCRIPCION,COSTO_MULTA, ID_CHECKOUT, CODIGO, ESTADO FROM MULTA";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "MULTA");


                tabla = dataset.Tables["MULTA"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todas las multas");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
        public DataTable GetMultaByIdCheckOutEstado(int idCheckOut,string estado)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_MULTA, DESCRIPCION,COSTO_MULTA, ID_CHECKOUT, CODIGO, ESTADO FROM MULTA WHERE ID_CHECKOUT = :v_id_check_out and ESTADO = :v_estado";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_id_check_out", idCheckOut);
                cmd.Parameters.Add("v_estado", estado);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet, "MULTA");

                tabla = dataSet.Tables["MULTA"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar las multas");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
