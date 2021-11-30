using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class ConjuntoServicioBLL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Total { get; set; }
        public int IdVehiculo { get; set; }
        public int IdEstacionamiento { get; set; }
        public int IdTour { get; set; }

        public ConjuntoServicioBLL() { }
        public ConjuntoServicioBLL(int id, string codigo, string nombre, int total, int idVehiculo, int idEstacionamiento, int idTour)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Total = total;
            this.IdVehiculo = idVehiculo;
            this.IdEstacionamiento = idEstacionamiento;
            this.IdTour = idTour;
        }
        public ConjuntoServicioBLL(string codigo, string nombre, int total, int idVehiculo, int idEstacionamiento, int idTour)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Total = total;
            this.IdVehiculo = idVehiculo;
            this.IdEstacionamiento = idEstacionamiento;
            this.IdTour = idTour;
        }

        public string InsertarConjunto(string codigo, string nombre, int total, int idVehiculo, int idEstacionamiento, int idTour)
        {
            ConjuntoServicioDAL conjuntoServicioDAL = new ConjuntoServicioDAL();
            ConjuntoServicioDAL objConjuntoServicioDAL = new ConjuntoServicioDAL(codigo, nombre, total, idVehiculo, idEstacionamiento,idTour);

            bool insert = conjuntoServicioDAL.InsertConjunto(objConjuntoServicioDAL);

            if (insert == true)
            {
                return "Conjunto registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string EliminarConjunto(int id)
        {
            ConjuntoServicioDAL conjuntoServicioDAL = new ConjuntoServicioDAL();

            bool delete = conjuntoServicioDAL.DeleteConjunto(id);

            if (delete == true)
            {
                return "Conjunto Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<ConjuntoServicioBLL> TraerTodos()
        {
            ConjuntoServicioDAL conjuntoData = new ConjuntoServicioDAL();
            DataTable tabla = conjuntoData.GetAllConjunto();
            List<ConjuntoServicioBLL> listConjunto = new List<ConjuntoServicioBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_conjunto"].ToString());
                string codigo = tabla.Rows[i]["codigo"].ToString();
                string nombre = tabla.Rows[i]["nombre"].ToString();
                int total = int.Parse(tabla.Rows[i]["total_pago_servicios"].ToString());
                int idVehiculo = int.Parse(tabla.Rows[i]["id_vehiculo"].ToString());
                int idEstacionamiento = int.Parse(tabla.Rows[i]["id_estacionamiento"].ToString());
                int idTour = int.Parse(tabla.Rows[i]["id_tour"].ToString());

                ConjuntoServicioBLL objConjunto = new ConjuntoServicioBLL();
                objConjunto.Id = id;
                objConjunto.Codigo = codigo;
                objConjunto.Nombre = nombre;
                objConjunto.Total = total;
                objConjunto.IdVehiculo = idVehiculo;
                objConjunto.IdEstacionamiento = idEstacionamiento;
                objConjunto.IdTour = idTour;

                listConjunto.Add(objConjunto);
                i++;
            }
            return listConjunto;
        }
        public List<ConjuntoServicioBLL> TraerPorNombre(string nombreParam)
        {
            ConjuntoServicioDAL conjuntoData = new ConjuntoServicioDAL();
            DataTable tabla = conjuntoData.GetConjuntoByNombre(nombreParam);
            List<ConjuntoServicioBLL> listConjunto = new List<ConjuntoServicioBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_conjunto"].ToString());
                string codigo = tabla.Rows[i]["codigo"].ToString();
                string nombre = tabla.Rows[i]["nombre"].ToString();
                int total = int.Parse(tabla.Rows[i]["total_pago_servicios"].ToString());
                int idVehiculo = int.Parse(tabla.Rows[i]["id_vehiculo"].ToString());
                int idEstacionamiento = int.Parse(tabla.Rows[i]["id_estacionamiento"].ToString());
                int idTour = int.Parse(tabla.Rows[i]["id_tour"].ToString());

                ConjuntoServicioBLL objConjunto = new ConjuntoServicioBLL();
                objConjunto.Id = id;
                objConjunto.Codigo = codigo;
                objConjunto.Nombre = nombre;
                objConjunto.Total = total;
                objConjunto.IdVehiculo = idVehiculo;
                objConjunto.IdEstacionamiento = idEstacionamiento;
                objConjunto.IdTour = idTour;

                listConjunto.Add(objConjunto);
                i++;
            }
            return listConjunto;
        }

    }
}
