using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class DepartamentoBLL
    {
        public int Id { get; set; }
        public int Habitaciones { get; set; }
        public int Baños { get; set; }
        public string Wifi { get; set; }
        public int PrecioNoche { get; set; }
        public string FechaPublicacion { get; set; }
        public string FechaAdquisicion { get; set; }
        public string Disponibilidad { get; set; }
        public string Titulo { get; set; }
        public string Television { get; set; }
        public string Descripcion { get; set; }
        public int CantPersonasMax { get; set; }
        public string Direccion { get; set; }
        public int NroDepto { get; set; }
        public int CantCamas { get; set; }
        public string ZonaDepto { get; set; }
        public DepartamentoBLL() { }

        public DepartamentoBLL(int habitaciones, int baños, string wifi, int precioNoche, string fechaPublicacion, string fechaAdquisicion, string disponibilidad, string titulo, string television, string descripcion,
                                int cantPersonasMax, string direccion, int nroDepto, int cantCamas, string zonaDepto)
        {
            Habitaciones = habitaciones;
            Baños = baños;
            Wifi = wifi;
            PrecioNoche = precioNoche;
            FechaAdquisicion = fechaPublicacion;
            FechaAdquisicion = fechaAdquisicion;
            Disponibilidad = disponibilidad;
            Titulo = titulo;
            Television = television;
            Descripcion = descripcion;
            CantPersonasMax = cantPersonasMax;
            Direccion = direccion;
            NroDepto = nroDepto;
            CantCamas = cantCamas;
            ZonaDepto = zonaDepto;
        }


        public DepartamentoBLL(int id,int habitaciones, int baños, string wifi, int precioNoche, string fechaPublicacion, string fechaAdquisicion, string disponibilidad, string titulo, string television, string descripcion,
                                int cantPersonasMax, string direccion, int nroDepto, int cantCamas, string zonaDepto)
        {
            Id = id;
            Habitaciones = habitaciones;
            Baños = baños;
            Wifi = wifi;
            PrecioNoche = precioNoche;
            FechaAdquisicion = fechaPublicacion;
            FechaAdquisicion = fechaAdquisicion;
            Disponibilidad = disponibilidad;
            Titulo = titulo;
            Television = television;
            Descripcion = descripcion;
            CantPersonasMax = cantPersonasMax;
            Direccion = direccion;
            NroDepto = nroDepto;
            CantCamas = cantCamas;
            ZonaDepto = zonaDepto;
        }

        //Método para Insertar Clientes
        public string InsertarDepartamento(int habitaciones, int baños, string wifi, int precioNoche, string fechaPublicacion, string fechaAdquisicion, string disponibilidad, string titulo, string television, string descripcion,
                                int cantPersonasMax, string direccion, int nroDepto, int cantCamas, string zonaDepto)
        {
            DepartamentoDAL departamentoDAL = new DepartamentoDAL();
            DepartamentoDAL objDepartamentoDAL = new DepartamentoDAL(habitaciones,baños,wifi,precioNoche,fechaPublicacion,fechaAdquisicion,disponibilidad,titulo,television,descripcion,cantPersonasMax,direccion,nroDepto,cantCamas,zonaDepto);

            bool insert = departamentoDAL.InsertDepartamento(objDepartamentoDAL);

            if (insert == true)
            {
                return "Departamento registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string ActualizarDepartamento(int id,int habitaciones, int baños, string wifi, int precioNoche, string fechaPublicacion, string fechaAdquisicion, string disponibilidad, string titulo, string television, string descripcion,
                                int cantPersonasMax, string direccion, int nroDepto, int cantCamas, string zonaDepto)
        {
            DepartamentoDAL departamentoDAL = new DepartamentoDAL();
            DepartamentoDAL objDepartamentoDAL = new DepartamentoDAL(id,habitaciones, baños, wifi, precioNoche,fechaPublicacion, fechaAdquisicion, disponibilidad, titulo, television, descripcion, cantPersonasMax, direccion, nroDepto, cantCamas, zonaDepto);

            bool update = departamentoDAL.UpdateDepartamento(objDepartamentoDAL);

            if (update == true)
            {
                return "Departamento actualizado";
            }
            else
            {
                return "Error al actualizar";
            }
        }

        public string EliminarDepartamento(int id)
        {
            DepartamentoDAL departamentoDAL = new DepartamentoDAL();

            bool delete = departamentoDAL.DeleteDepartamento(id);

            if (delete == true)
            {
                return "Departamento Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<DepartamentoBLL> TraerTodos()
        {
            DepartamentoDAL departamentoData = new DepartamentoDAL();
            DataTable tabla = departamentoData.GetAllDepartamento();
            List<DepartamentoBLL> listDepartamento = new List<DepartamentoBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_depto"].ToString());
                int habitaciones = int.Parse(tabla.Rows[i]["habitaciones"].ToString());
                int baños = int.Parse(tabla.Rows[i]["Banios"].ToString());
                string wifi = tabla.Rows[i]["wifi"].ToString();
                int precioNoche = int.Parse(tabla.Rows[i]["precio_nochedepto"].ToString());
                string fechaPublicacion = tabla.Rows[i]["fecha_publicacion"].ToString();
                string fechaAdquisicion = tabla.Rows[i]["fecha_adquisicion"].ToString();
                string disponibilidad = tabla.Rows[i]["disponibilidad"].ToString();
                string titulo = tabla.Rows[i]["titulo"].ToString();
                string descripcion = tabla.Rows[i]["descripcion"].ToString();
                string television = tabla.Rows[i]["television"].ToString();
                int cantPersonasMax = int.Parse(tabla.Rows[i]["cant_personasmax"].ToString());
                string direccion = tabla.Rows[i]["direccion"].ToString();
                int nroDepto = int.Parse(tabla.Rows[i]["nro_depto"].ToString());
                int cantCamas = int.Parse(tabla.Rows[i]["cant_camas"].ToString());
                string zonaDepto = tabla.Rows[i]["zona_depto"].ToString();

                DepartamentoBLL objDepartamento = new DepartamentoBLL();
                objDepartamento.Id = id;
                objDepartamento.Habitaciones = habitaciones;
                objDepartamento.Baños = baños;
                objDepartamento.Wifi = wifi;
                objDepartamento.PrecioNoche = precioNoche;
                objDepartamento.FechaPublicacion = fechaPublicacion;
                objDepartamento.FechaAdquisicion = fechaAdquisicion;
                objDepartamento.Disponibilidad = disponibilidad;
                objDepartamento.Titulo = titulo;
                objDepartamento.Descripcion = descripcion;
                objDepartamento.Television = television;
                objDepartamento.CantPersonasMax = cantPersonasMax;
                objDepartamento.Direccion = direccion;
                objDepartamento.NroDepto = nroDepto;
                objDepartamento.CantCamas = cantCamas;
                objDepartamento.ZonaDepto = zonaDepto;

                listDepartamento.Add(objDepartamento);
                i++;
            }
            return listDepartamento;
        }

        public List<DepartamentoBLL> TraerPorTitulo(string tituloParam)
        {
            DepartamentoDAL departamentoData = new DepartamentoDAL();
            DataTable tabla = departamentoData.GetDepartamentoByTitulo(tituloParam);
            List<DepartamentoBLL> listDepartamento = new List<DepartamentoBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_depto"].ToString());
                int habitaciones = int.Parse(tabla.Rows[i]["habitaciones"].ToString());
                int baños = int.Parse(tabla.Rows[i]["Banios"].ToString());
                string wifi = tabla.Rows[i]["wifi"].ToString();
                int precioNoche = int.Parse(tabla.Rows[i]["precio_nochedepto"].ToString());
                string fechaPublicacion = tabla.Rows[i]["fecha_publicacion"].ToString();
                string fechaAdquisicion = tabla.Rows[i]["fecha_adquisicion"].ToString();
                string disponibilidad = tabla.Rows[i]["disponibilidad"].ToString();
                string titulo = tabla.Rows[i]["titulo"].ToString();
                string descripcion = tabla.Rows[i]["descripcion"].ToString();
                string television = tabla.Rows[i]["television"].ToString();
                int cantPersonasMax = int.Parse(tabla.Rows[i]["cant_personasmax"].ToString());
                string direccion = tabla.Rows[i]["direccion"].ToString();
                int nroDepto = int.Parse(tabla.Rows[i]["nro_depto"].ToString());
                int cantCamas = int.Parse(tabla.Rows[i]["cant_camas"].ToString());
                string zonaDepto = tabla.Rows[i]["zona_depto"].ToString();

                DepartamentoBLL objDepartamento = new DepartamentoBLL();
                objDepartamento.Id = id;
                objDepartamento.Habitaciones = habitaciones;
                objDepartamento.Baños = baños;
                objDepartamento.Wifi = wifi;
                objDepartamento.PrecioNoche = precioNoche;
                objDepartamento.FechaPublicacion = fechaPublicacion;
                objDepartamento.FechaAdquisicion = fechaAdquisicion;
                objDepartamento.Disponibilidad = disponibilidad;
                objDepartamento.Titulo = titulo;
                objDepartamento.Descripcion = descripcion;
                objDepartamento.Television = television;
                objDepartamento.CantPersonasMax = cantPersonasMax;
                objDepartamento.Direccion = direccion;
                objDepartamento.NroDepto = nroDepto;
                objDepartamento.CantCamas = cantCamas;
                objDepartamento.ZonaDepto = zonaDepto;

                listDepartamento.Add(objDepartamento);
                i++;
            }
            return listDepartamento;
        }

    }
}
