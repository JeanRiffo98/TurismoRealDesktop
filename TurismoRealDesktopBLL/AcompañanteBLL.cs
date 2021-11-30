using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class AcompañanteBLL
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdReserva { get; set; }

        public AcompañanteBLL() { }

        public AcompañanteBLL(int id, string rut, string nombres, string apellidos, int idReserva)
        {
            this.Id = id;
            this.Rut = rut;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.IdReserva = idReserva;
        }
        public AcompañanteBLL(string rut, string nombres, string apellidos, int idReserva)
        {
            this.Rut = rut;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.IdReserva = idReserva;
        }

        //Método para Insertar Clientes
        public string InsertarAcompañante(string rut, string nombres, string apellidos, int idReserva)
        {
            AcompañanteDAL acompañanteDAL = new AcompañanteDAL();
            AcompañanteDAL objAcompañanteDAL = new AcompañanteDAL(rut, nombres, apellidos, idReserva);

            bool insert = acompañanteDAL.InsertAcompañante(objAcompañanteDAL);

            if (insert == true)
            {
                return "Acompañante registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string EliminarAcompañante(string rut, int idReserva)
        {
            AcompañanteDAL acompañanteDAL = new AcompañanteDAL();

            bool delete = acompañanteDAL.DeleteAcompañante(rut, idReserva);

            if (delete == true)
            {
                return "Acompañante Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }


        public List<AcompañanteBLL> TraerPorIdReserva(int idParam)
        {
            AcompañanteDAL acompañanteData = new AcompañanteDAL();
            DataTable tabla = acompañanteData.GetAcompañanteByIdReserva(idParam);
            List<AcompañanteBLL> listAcompañante = new List<AcompañanteBLL>();

            int i = 0;
            while (i<tabla.Rows.Count)
            {
                AcompañanteBLL objAcompañante = new AcompañanteBLL();

                int id = int.Parse(tabla.Rows[i]["Id_Acompaniante"].ToString());
                string rut = tabla.Rows[i]["Rut"].ToString();
                string nombres = tabla.Rows[i]["Nombres"].ToString();
                string apellidos = tabla.Rows[i]["Apellidos"].ToString();
                int idReserva = int.Parse(tabla.Rows[i]["Id_Reserva"].ToString());

                objAcompañante.Id = id;
                objAcompañante.Rut = rut;
                objAcompañante.Nombres = nombres;
                objAcompañante.Apellidos = apellidos;
                objAcompañante.IdReserva = idReserva;

                listAcompañante.Add(objAcompañante);
                i++;
            }
            return listAcompañante;
        }
    }
}
