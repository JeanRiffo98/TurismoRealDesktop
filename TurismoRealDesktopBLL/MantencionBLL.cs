using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class MantencionBLL
    {
        public int Id { get; set; }
        public string EnMantencion { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int Costo { get; set; }
        public int IdDepto { get; set; }

        public MantencionBLL() { }
        public MantencionBLL(int id, string enMantencion, string codigo, string descripcion, string fechaInicio, string fechaFin, int costo, int idDepto)
        {
            this.Id = id;
            this.EnMantencion = enMantencion;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Costo = costo;
            this.IdDepto = idDepto;
        }
        public MantencionBLL(string enMantencion, string codigo,string descripcion, string fechaInicio, string fechaFin, int costo, int idDepto)
        {
            this.EnMantencion = enMantencion;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.Costo = costo;
            this.IdDepto = idDepto;
        }
        
        public string InsertarMantencion(string enMantencion, string codigo,string descripcion, string fechaInicio, string fechaFin, int costo, int idDepto)
        {
            MantencionDAL mantencionDAL = new MantencionDAL();
            MantencionDAL objMantencionDAL = new MantencionDAL(enMantencion,codigo,descripcion,fechaInicio,fechaFin,costo,idDepto);

            bool insert = mantencionDAL.InsertMantencion(objMantencionDAL);

            if (insert == true)
            {
                return "Mantencion registrada";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string ActualizarMantencion(int id, string enMantencion, string codigo,string descripcion, string fechaInicio, string fechaFin, int costo, int idDepto)
        {
            MantencionDAL mantencionDAL = new MantencionDAL();
            MantencionDAL objMantencionDAL = new MantencionDAL(id, enMantencion,codigo,descripcion,fechaInicio,fechaFin, costo, idDepto);

            bool update = mantencionDAL.UpdateMantencion(objMantencionDAL);

            if (update == true)
            {
                return "Mantencion actualizada";
            }
            else
            {
                return "Error al actualizar";
            }
        }

        public string EliminarMantencion(int id)
        {
            MantencionDAL mantencionDAL = new MantencionDAL();

            bool delete = mantencionDAL.DeleteMantencion(id);

            if (delete == true)
            {
                return "Mantencion Eliminada";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<MantencionBLL> TraerPorCodigo(string codigoParam)
        {
            MantencionDAL mantencionData = new MantencionDAL();
            DataTable tabla = mantencionData.GetMantencionByCodigo(codigoParam);
            List<MantencionBLL> listMantencion = new List<MantencionBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_mantencion"].ToString());
                string enMantencion = tabla.Rows[i]["en_mantencion"].ToString();
                string codigo = tabla.Rows[i]["CODIGO"].ToString();
                string descripcion = tabla.Rows[i]["DESC_MANTENCION"].ToString();
                string fechaInicio = tabla.Rows[i]["FECHA_INICIO"].ToString();
                string fechaFin = tabla.Rows[i]["FECHA_FIN"].ToString();
                int costo = int.Parse(tabla.Rows[i]["COSTO_MANTENCION"].ToString());
                int idDepto = int.Parse(tabla.Rows[i]["DEPTO_ID_DEPTO"].ToString());

                MantencionBLL objMantencion = new MantencionBLL();
                objMantencion.Id = id;
                objMantencion.EnMantencion = enMantencion;
                objMantencion.Codigo = codigo;
                objMantencion.Descripcion = descripcion;
                objMantencion.FechaInicio = fechaInicio;
                objMantencion.FechaFin = fechaFin;
                objMantencion.Costo = costo;
                objMantencion.IdDepto = idDepto;

                listMantencion.Add(objMantencion);
                i++;
            }
            return listMantencion;
        }


        public List<MantencionBLL> TraerPorIdDepto(int idDeptoParam)
        {
            MantencionDAL mantencionData = new MantencionDAL();
            DataTable tabla = mantencionData.GetMantencionByIdDepto(idDeptoParam);
            List<MantencionBLL> listMantencion = new List<MantencionBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_mantencion"].ToString());
                string enMantencion = tabla.Rows[i]["en_mantencion"].ToString();
                string codigo = tabla.Rows[i]["CODIGO"].ToString();
                string descripcion = tabla.Rows[i]["DESC_MANTENCION"].ToString();
                string fechaInicio = tabla.Rows[i]["FECHA_INICIO"].ToString();
                string fechaFin = tabla.Rows[i]["FECHA_FIN"].ToString();
                int costo = int.Parse(tabla.Rows[i]["COSTO_MANTENCION"].ToString());
                int idDepto = int.Parse(tabla.Rows[i]["DEPTO_ID_DEPTO"].ToString());

                MantencionBLL objMantencion = new MantencionBLL();
                objMantencion.Id = id;
                objMantencion.EnMantencion = enMantencion;
                objMantencion.Codigo = codigo;
                objMantencion.Descripcion = descripcion;
                objMantencion.FechaInicio = fechaInicio;
                objMantencion.FechaFin = fechaFin;
                objMantencion.Costo = costo;
                objMantencion.IdDepto = idDepto;

                listMantencion.Add(objMantencion);
                i++;
            }
            return listMantencion;
        }
    }
}
