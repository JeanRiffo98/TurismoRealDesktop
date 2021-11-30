using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class ImagenBLL
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public int IdDepto { get; set; }

        public ImagenBLL() { }

        public ImagenBLL(int id, byte[] imagen, int idDepto)
        {
            this.Id = id;
            this.Imagen = imagen;
            this.IdDepto = idDepto;
        }
        public ImagenBLL(byte[] imagen, int idDepto)
        {
            this.Imagen = imagen;
            this.IdDepto = idDepto;
        }


        //Método para Insertar Clientes
        public string InsertarImagen(byte[] imagen, int idDepto)
        {
            ImagenDAL imagenDAL = new ImagenDAL();
            ImagenDAL objImagenDAL = new ImagenDAL(imagen,idDepto);

            bool insert = imagenDAL.InsertImagen(objImagenDAL);

            if (insert == true)
            {
                return "Departamento registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string EliminarImagen(int id)
        {
            ImagenDAL imagenDAL = new ImagenDAL();

            bool delete = imagenDAL.DeleteImagen(id);

            if (delete == true)
            {
                return "Imagen Eliminada";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<ImagenBLL> TraerTodas()
        {
            ImagenDAL imagenData = new ImagenDAL();
            DataTable tabla = imagenData.GetAllImagen();
            List<ImagenBLL> listImagen = new List<ImagenBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["Id_imagen"].ToString());
                byte[] imagen = (byte[])tabla.Rows[i]["imagen"];
                int idDepto = int.Parse(tabla.Rows[i]["depto_id_depto"].ToString());

                ImagenBLL objImagen = new ImagenBLL();

                objImagen.Id = id;
                objImagen.Imagen = imagen;
                objImagen.IdDepto = IdDepto;

                listImagen.Add(objImagen);
                i++;
            }
            return listImagen;
        }
    }
}

