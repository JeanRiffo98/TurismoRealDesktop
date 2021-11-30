using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealDesktopDAL;

namespace TurismoRealDesktopBLL
{
    public class PersonaBLL
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public PersonaBLL() { }

        public PersonaBLL(int id, string rut, string nombres, string apellidos, string telefono, string correo, string contraseña)
        {
            Id = id;
            Rut = rut;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Correo = correo;
            Contraseña = contraseña;
        }


        public PersonaBLL(string rut, string nombres, string apellidos, string telefono, string correo)
        {
            Rut = rut;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Correo = correo;
        }
        public PersonaBLL(string rut, string nombres, string apellidos, string telefono, string correo, string contraseña)
        {
            Rut = rut;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Correo = correo;
            Contraseña = contraseña;
        }

        //Método para Insertar Clientes
        public string InsertarPersona(string rut, string nombres, string apellidos, string telefono, string correo, string contraseña)
        {
            PersonaDAL personaDAL = new PersonaDAL();
            PersonaDAL objPersonaDAL = new PersonaDAL(rut, nombres, apellidos, telefono, correo, contraseña);

            bool insert = personaDAL.InsertPersona(objPersonaDAL);

            if (insert == true)
            {
                return "Cliente registrado";
            }
            else
            {
                return "Hubo un error al registrar";
            }
        }

        public string EliminarCliente(string rut)
        {
            PersonaDAL personaDAL = new PersonaDAL();

            bool delete = personaDAL.DeletePersona(rut);

            if (delete == true)
            {
                return "Cliente Eliminado";
            }
            else
            {
                return "Error al eliminar";
            }
        }

        public List<PersonaBLL> TraerTodos()
        {
            PersonaDAL personaData = new PersonaDAL();
            DataTable tabla = personaData.GetAllPersona();
            List<PersonaBLL> listPersona = new List<PersonaBLL>();

            int i = 0;
            while (i < tabla.Rows.Count)
            {
                int id = int.Parse(tabla.Rows[i]["ID_PERSONA"].ToString());
                string rut = tabla.Rows[i]["Rut"].ToString();
                string nombres = tabla.Rows[i]["Nombres"].ToString();
                string apellidos = tabla.Rows[i]["Apellidos"].ToString();
                string telefono = tabla.Rows[i]["Telefono"].ToString();
                string correo = tabla.Rows[i]["Correo"].ToString();
                string contraseña = tabla.Rows[i]["Contrasenia"].ToString();

                PersonaBLL objPersona = new PersonaBLL();
                objPersona.Id = id;
                objPersona.Rut = rut;
                objPersona.Nombres = nombres;
                objPersona.Apellidos = apellidos;
                objPersona.Telefono = telefono;
                objPersona.Correo = correo;
                objPersona.Contraseña = contraseña;

                listPersona.Add(objPersona);
                i++;
            }
            return listPersona;
        }

        public List<PersonaBLL> TraerPorRut(string rut)
        {
            PersonaDAL personaData = new PersonaDAL();
            DataTable tabla = personaData.GetPersonaByRut(rut);
            List<PersonaBLL> listPersona = new List<PersonaBLL>();

            PersonaBLL objPersona = new PersonaBLL();

            if (tabla.Rows.Count > 0)
            {
                objPersona.Rut = tabla.Rows[0]["Rut"].ToString();
                objPersona.Nombres = tabla.Rows[0]["Nombres"].ToString();
                objPersona.Apellidos = tabla.Rows[0]["Apellidos"].ToString();
                objPersona.Telefono = tabla.Rows[0]["Telefono"].ToString();
                objPersona.Correo = tabla.Rows[0]["Correo"].ToString();
                objPersona.Contraseña = tabla.Rows[0]["Contrasenia"].ToString();

                listPersona.Add(objPersona);
            }
            return listPersona;
        }
        public List<PersonaBLL> TraerPorId(int id)
        {
            PersonaDAL personaData = new PersonaDAL();
            DataTable tabla = personaData.GetPersonaById(id);
            List<PersonaBLL> listPersona = new List<PersonaBLL>();

            PersonaBLL objPersona = new PersonaBLL();

            if (tabla.Rows.Count > 0)
            {
                objPersona.Rut = tabla.Rows[0]["Rut"].ToString();
                objPersona.Nombres = tabla.Rows[0]["Nombres"].ToString();
                objPersona.Apellidos = tabla.Rows[0]["Apellidos"].ToString();
                objPersona.Telefono = tabla.Rows[0]["Telefono"].ToString();
                objPersona.Correo = tabla.Rows[0]["Correo"].ToString();
                objPersona.Contraseña = tabla.Rows[0]["Contrasenia"].ToString();

                listPersona.Add(objPersona);
            }
            return listPersona;
        }
    }
}
