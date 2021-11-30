using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace TurismoRealDesktopDAL
{
    public class PersonaDAL
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public PersonaDAL()
        {

        }


        public PersonaDAL(int id, string rut, string nombres, string apellidos, string telefono, string correo, string contraseña)
        {
            Id = id;
            Rut = rut;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Correo = correo;
            Contraseña = contraseña;
        }

        public PersonaDAL(string rut, string nombres, string apellidos,string telefono, string correo, string contraseña)
        {
            Rut = rut;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Correo = correo;
            Contraseña = contraseña;
        }

        public PersonaDAL(string rut, string nombres, string apellidos, string telefono, string correo)
        {
            Rut = rut;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Correo = correo;
        }

        public bool InsertPersona(PersonaDAL personaDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_persona", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_rut", personaDAL.Rut);
                cmd.Parameters.Add("v_nombres", personaDAL.Nombres);
                cmd.Parameters.Add("v_apellidos", personaDAL.Apellidos);
                cmd.Parameters.Add("v_telefono", personaDAL.Telefono);
                cmd.Parameters.Add("v_correo", personaDAL.Correo);
                cmd.Parameters.Add("v_contraseña", personaDAL.Contraseña);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;

            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar a la persona");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }

        //Metodo que Borra en la BD
        public bool DeletePersona(string rut)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_PERSONA", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_rut", rut);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar la persona");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        //Metodo que Selecciona todos los Clientes de la tabla Cliente
        public DataTable GetAllPersona()
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT ID_PERSONA, RUT, NOMBRES, APELLIDOS, TELEFONO,CORREO, CONTRASENIA FROM PERSONA";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement, cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "PERSONA");


                tabla = dataset.Tables["PERSONA"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todas las personas");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

        //Metodo que Selecciona Clientes segun Rut
        public DataTable GetPersonaByRut(string rut)
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_PERSONA,RUT,NOMBRES,APELLIDOS,TELEFONO,CORREO,CONTRASENIA FROM PERSONA WHERE RUT LIKE UPPER(:v_rut || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_rut", rut);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataset, "PERSONA");

                tabla = dataset.Tables["PERSONA"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar Personas por Rut");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

        public DataTable GetPersonaById(int id)
        {
            DataTable tabla = new DataTable();
            DataSet dataset = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT ID_PERSONA,RUT,NOMBRES,APELLIDOS,TELEFONO,CORREO,CONTRASENIA FROM PERSONA WHERE ID_PERSONA = :v_id";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("v_id", id);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataset, "PERSONA");

                tabla = dataset.Tables["PERSONA"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar Personas por Id");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }
    }
}
