using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Clases
{
    public class Clases { }

    public class Persona
    {
        private string dni;
        private string nombre;
        private string apellidos;
        private DateTime fechaNacimiento;
        private DateTime fechaAlta;
        private string telefono;
        private string direccion;
        private string imagen;

        public Persona(string dni, string nombre, string apellidos, DateTime fechaNacimiento, 
            DateTime fechaAlta, string telefono, string direccion, string imagen)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaAlta = fechaAlta;
            this.telefono = telefono;
            this.direccion = direccion;
            this.imagen = imagen;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
    public class Alumno : Persona
    {
        private string estudios;
        private int anoCurso;
        private string personaContacto;
        private bool activo;

        public Alumno(string dni, string nombre, string apellidos, DateTime fechaNacimiento,
            DateTime fechaAlta, string telefono, string direccion, string estudios, int anoCurso, string personaContacto,string imagen,bool activo) 
            : base(dni, nombre, apellidos, fechaNacimiento,fechaAlta, telefono, direccion, imagen)
        {
            this.estudios = estudios;
            this.anoCurso = anoCurso;
            this.personaContacto = personaContacto;
            this.activo = activo;
        }

        public string Estudios { get => estudios; set => estudios = value; }
        public string PersonaContacto { get => personaContacto; set => personaContacto = value; }
        public int AnoCurso { get => anoCurso; set => anoCurso = value; }
        public bool Activo { get => activo; set => activo = value; }
    }

    public class Profesor:Persona
    {
        private string estudios;
        private bool activo;

        public Profesor(string dni, string nombre, string apellidos, DateTime fechaNacimiento,
            DateTime fechaAlta, string telefono, string direccion, string estudios, string imagen, bool activo)
            : base(dni, nombre, apellidos, fechaNacimiento, fechaAlta, telefono, direccion, imagen)
        {
            this.estudios = estudios;
            this.activo = activo;
        }

        public string Estudios { get => estudios; set => estudios = value; }
        public bool Activo { get => activo; set => activo = value; }
    }

    public class Empleado : Persona
    {
        private bool activo;

        public Empleado(string dni, string nombre, string apellidos, DateTime fechaNacimiento,
            DateTime fechaAlta, string telefono, string direccion, string imagen,bool activo)
            : base(dni, nombre, apellidos, fechaNacimiento, fechaAlta, telefono, direccion, imagen)
        {
            this.activo = activo;
        }
        public bool Activo { get => activo; set => activo = value; }
    }

    public class Usuario
    {
        private string usuarios;
        private string pass;

        public Usuario(string usuarios, string pass)
        {
            this.usuarios = usuarios;
            this.pass = pass;
        }

        public string Usuarios { get => usuarios; set => usuarios = value; }
        public string Pass { get => pass; set => pass = value; }
    }

    public class Asignatura
    {
        private string codigoAsignatura;
        private string nombre;

        public Asignatura(string codigoAsignatura, string nombre)
        {
            this.codigoAsignatura = codigoAsignatura;
            this.nombre = nombre;
        }

        public string CodigoAsignatura { get => codigoAsignatura; set => codigoAsignatura = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
