using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class VehiculoTransporteBLL
    {
        public int Id { get; set; }
        public int Precio { get; set; }
        public string LugarCoordinacion { get; set; }
        public string Patente { get; set; }
        public string FechaHora { get; set; }
        public VehiculoTransporteBLL() { }
        public VehiculoTransporteBLL(int id, int precio, string lugarCoordinacion, string patente, string fechaHora)
        {
            this.Id = id;
            this.Precio = precio;
            this.LugarCoordinacion = lugarCoordinacion;
            this.Patente = patente;
            this.FechaHora = fechaHora;
        }
        public VehiculoTransporteBLL(int precio, string lugarCoordinacion, string patente, string fechaHora)
        {
            this.Precio = precio;
            this.LugarCoordinacion = lugarCoordinacion;
            this.Patente = patente;
            this.FechaHora = fechaHora;
        }

        public string InsertarVehiculo(int precio, string lugarCoordinacion, string patente, string fechaHora)
        {
            VehiculoTransporteDAL vehiculoTransporteDAL = new VehiculoTransporteDAL();
            VehiculoTransporteDAL objVehiculo = new VehiculoTransporteDAL(precio, lugarCoordinacion, patente, fechaHora);

            bool insert = vehiculoTransporteDAL.InsertVehiculoTransporte(objVehiculo);

            if (insert == true)
            {
                return "Vehiculo registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string ActualizarVehiculo(int id, int precio, string lugarCoordinacion, string patente, string fechaHora)
        {
            VehiculoTransporteDAL vehiculoTransporteDAL = new VehiculoTransporteDAL();
            VehiculoTransporteDAL objVehiculo = new VehiculoTransporteDAL(id, precio, lugarCoordinacion, patente, fechaHora);

            bool update = vehiculoTransporteDAL.UpdateVehiculo(objVehiculo);

            if (update == true)
            {
                return "Vehiculo actualizado";
            }
            else
            {
                return "Error al actualizar";
            }
        }

        public string EliminarVehiculo(int id)
        {
            VehiculoTransporteDAL vehiculoTransporteDAL = new VehiculoTransporteDAL();

            bool delete = vehiculoTransporteDAL.DeleteVehiculo(id);

            if (delete == true)
            {
                return "Vehiculo Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<VehiculoTransporteBLL> TraerTodos()
        {
            VehiculoTransporteDAL vehiculoData = new VehiculoTransporteDAL();
            DataTable tabla = vehiculoData.GetAllVehiculo();
            List<VehiculoTransporteBLL> listVehiculo = new List<VehiculoTransporteBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["id_serv_vehiculo"].ToString());
                int precio= int.Parse(tabla.Rows[i]["precio_transporte"].ToString());
                string lugar = tabla.Rows[i]["lugar_coordinacion"].ToString();
                string patente = tabla.Rows[i]["patente_vehiculo"].ToString();
                string fechaHora = tabla.Rows[i]["fecha_hora_coordinacion"].ToString();

                VehiculoTransporteBLL objVehiculo = new VehiculoTransporteBLL();
                objVehiculo.Id = id;
                objVehiculo.Precio = precio;
                objVehiculo.LugarCoordinacion = lugar;
                objVehiculo.Patente = patente;
                objVehiculo.FechaHora = fechaHora;

                listVehiculo.Add(objVehiculo);
                i++;
            }
            return listVehiculo;
        }
        public List<VehiculoTransporteBLL> TraerPorLugar(string lugarParam)
        {
            VehiculoTransporteDAL vehiculoData = new VehiculoTransporteDAL();
            DataTable tabla = vehiculoData.GetVehículoByLugar(lugarParam);
            List<VehiculoTransporteBLL> listaVehiculo = new List<VehiculoTransporteBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["id_serv_vehiculo"].ToString());
                int precio = int.Parse(tabla.Rows[i]["precio_transporte"].ToString());
                string lugar = tabla.Rows[i]["lugar_coordinacion"].ToString();
                string patente = tabla.Rows[i]["patente_vehiculo"].ToString();
                string fechaHora = tabla.Rows[i]["fecha_hora_coordinacion"].ToString();

                VehiculoTransporteBLL objVehiculo = new VehiculoTransporteBLL();

                objVehiculo.Id = id;
                objVehiculo.Precio = precio;
                objVehiculo.LugarCoordinacion = lugar;
                objVehiculo.Patente = patente;
                objVehiculo.FechaHora = fechaHora;

                listaVehiculo.Add(objVehiculo);
                i++;
            }
            return listaVehiculo;
        }
    }
}
