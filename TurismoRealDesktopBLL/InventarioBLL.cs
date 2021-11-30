using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class InventarioBLL
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public string FechaIngreso { get; set; }
        public int CostoIndividual { get; set; }
        public int CostoTotal { get; set; }
        public int IdDepto { get; set; }

        public InventarioBLL() { }
        public InventarioBLL(int id, string nombre, string descripcion, string codigo, int cantidad, string fechaIngreso, int costoIndividual, int costoTotal, int idDepto)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.Cantidad = cantidad;
            this.FechaIngreso = fechaIngreso;
            this.CostoIndividual = costoIndividual;
            this.CostoTotal = costoTotal;
            this.IdDepto = idDepto;
        }

        public InventarioBLL(string nombre, string descripcion, string codigo, int cantidad, string fechaIngreso, int costoIndividual, int costoTotal, int idDepto)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.Cantidad = cantidad;
            this.FechaIngreso = fechaIngreso;
            this.CostoIndividual = costoIndividual;
            this.CostoTotal = costoTotal;
            this.IdDepto = idDepto;
        }

        //Método para Insertar Clientes
        public string InsertarObjeto(string nombre, string descripcion, string codigo, int cantidad, string fechaIngreso, int costoIndividual,int costoTotal, int idDepto)
        {
            InventarioDAL inventarioDAL = new InventarioDAL();
            InventarioDAL objinventarioDAL = new InventarioDAL(nombre, descripcion, codigo, cantidad, fechaIngreso, costoIndividual,costoTotal, idDepto);

            bool insert = inventarioDAL.InsertObjeto(objinventarioDAL);

            if (insert == true)
            {
                return "Objeto registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string ActualizarObjeto(int id, string nombre, string descripcion, string codigo, int cantidad, string fechaIngreso, int costoIndividual, int costoTotal, int idDepto)
        {
            InventarioDAL inventarioDAL = new InventarioDAL();
            InventarioDAL objinventarioDAL = new InventarioDAL(id, nombre, descripcion, codigo, cantidad, fechaIngreso, costoIndividual, costoTotal, idDepto);

            bool update = inventarioDAL.UpdateObjeto(objinventarioDAL);

            if (update == true)
            {
                return "Objeto actualizado";
            }
            else
            {
                return "Error al actualizar";
            }
        }

        public string EliminarObjeto(int id)
        {
            InventarioDAL inventarioDAL = new InventarioDAL();

            bool delete = inventarioDAL.DeleteObjeto(id);

            if (delete == true)
            {
                return "Objeto Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<InventarioBLL> TraerPorNombre(string nombreParam)
        {
            InventarioDAL inventarioData = new InventarioDAL();
            DataTable tabla = inventarioData.GetObjetoByNombre(nombreParam);
            List<InventarioBLL> listInventario = new List<InventarioBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_objeto"].ToString());
                string nombre = tabla.Rows[i]["Nombre"].ToString();
                string descripcion = tabla.Rows[i]["Descripcion"].ToString();
                string codigo = tabla.Rows[i]["Codigo"].ToString();
                int cantidad = int.Parse(tabla.Rows[i]["Cantidad"].ToString());
                string fechaIngreso = tabla.Rows[i]["Fecha_ingreso"].ToString();
                int costoIndividual = int.Parse(tabla.Rows[i]["Costo_individual"].ToString());
                int costoTotal = int.Parse(tabla.Rows[i]["Costo_total"].ToString());
                int idDepto = int.Parse(tabla.Rows[i]["DEPTO_ID_DEPTO"].ToString());

                InventarioBLL objInventario = new InventarioBLL();

                objInventario.Id = id;
                objInventario.Nombre = nombre;
                objInventario.Descripcion = descripcion;
                objInventario.Codigo = codigo;
                objInventario.Cantidad = cantidad;
                objInventario.FechaIngreso = fechaIngreso;
                objInventario.CostoIndividual = costoIndividual;
                objInventario.CostoTotal = costoTotal;
                objInventario.IdDepto = idDepto;

                listInventario.Add(objInventario);
                i++;
            }
            return listInventario;
        }


        public List<InventarioBLL> TraerPorIdDepto(int idDeptoParam)
        {
            InventarioDAL inventarioData = new InventarioDAL();
            DataTable tabla = inventarioData.GetObjetoByIdDepto(idDeptoParam);
            List<InventarioBLL> listInventario = new List<InventarioBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_objeto"].ToString());
                string nombre = tabla.Rows[i]["Nombre"].ToString();
                string descripcion = tabla.Rows[i]["Descripcion"].ToString();
                string codigo = tabla.Rows[i]["Codigo"].ToString();
                int cantidad = int.Parse(tabla.Rows[i]["Cantidad"].ToString());
                string fechaIngreso = tabla.Rows[i]["Fecha_ingreso"].ToString();
                int costoIndividual = int.Parse(tabla.Rows[i]["Costo_individual"].ToString());
                int costoTotal = int.Parse(tabla.Rows[i]["Costo_total"].ToString());
                int idDepto = int.Parse(tabla.Rows[i]["DEPTO_ID_DEPTO"].ToString());

                InventarioBLL objInventario = new InventarioBLL();

                objInventario.Id = id;
                objInventario.Nombre = nombre;
                objInventario.Descripcion = descripcion;
                objInventario.Codigo = codigo;
                objInventario.Cantidad = cantidad;
                objInventario.FechaIngreso = fechaIngreso;
                objInventario.CostoIndividual = costoIndividual;
                objInventario.CostoTotal = costoTotal;
                objInventario.IdDepto = idDepto;

                listInventario.Add(objInventario);
                i++;
            }
            return listInventario;
        }
    }
}
