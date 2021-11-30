using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class EstacionamientoBLL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Zona { get; set; }
        public int Piso { get; set; }
        public int Precio { get; set; }

        public EstacionamientoBLL() { }
        public EstacionamientoBLL(int id, string codigo, string zona, int piso, int precio)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Zona = zona;
            this.Piso = piso;
            this.Precio = precio;
        }
        public EstacionamientoBLL(string codigo, string zona, int piso, int precio)
        {
            this.Codigo = codigo;
            this.Zona = zona;
            this.Piso = piso;
            this.Precio = precio;
        }
        public string InsertarEstacionamiento(string codigo, string zona, int piso, int precio)
        {
            EstacionamientoDAL estacionamientoDAL = new EstacionamientoDAL();
            EstacionamientoDAL objEstacionamiento = new EstacionamientoDAL(codigo, zona, piso, precio);

            bool insert = estacionamientoDAL.InsertEstacionamiento(objEstacionamiento);

            if (insert == true)
            {
                return "Estacionamiento registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string ActualizarEstacionamiento(int id, string codigo, string zona, int piso, int precio)
        {
            EstacionamientoDAL estacionamientoDAL = new EstacionamientoDAL();
            EstacionamientoDAL objEstacionamiento = new EstacionamientoDAL(id, codigo, zona, piso, precio);

            bool update = estacionamientoDAL.UpdateEstacionamiento(objEstacionamiento);

            if (update == true)
            {
                return "Estacionamiento actualizado";
            }
            else
            {
                return "Error al actualizar";
            }
        }

        public string EliminarEstacionamiento(int id)
        {
            EstacionamientoDAL estacionamientoDAL = new EstacionamientoDAL();

            bool delete = estacionamientoDAL.DeleteEstacionamiento(id);

            if (delete == true)
            {
                return "Estacionamiento Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<EstacionamientoBLL> TraerTodos()
        {
            EstacionamientoDAL estacionamientoData = new EstacionamientoDAL();
            DataTable tabla = estacionamientoData.GetAllEstacionamiento();
            List<EstacionamientoBLL> listEstacionamiento = new List<EstacionamientoBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["id_serv_estacionamiento"].ToString());
                string codigo = tabla.Rows[i]["codigo_estacionamiento"].ToString();
                string zona = tabla.Rows[i]["zona"].ToString();
                int piso = int.Parse(tabla.Rows[i]["piso"].ToString());
                int precio = int.Parse(tabla.Rows[i]["precio_estacionamiento"].ToString());

                EstacionamientoBLL objEstacionamiento = new EstacionamientoBLL();
                objEstacionamiento.Id = id;
                objEstacionamiento.Codigo = codigo;
                objEstacionamiento.Zona = zona;
                objEstacionamiento.Piso = piso;
                objEstacionamiento.Precio = precio;

                listEstacionamiento.Add(objEstacionamiento);
                i++;
            }
            return listEstacionamiento;
        }
        public List<EstacionamientoBLL> TraerPorZona(string zonaParam)
        {
            EstacionamientoDAL estacionamientoData = new EstacionamientoDAL();
            DataTable tabla = estacionamientoData.GetEstacionamientoByZona(zonaParam);
            List<EstacionamientoBLL> listEstacionamiento = new List<EstacionamientoBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["id_serv_estacionamiento"].ToString());
                string codigo = tabla.Rows[i]["codigo_estacionamiento"].ToString();
                string zona = tabla.Rows[i]["zona"].ToString();
                int piso = int.Parse(tabla.Rows[i]["piso"].ToString());
                int precio = int.Parse(tabla.Rows[i]["precio_estacionamiento"].ToString());

                EstacionamientoBLL objEstacionamiento = new EstacionamientoBLL();
                objEstacionamiento.Id = id;
                objEstacionamiento.Codigo = codigo;
                objEstacionamiento.Zona = zona;
                objEstacionamiento.Piso = piso;
                objEstacionamiento.Precio = precio;

                listEstacionamiento.Add(objEstacionamiento);
                i++;
            }
            return listEstacionamiento;
        }
    }
}
