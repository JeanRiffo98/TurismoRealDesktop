using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealDesktopDAL
{
    public class ImagenDAL
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public int IdDepto { get; set; }

        public ImagenDAL() { }

        public ImagenDAL(int id, byte[] imagen, int idDepto)
        {
            this.Id = id;
            this.Imagen = imagen;
            this.IdDepto = idDepto;
        }
        public ImagenDAL(byte[] imagen, int idDepto)
        {
            this.Imagen = imagen;
            this.IdDepto = idDepto;
        }

        public bool InsertImagen(ImagenDAL imagenDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_img", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_imagen", imagenDAL.Imagen);
                cmd.Parameters.Add("v_id_depto", imagenDAL.IdDepto);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar la imagen");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }


        public bool DeleteImagen(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_IMG", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar la imagen");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }


        public DataTable GetAllImagen()
        {
            DataSet dataset = new DataSet();
            DataTable tabla = new DataTable();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_IMAGEN, IMAGEN, DEPTO_ID_DEPTO FROM IMAGEN";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "IMAGEN");


                tabla = dataset.Tables["IMAGEN"];

                //OracleCommand cmd = new OracleCommand(sqlStatement,cnxDB);
                //cmd.CommandType = CommandType.Text;



                //OracleDataAdapter dataAdapter = new OracleDataAdapter(cmd);

                //dataAdapter.Fill(tabla);
                //cnxDB.Close();

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todas las imagenes");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

    }
}
