using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class MultaBLL
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public int IdCheckOut { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }

        public MultaBLL() { }
        public MultaBLL(int id, string descripcion, int costo, int idCheckOut, string codigo, string estado)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.IdCheckOut = idCheckOut;
            this.Codigo = codigo;
            this.Estado = estado;
        }
        public MultaBLL(string descripcion, int costo, int idCheckOut, string codigo, string estado)
        {
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.IdCheckOut = idCheckOut;
            this.Codigo = codigo;
            this.Estado = estado;
        }

        public string InsertarMulta(string descripcion, int costo, int idCheckOut, string codigo, string estado)
        {
            MultaDAL multaDAL = new MultaDAL();
            MultaDAL objMulta = new MultaDAL(descripcion,costo,idCheckOut,codigo,estado);

            bool insert = multaDAL.InsertMulta(objMulta);

            if (insert == true)
            {
                return "Multa registrada";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }
        public string EliminarMulta(int id)
        {
            MultaDAL multaDAL = new MultaDAL();

            bool delete = multaDAL.DeleteMulta(id);

            if (delete == true)
            {
                return "Multa Eliminada";
            }
            else
            {
                return "Error al eliminar";
            }
        }
        public List<MultaBLL> TraerTodos()
        {
            MultaDAL multaData = new MultaDAL();
            DataTable tabla = multaData.GetAllMulta();
            List<MultaBLL> listMulta = new List<MultaBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["ID_MULTA"].ToString());
                string descripcion = tabla.Rows[i]["DESCRIPCION"].ToString();
                int costo = int.Parse(tabla.Rows[i]["COSTO_MULTA"].ToString());
                int idCheckOut = int.Parse(tabla.Rows[i]["ID_CHECKOUT"].ToString());
                string codigo = tabla.Rows[i]["CODIGO"].ToString();
                string estado = tabla.Rows[i]["ESTADO"].ToString();

                MultaBLL objMulta = new MultaBLL();

                objMulta.Id = id;
                objMulta.Descripcion = descripcion;
                objMulta.Costo = costo;
                objMulta.IdCheckOut = idCheckOut;
                objMulta.Codigo = codigo;
                objMulta.Estado = estado;

                listMulta.Add(objMulta);
                i++;
            }
            return listMulta;
        }
        public List<MultaBLL> TraerPorIdCheckOutEstado(int idCheckOutParam,string estadoParam)
        {
            MultaDAL multaData = new MultaDAL();
            DataTable tabla = multaData.GetMultaByIdCheckOutEstado(idCheckOutParam, estadoParam);
            List<MultaBLL> listMulta = new List<MultaBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["ID_MULTA"].ToString());
                string descripcion = tabla.Rows[i]["DESCRIPCION"].ToString();
                int costo = int.Parse(tabla.Rows[i]["COSTO_MULTA"].ToString());
                int idCheckOut = int.Parse(tabla.Rows[i]["ID_CHECKOUT"].ToString());
                string codigo = tabla.Rows[i]["CODIGO"].ToString();
                string estado = tabla.Rows[i]["ESTADO"].ToString();

                MultaBLL objMulta = new MultaBLL();

                objMulta.Id = id;
                objMulta.Descripcion = descripcion;
                objMulta.Costo = costo;
                objMulta.IdCheckOut = idCheckOut;
                objMulta.Codigo = codigo;
                objMulta.Estado = estado;

                listMulta.Add(objMulta);
                i++;
            }
            return listMulta;
        }
    }
}
