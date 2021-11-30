using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class TourBLL
    {
        public int Id { get; set; }
        public int Precio { get; set; }
        public string Lugar { get; set; }
        public string FechaHora { get; set; }
        public TourBLL() { }
        public TourBLL(int id, int precio, string lugar, string fechaHora)
        {
            this.Id = id;
            this.Precio = precio;
            this.Lugar = lugar;
            this.FechaHora = fechaHora;
        }
        public TourBLL(int precio, string lugar, string fechaHora)
        {
            this.Precio = precio;
            this.Lugar = lugar;
            this.FechaHora = fechaHora;
        }
        public string InsertarTour(int precio, string lugar, string fechaHora)
        {
            TourDAL tourDAL = new TourDAL();
            TourDAL objTour = new TourDAL(precio, lugar, fechaHora);

            bool insert = tourDAL.InsertTour(objTour);

            if (insert == true)
            {
                return "Tour registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string ActualizarTour(int id, int precio, string lugar, string fechaHora)
        {
            TourDAL tourDAL = new TourDAL();
            TourDAL objTour = new TourDAL(id, precio, lugar, fechaHora);

            bool update = tourDAL.UpdateTour(objTour);

            if (update == true)
            {
                return "Tour actualizado";
            }
            else
            {
                return "Error al actualizar";
            }
        }

        public string EliminarTour(int id)
        {
            TourDAL tourDAL = new TourDAL();

            bool delete = tourDAL.DeleteTour(id);

            if (delete == true)
            {
                return "Tour Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<TourBLL> TraerTodos()
        {
            TourDAL tourData = new TourDAL();
            DataTable tabla = tourData.GetAllTour();
            List<TourBLL> listTour = new List<TourBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["ID_SERV_TOUR"].ToString());
                int precio = int.Parse(tabla.Rows[i]["PRECIO_TOUR"].ToString());
                string lugar = tabla.Rows[i]["LUGAR_COORDINACION"].ToString();
                string fechaHora = tabla.Rows[i]["FECHA_HORA_COORDINACION"].ToString();

                TourBLL objTour = new TourBLL();
                objTour.Id = id;
                objTour.Precio = precio;
                objTour.Lugar = lugar;
                objTour.FechaHora = fechaHora;

                listTour.Add(objTour);
                i++;
            }
            return listTour;
        }
        public List<TourBLL> TraerPorLugar(string lugarParam)
        {
            TourDAL tourData = new TourDAL();
            DataTable tabla = tourData.GetTourByLugar(lugarParam);
            List<TourBLL> listTour = new List<TourBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["ID_SERV_TOUR"].ToString());
                int precio = int.Parse(tabla.Rows[i]["PRECIO_TOUR"].ToString());
                string lugar = tabla.Rows[i]["LUGAR_COORDINACION"].ToString();
                string fechaHora = tabla.Rows[i]["FECHA_HORA_COORDINACION"].ToString();

                TourBLL objTour = new TourBLL();
                objTour.Id = id;
                objTour.Precio = precio;
                objTour.Lugar = lugar;
                objTour.FechaHora = fechaHora;

                listTour.Add(objTour);
                i++;
            }
            return listTour;
        }
    }
}
