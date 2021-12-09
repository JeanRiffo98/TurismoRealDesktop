using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class CheckOutBLL
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public byte[] Firma { get; set; }
        public string Fecha { get; set; }
        public int IdPersona { get; set; }
        public string Llaves { get; set; }

        public CheckOutBLL() { }
        public CheckOutBLL(int id, string codigo, byte[] firma, string fecha, int idPersona, string llaves)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Firma = firma;
            this.Fecha = fecha;
            this.IdPersona = idPersona;
            this.Llaves = llaves;
        }

        public CheckOutBLL(string codigo,  byte[] firma, string fecha, int idPersona, string llaves)
        {
            this.Codigo = codigo;
            this.Firma = firma;
            this.Fecha = fecha;
            this.IdPersona = idPersona;
            this.Llaves = llaves;
        }

        public string InsertarCheckOut(string codigo,  byte[] firma, string fecha, int idPersona, string llaves)
        {
            CheckOutDAL checkOutDAL = new CheckOutDAL();
            CheckOutDAL objCheckOut = new CheckOutDAL(codigo, firma, fecha, idPersona,llaves);

            bool insert = checkOutDAL.InsertCheckOut(objCheckOut);

            if (insert == true)
            {
                return "Check out registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }
        public string EliminarCheckOut(int id)
        {
            CheckOutDAL checkOutDAL = new CheckOutDAL();

            bool delete = checkOutDAL.DeleteCheckOut(id);

            if (delete == true)
            {
                return "Check out Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }
        public List<CheckOutBLL> TraerTodos()
        {
            CheckOutDAL checkOutData = new CheckOutDAL();
            DataTable tabla = checkOutData.GetAllCheckOut();
            List<CheckOutBLL> listCheckOut = new List<CheckOutBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["ID_CHECKOUT"].ToString());
                byte[] firmaCliente = (byte[])tabla.Rows[i]["FIRMA_CLIENTE"];
                string fecha = tabla.Rows[i]["FECHA_CHECKOUT"].ToString();
                int idPersona = int.Parse(tabla.Rows[i]["PERSONA_ID"].ToString());
                string llaves = tabla.Rows[i]["LLAVES"].ToString();
                string codigo = tabla.Rows[i]["CODIGO"].ToString();

                CheckOutBLL objCheckOut = new CheckOutBLL();

                objCheckOut.Id = id;
                objCheckOut.Firma = firmaCliente;
                objCheckOut.Fecha = fecha;
                objCheckOut.IdPersona = idPersona;
                objCheckOut.Llaves = llaves;
                objCheckOut.Codigo = codigo;

                listCheckOut.Add(objCheckOut);
                i++;
            }
            return listCheckOut;
        }
        public List<CheckOutBLL> TraerPorCodigo(string codigoParam)
        {
            CheckOutDAL checkOutData = new CheckOutDAL();
            DataTable tablaCheckOut = checkOutData.GetCheckOutByCodigo(codigoParam);
            List<CheckOutBLL> listCheckOut = new List<CheckOutBLL>();

            CheckOutBLL objCheckOut = new CheckOutBLL();

            if (tablaCheckOut.Rows.Count > 0)
            {
                objCheckOut.Id = int.Parse(tablaCheckOut.Rows[0]["ID_CHECKOUT"].ToString());
                objCheckOut.Firma = (byte[])tablaCheckOut.Rows[0]["FIRMA_CLIENTE"];
                objCheckOut.Fecha = tablaCheckOut.Rows[0]["FECHA_CHECKOUT"].ToString();
                objCheckOut.IdPersona= int.Parse(tablaCheckOut.Rows[0]["PERSONA_ID"].ToString());
                objCheckOut.Llaves = tablaCheckOut.Rows[0]["LLAVES"].ToString();
                objCheckOut.Codigo = tablaCheckOut.Rows[0]["CODIGO"].ToString();

                listCheckOut.Add(objCheckOut);
            }
            return listCheckOut;
        }
    }
}
