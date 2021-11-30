using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class ReservaBLL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Precio { get; set; }
        public string FechaReserva { get; set; }
        public int CantNoches { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public int IdPersona { get; set; }
        public int IdConjunto { get; set; }
        public int IdDepto { get; set; }

        public ReservaBLL() { }

        public ReservaBLL(int id, string codigo,int precio, string fechaReserva, int cantNoches,  string fechaEntrada, string fechaSalida, int idPersona, int idConjunto, int idDepto)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Precio = precio;
            this.FechaReserva = fechaReserva;
            this.CantNoches = cantNoches;
            this.FechaEntrada = fechaEntrada;
            this.FechaSalida = fechaSalida;
            this.IdPersona = idPersona;
            this.IdConjunto = idConjunto;
            this.IdDepto = idDepto;
        }

        public ReservaBLL(string codigo, int precio, string fechaReserva, int cantNoches,  string fechaEntrada, string fechaSalida, int idPersona, int idConjunto, int idDepto)
        {
            this.Codigo = codigo;
            this.Precio = precio;
            this.FechaReserva = fechaReserva;
            this.CantNoches = cantNoches;
            this.FechaEntrada = fechaEntrada;
            this.FechaSalida = fechaSalida;
            this.IdPersona = idPersona;
            this.IdConjunto = idConjunto;
            this.IdDepto = idDepto;
        }

        //Método para Insertar Clientes
        public string InsertarReserva(string codigo, int precio, string fechaReserva, int cantNoches,  string fechaEntrada, string fechaSalida, int idPersona, int idConjunto, int idDepto)
        {
            ReservaDAL reservaDAL = new ReservaDAL();
            ReservaDAL objReservaDAL = new ReservaDAL(codigo,precio, fechaReserva, cantNoches, fechaEntrada, fechaSalida, idPersona, idConjunto,idDepto);

            bool insert = reservaDAL.InsertReserva(objReservaDAL);

            if (insert == true)
            {
                return "Reserva registrada";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string ActualizarReserva(int id, string codigo, int precio, string fechaReserva, int cantNoches,string fechaEntrada, string fechaSalida, int idPersona, int idConjunto, int idDepto)
        {
            ReservaDAL reservaDAL = new ReservaDAL();
            ReservaDAL objReservaDAL = new ReservaDAL(id, codigo, precio,fechaReserva,cantNoches,fechaEntrada,fechaSalida,idPersona,idConjunto,idDepto);

            bool update = reservaDAL.UpdateReserva(objReservaDAL);

            if (update == true)
            {
                return "Reserva Actualizada";
            }
            else
            {
                return "Error al actualizar";
            }
        }

        public string EliminarReserva(int id)
        {
            ReservaDAL reservaDAL = new ReservaDAL();

            bool delete = reservaDAL.DeleteReserva(id);

            if (delete == true)
            {
                return "Reserva eliminada";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<ReservaBLL> TraerTodos()
        {
            ReservaDAL reservaData = new ReservaDAL();
            DataTable tabla = reservaData.GetAllReserva();
            List<ReservaBLL> listReserva = new List<ReservaBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["ID_RESERVA"].ToString());
                string codigo = tabla.Rows[i]["CODIGO"].ToString();
                int precio = int.Parse(tabla.Rows[i]["PRECIO_RESERVA"].ToString());
                string fechaReserva = tabla.Rows[i]["FECHA_RESERVA"].ToString();
                int cantNoches = int.Parse(tabla.Rows[i]["CANT_NOCHES"].ToString());
                string fechaEntrada = tabla.Rows[i]["FECHA_ENTRADA"].ToString();
                string fechaSalida = tabla.Rows[i]["FECHA_SALIDA"].ToString();
                int idPersona = int.Parse(tabla.Rows[i]["PERSONA_ID"].ToString());
                int idConjunto = int.Parse(tabla.Rows[i]["ID_CONJUNTO_SERV"].ToString());
                int idDepto = int.Parse(tabla.Rows[i]["DEPTO_ID_DEPTO"].ToString());

                ReservaBLL objReservaBLL = new ReservaBLL();

                objReservaBLL.Id = id;
                objReservaBLL.Codigo = codigo;
                objReservaBLL.Precio = precio;
                objReservaBLL.FechaReserva = fechaReserva;
                objReservaBLL.CantNoches = cantNoches;
                objReservaBLL.FechaEntrada = fechaEntrada;
                objReservaBLL.FechaSalida = fechaSalida;
                objReservaBLL.IdPersona = idPersona;
                objReservaBLL.IdConjunto = idConjunto;
                objReservaBLL.IdDepto = idDepto;

                listReserva.Add(objReservaBLL);
                i++;
            }
            return listReserva;
        }

        public List<ReservaBLL> TraerPorCodigo(string codigo)
        {
            ReservaDAL reservaDAL = new ReservaDAL();
            DataTable tabla = reservaDAL.GetReservaByCodigo(codigo);
            List<ReservaBLL> listReserva = new List<ReservaBLL>();

            ReservaBLL objReserva = new ReservaBLL();

            if (tabla.Rows.Count > 0)
            {
                objReserva.Id = int.Parse(tabla.Rows[0]["ID_RESERVA"].ToString());
                objReserva.Codigo = tabla.Rows[0]["CODIGO"].ToString();
                objReserva.Precio = int.Parse(tabla.Rows[0]["PRECIO_RESERVA"].ToString());
                objReserva.FechaReserva = tabla.Rows[0]["FECHA_RESERVA"].ToString();
                objReserva.CantNoches = int.Parse(tabla.Rows[0]["CANT_NOCHES"].ToString());
                objReserva.FechaEntrada = tabla.Rows[0]["FECHA_ENTRADA"].ToString();
                objReserva.FechaSalida = tabla.Rows[0]["FECHA_SALIDA"].ToString();
                objReserva.IdPersona = int.Parse(tabla.Rows[0]["PERSONA_ID"].ToString());
                objReserva.IdConjunto = int.Parse(tabla.Rows[0]["ID_CONJUNTO_SERV"].ToString());
                objReserva.IdDepto = int.Parse(tabla.Rows[0]["DEPTO_ID_DEPTO"].ToString());

                listReserva.Add(objReserva);
            }
            return listReserva;
        }

        

        public List<ReservaBLL> TraerPorIdDepto(int idDepto)
        {
            ReservaDAL reservaDAL = new ReservaDAL();
            DataTable tabla = reservaDAL.GetReservaByIdDepto(idDepto);
            List<ReservaBLL> listReserva = new List<ReservaBLL>();

            ReservaBLL objReserva = new ReservaBLL();

            if (tabla.Rows.Count > 0)
            {
                objReserva.Id = int.Parse(tabla.Rows[0]["ID_RESERVA"].ToString());
                objReserva.Codigo = tabla.Rows[0]["CODIGO"].ToString();
                objReserva.Precio = int.Parse(tabla.Rows[0]["PRECIO_RESERVA"].ToString());
                objReserva.FechaReserva = tabla.Rows[0]["FECHA_RESERVA"].ToString();
                objReserva.CantNoches = int.Parse(tabla.Rows[0]["CANT_NOCHES"].ToString());
                objReserva.FechaEntrada = tabla.Rows[0]["FECHA_ENTRADA"].ToString();
                objReserva.FechaSalida = tabla.Rows[0]["FECHA_SALIDA"].ToString();
                objReserva.IdPersona = int.Parse(tabla.Rows[0]["PERSONA_ID"].ToString());
                objReserva.IdConjunto = int.Parse(tabla.Rows[0]["ID_CONJUNTO_SERV"].ToString());
                objReserva.IdDepto = int.Parse(tabla.Rows[0]["DEPTO_ID_DEPTO"].ToString());

                listReserva.Add(objReserva);
            }
            return listReserva;
        }
    }
}
