using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurismoRealDesktopDAL
{
    public class DepartamentoDAL
    {
        public int Id { get; set; }
        public int Habitaciones { get; set; }
        public int Baños { get; set; }
        public string Wifi { get; set; }
        public int PrecioNoche { get; set; }
        public string FechaPublicacion { get; set; }
        public string FechaAdquisicion { get; set; }
        public string Disponibilidad { get; set; }
        public string Titulo { get; set; }
        public string Television { get; set; }
        public string Descripcion { get; set; }
        public int CantPersonasMax { get; set; }
        public string Direccion { get; set; }
        public int NroDepto { get; set; }
        public int CantCamas { get; set; }
        public string ZonaDepto { get; set; }


        public DepartamentoDAL() { }

        public DepartamentoDAL(int habitaciones, int baños, string wifi, int precioNoche, string fechaPublicacion, string fechaAdquisicion,string disponibilidad, string titulo,string television, string descripcion, 
                                int cantPersonasMax, string direccion, int nroDepto, int cantCamas, string zonaDepto)
        {
            Habitaciones = habitaciones;
            Baños = baños;
            Wifi = wifi;
            PrecioNoche = precioNoche;
            FechaPublicacion = fechaPublicacion;
            FechaAdquisicion = fechaAdquisicion;
            Disponibilidad = disponibilidad;
            Titulo = titulo;
            Television = television;
            Descripcion = descripcion;
            CantPersonasMax = cantPersonasMax;
            Direccion = direccion;
            NroDepto = nroDepto;
            CantCamas = cantCamas;
            ZonaDepto = zonaDepto;
        }
        public DepartamentoDAL(int id, int habitaciones, int baños, string wifi, int precioNoche, string fechaPublicacion, string fechaAdquisicion, string disponibilidad, string titulo, string television, string descripcion,
                                int cantPersonasMax, string direccion, int nroDepto, int cantCamas, string zonaDepto)
        {
            Id = id;
            Habitaciones = habitaciones;
            Baños = baños;
            Wifi = wifi;
            PrecioNoche = precioNoche;
            FechaPublicacion = fechaPublicacion;
            FechaAdquisicion = fechaAdquisicion;
            Disponibilidad = disponibilidad;
            Titulo = titulo;
            Television = television;
            Descripcion = descripcion;
            CantPersonasMax = cantPersonasMax;
            Direccion = direccion;
            NroDepto = nroDepto;
            CantCamas = cantCamas;
            ZonaDepto = zonaDepto;
        }

        public bool InsertDepartamento(DepartamentoDAL departamentoDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                OracleCommand cmd = new OracleCommand("sp_insert_depto",cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("habitaciones", departamentoDAL.Habitaciones);
                cmd.Parameters.Add("banios", departamentoDAL.Baños);
                cmd.Parameters.Add("wifi", departamentoDAL.Wifi);
                cmd.Parameters.Add("precioNoche", departamentoDAL.PrecioNoche);
                cmd.Parameters.Add("fecha_Publicacion", departamentoDAL.FechaPublicacion);
                cmd.Parameters.Add("fecha_Adquisicion", departamentoDAL.FechaAdquisicion);
                cmd.Parameters.Add("disponibilidad", departamentoDAL.Disponibilidad);
                cmd.Parameters.Add("titulo", departamentoDAL.Titulo);
                cmd.Parameters.Add("television", departamentoDAL.Television);
                cmd.Parameters.Add("descripcion", departamentoDAL.Descripcion);
                cmd.Parameters.Add("cantPersonasMax", departamentoDAL.CantPersonasMax);
                cmd.Parameters.Add("direccion", departamentoDAL.Direccion);
                cmd.Parameters.Add("nro_Depto", departamentoDAL.NroDepto);
                cmd.Parameters.Add("cant_Camas", departamentoDAL.CantCamas);
                cmd.Parameters.Add("zona_Depto", departamentoDAL.ZonaDepto);


                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (OracleException e)
            {
                Console.WriteLine("Error al registrar el departamento");
                Console.WriteLine("Detalle del error: " + e.Message);

                return false;
            }
        }

        public bool UpdateDepartamento(DepartamentoDAL departamentoDAL)
        {
            try
            {
                OracleConnection cnx = ConnectionDB.Connection;

                cnx.Open();

                OracleCommand cmd = new OracleCommand("sp_update_depto", cnx);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_id_depto", departamentoDAL.Id);
                cmd.Parameters.Add("v_habitaciones", departamentoDAL.Habitaciones);
                cmd.Parameters.Add("v_baños", departamentoDAL.Baños);
                cmd.Parameters.Add("v_wifi", departamentoDAL.Wifi);
                cmd.Parameters.Add("v_precioNoche", departamentoDAL.PrecioNoche);
                cmd.Parameters.Add("v_fechaPublicacion", departamentoDAL.FechaPublicacion);
                cmd.Parameters.Add("v_fechaAdquisicion", departamentoDAL.FechaAdquisicion);
                cmd.Parameters.Add("v_disponibilidad", departamentoDAL.Disponibilidad);
                cmd.Parameters.Add("v_titulo", departamentoDAL.Titulo);
                cmd.Parameters.Add("v_descripcion", departamentoDAL.Descripcion);
                cmd.Parameters.Add("v_television", departamentoDAL.Television);
                cmd.Parameters.Add("v_cantPersonasMax", departamentoDAL.CantPersonasMax);
                cmd.Parameters.Add("v_direccion", departamentoDAL.Direccion);
                cmd.Parameters.Add("v_nroDepto", departamentoDAL.NroDepto);
                cmd.Parameters.Add("v_cantCamas", departamentoDAL.CantCamas);
                cmd.Parameters.Add("v_zonaDepto", departamentoDAL.ZonaDepto);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar el departamento");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public bool DeleteDepartamento(int id)
        {
            try
            {
                OracleConnection sqlConnection = ConnectionDB.Connection;

                sqlConnection.Open();

                OracleCommand sqlCommand = new OracleCommand("SP_DELETE_DEPTO", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("v_id_depto", id);

                OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar el departamento");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return false;
            }
        }

        public DataTable GetAllDepartamento()
        {
            DataSet dataset = new DataSet();
            DataTable tabla = new DataTable();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sqlStatement = "SELECT id_depto,habitaciones,banios,wifi,precio_nochedepto,fecha_publicacion, fecha_adquisicion, disponibilidad, titulo, descripcion, television, cant_personasmax,direccion,nro_depto,cant_camas,zona_depto FROM Departamento";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlStatement,cnxDB);

                OracleCommandBuilder builder = new OracleCommandBuilder(oracleDataAdapter);

                oracleDataAdapter.Fill(dataset, "DEPARTAMENTO");

                tabla = dataset.Tables["DEPARTAMENTO"];

                //OracleCommand cmd = new OracleCommand(sqlStatement,cnxDB);
                //cmd.CommandType = CommandType.Text;

                //OracleDataAdapter dataAdapter = new OracleDataAdapter(cmd);

                //dataAdapter.Fill(tabla);
                //cnxDB.Close();

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al traer todos los departamentos");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

        public DataTable GetDepartamentoByTitulo(string titulo)
        {
            DataTable tabla = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection cnxDB = ConnectionDB.Connection;

                string sentenciaSql = "SELECT id_depto,habitaciones,banios,wifi,precio_nochedepto,fecha_publicacion, fecha_adquisicion, disponibilidad, titulo, descripcion, television, cant_personasmax,direccion,nro_depto,cant_camas,zona_depto FROM Departamento where titulo LIKE UPPER(:titulo || '%')";

                OracleCommand cmd = new OracleCommand(sentenciaSql, cnxDB);
                cmd.BindByName = true;

                cmd.Parameters.Add("titulo", titulo);

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);

                oracleDataAdapter.Fill(dataSet,"DEPARTAMENTO");

                tabla = dataSet.Tables["DEPARTAMENTO"];

                return tabla;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar Departamentos por Nombre");
                Console.WriteLine("Detalle de Error :   " + e.Message);
                return tabla;
            }
        }

    }
}
