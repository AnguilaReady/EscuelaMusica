using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Clases;
using Npgsql;
using System.Collections.ObjectModel;

namespace Capa_Negocio
{
    public class Negocio
    {
        private BD bd;
        private List<Usuario> listaUsuarios;
        private ObservableCollection<Alumno> listaAlumnos;
        private ObservableCollection<Profesor> listaProfesores;
        private ObservableCollection<Empleado> listaEmpleados;
        private List<Asignatura> listaAsignturas;

        public Negocio()
        {
            bd = new BD();

            listaUsuarios = new List<Usuario>();
            listaAlumnos = new ObservableCollection<Alumno>();
            listaProfesores = new ObservableCollection<Profesor>();
            listaEmpleados = new ObservableCollection<Empleado>();
            listaAsignturas = new List<Asignatura>();

            leerUsuarios();
            leerAlumnos();
            leerProfesores();
            leerEmpleados();
        }

        /*--------------------------------USUARIOS------------------------------------------*/

        //CARGO LA LISTA DE USUARIOS CON LOS USUARIOS QUE HAY EN LA BD
        public void leerUsuarios()
        {
            bd.Abrir();
            NpgsqlDataReader datosRecibidos = bd.EjecutarSelect("select * from usuarios;");
            while (datosRecibidos.Read())
            {
                listaUsuarios.Add(new Usuario(
                    datosRecibidos.GetString(0),
                    datosRecibidos.GetString(1)));
            }
            
            bd.Cerrar();
        }
        //DEVUELVO LA LISTA DE USUARIOS
        public List<Usuario> GetListaUsuarios()
        {
            return listaUsuarios;
        }
        //DEVUELVO UN USUARIO
        public Usuario GetUsuario(int indice)
        {
            return listaUsuarios[indice];
        }
        //BORRO USUARIO
        public int BorrarUsuarios(string usuario)
        {
            bd.Abrir();
            int datosBorrados = bd.EjecutarOrden("delete from usuarios where usuario= '"+usuario+"';");
            bd.Cerrar();
            return datosBorrados;
        }

        //MODIFICO USUARIO
        public int ModificarUsuarios(Usuario usuario)
        {
            bd.Abrir();
            int datosModificados = bd.EjecutarOrden("update usuarios set pass='"+usuario.Pass+"' " +
                "where usuario='"+usuario.Usuarios+"';");
            bd.Cerrar();
            return datosModificados;
        }

        //INSERTAR USUARIO
        public int insertarUsuario(Usuario usuario)
        {
            bd.Abrir();
            int datosInsertados = bd.EjecutarOrden("insert into usuarios(usuario,pass) " +
                "values ('"+usuario.Usuarios+"','"+usuario.Pass+"');");
            bd.Cerrar();
            return datosInsertados;
        }

        /*--------------------------------ALUMNOS------------------------------------------*/

        //CARGO LA LISTA DE ALUMNOS CON LOS ALUMNOS QUE HAY EN LA BD
        public void leerAlumnos()
        {
            bd.Abrir();
            NpgsqlDataReader datosRecibidos = bd.EjecutarSelect("select * from alumno;");
            while (datosRecibidos.Read())
            {
                listaAlumnos.Add(new Alumno(
                    datosRecibidos.GetString(0),
                    datosRecibidos.GetString(1),
                    datosRecibidos.GetString(2),
                    datosRecibidos.GetDateTime(3),
                    datosRecibidos.GetDateTime(4),
                    datosRecibidos.GetString(5),
                    datosRecibidos.GetString(6),
                    datosRecibidos.GetString(7),
                    datosRecibidos.GetInt32(8),
                    datosRecibidos.GetString(9),
                    datosRecibidos.GetString(10),
                    datosRecibidos.GetBoolean(11)));
            }

            bd.Cerrar();
        }

        //DEVUELVO LA LISTA DE ALUMNOS
        public ObservableCollection<Alumno> GetListaAlumnos()
        {
            return listaAlumnos;
        }
        //DEVUELVO UN USUARIO
        public Alumno GetAlumno(int indice)
        {
            return listaAlumnos[indice];
        }
        //BORRO ALUMNO
        public int BorrarAlumno(Alumno alumno)
        {
            bd.Abrir();
            int datosBorrados = bd.EjecutarOrden("update alumno set activo = false where dni= '" + alumno.Dni + "';");
            bd.Cerrar();
            return datosBorrados;
        }
        //MODIFICO ALUMNO
        public int ModificarAlumno(Alumno alumno)
        {
            int datosModificados=0;
            bd.Abrir();
            try
            {
                datosModificados = bd.EjecutarOrden("update alumno set " +
                "dni='" + alumno.Dni + "'," +
                "nombre='" + alumno.Nombre + "'," +
                "apellidos='" + alumno.Apellidos + "'," +
                "fechanacimiento='" + alumno.FechaNacimiento + "'," +
                "fechaalta='" + alumno.FechaAlta + "'," +
                "telefono='" + alumno.Telefono + "'," +
                "direccion='" + alumno.Direccion + "'," +
                "estudios='" + alumno.Estudios + "'," +
                "anocurso='" + alumno.AnoCurso + "'," +
                "personacontacto='" + alumno.PersonaContacto + "'," +
                "imagen='" + alumno.Imagen + "'," +
                "activo=" + alumno.Activo + " " +
                "where dni='" + alumno.Dni + "';");
            }
            catch (NullReferenceException) { }
            
            bd.Cerrar();
            return datosModificados;
        }

        //INSERTAR ALULMNO
        public int insertarAlumno(Alumno alumno)
        {
            bd.Abrir();
            int datosInsertados = bd.EjecutarOrden("insert into " +
                "alumno(dni,nombre,apellidos,fechanacimiento,fechaalta,telefono," +
                "direccion,estudios,anocurso,personacontacto,imagen,activo) " +
                "values (" +
                "'" + alumno.Dni + "'," +
                "'" + alumno.Nombre + "'," +
                "'" + alumno.Apellidos + "'," +
                "'" + alumno.FechaNacimiento + "'," +
                "'" + alumno.FechaAlta + "'," +
                "'" + alumno.Telefono + "'," +
                "'" + alumno.Direccion + "'," +
                "'" + alumno.Estudios + "'," +
                "'" + alumno.AnoCurso + "'," +
                "'" + alumno.PersonaContacto + "'," +
                "'" + alumno.Imagen + "', true);");
            bd.Cerrar();
            return datosInsertados;
        }

        /*--------------------------------PROFESORES------------------------------------------*/

        //CARGO LA LISTA DE ALUMNOS CON LOS ALUMNOS QUE HAY EN LA BD
        public void leerProfesores()
        {
            bd.Abrir();
            NpgsqlDataReader datosRecibidos = bd.EjecutarSelect("select * from profesor;");
            while (datosRecibidos.Read())
            {
                listaProfesores.Add(new Profesor(
                    datosRecibidos.GetString(0),
                    datosRecibidos.GetString(1),
                    datosRecibidos.GetString(2),
                    datosRecibidos.GetDateTime(3),
                    datosRecibidos.GetDateTime(4),
                    datosRecibidos.GetString(5),
                    datosRecibidos.GetString(6),
                    datosRecibidos.GetString(7),
                    datosRecibidos.GetString(8),
                    datosRecibidos.GetBoolean(9)));
            }

            bd.Cerrar();
        }

        //DEVUELVO LA LISTA DE PROFESORES
        public ObservableCollection<Profesor> GetListaProfesores()
        {
            return listaProfesores;
        }
        //DEVUELVO UN PROFESOR
        public Profesor GetProfesor(int indice)
        {
            return listaProfesores[indice];
        }
        //BORRO PROFESOR
        public int BorrarProfesor(Profesor profesor)
        {
            bd.Abrir();
            int datosBorrados = bd.EjecutarOrden("update profesor set activo = false where dni= '" + profesor.Dni + "';");
            bd.Cerrar();
            return datosBorrados;
        }
        //MODIFICO PROFESOR
        public int ModificarProfesor(Profesor profesor)
        {
            int datosModificados = 0;
            bd.Abrir();
            try
            {
               datosModificados = bd.EjecutarOrden("update profesor set " +
               "dni='" + profesor.Dni + "'," +
               "nombre='" + profesor.Nombre + "'," +
               "apellidos='" + profesor.Apellidos + "'," +
               "fechanacimiento='" + profesor.FechaNacimiento + "'," +
               "fechaalta='" + profesor.FechaAlta + "'," +
               "telefono='" + profesor.Telefono + "'," +
               "direccion='" + profesor.Direccion + "'," +
               "estudios='" + profesor.Estudios + "'," +
               "imagen='" + profesor.Imagen + "'" +
               "where dni='" + profesor.Dni + "';");
            }
            catch (System.NullReferenceException) { }
           
            bd.Cerrar();
            return datosModificados;
        }

        //INSERTAR PROFESOR
        public int insertarProfesor(Profesor profesor)
        {
            bd.Abrir();
            int datosInsertados = bd.EjecutarOrden("insert into " +
                "profesor(dni,nombre,apellidos,fechanacimiento,fechaalta,telefono," +
                "direccion,estudios,imagen,activo) " +
                "values (" +
                "'" + profesor.Dni + "'," +
                "'" + profesor.Nombre + "'," +
                "'" + profesor.Apellidos + "'," +
                "'" + profesor.FechaNacimiento + "'," +
                "'" + profesor.FechaAlta + "'," +
                "'" + profesor.Telefono + "'," +
                "'" + profesor.Direccion + "'," +
                "'" + profesor.Estudios + "'," +
                "'" + profesor.Imagen + "', true);");
            bd.Cerrar();
            return datosInsertados;
        }

        /*--------------------------------EMPLEADO------------------------------------------*/

        //CARGO LA LISTA DE EMPLEADOS CON LOS EMPELADOS QUE HAY EN LA BD
        public void leerEmpleados()
        {
            bd.Abrir();
            NpgsqlDataReader datosRecibidos = bd.EjecutarSelect("select * from empleado;");
            while (datosRecibidos.Read())
            {
                listaEmpleados.Add(new Empleado(
                    datosRecibidos.GetString(0),
                    datosRecibidos.GetString(1),
                    datosRecibidos.GetString(2),
                    datosRecibidos.GetDateTime(3),
                    datosRecibidos.GetDateTime(4),
                    datosRecibidos.GetString(5),
                    datosRecibidos.GetString(6),
                    datosRecibidos.GetString(7),
                    datosRecibidos.GetBoolean(8)));
            }

            bd.Cerrar();
        }

        //DEVUELVO LA LISTA DE EMPLEADOS
        public ObservableCollection<Empleado> GetListaEmpleados()
        {
            return listaEmpleados;
        }
        //DEVUELVO UN EMPLEADO
        public Empleado GetEmpleado(int indice)
        {
            return listaEmpleados[indice];
        }
        //BORRO EMPLEADO
        public int BorrarEmpleado(Empleado empleado)
        {
            bd.Abrir();
            int datosBorrados = bd.EjecutarOrden("update empleado set activo = false where dni= '" + empleado.Dni + "';");
            bd.Cerrar();
            return datosBorrados;
        }
        //MODIFICO EMPLEADO
        public int ModificarEmpleado(Empleado empleado)
        {
            bd.Abrir();
            int datosModificados = bd.EjecutarOrden("update empleado set " +
                "dni='" + empleado.Dni + "'," +
                "nombre='" + empleado.Nombre + "'," +
                "apellidos='" + empleado.Apellidos + "'," +
                "fechanacimiento='" + empleado.FechaNacimiento + "'," +
                "fechaalta='" + empleado.FechaAlta + "'," +
                "telefono='" + empleado.Telefono + "'," +
                "direccion='" + empleado.Direccion + "'," +
                "imagen='" + empleado.Imagen + "'" +
                "where dni='" + empleado.Dni + "';");
            bd.Cerrar();
            return datosModificados;
        }
        //INSERTAR EMPLEADO
        public int insertarEmpleado(Empleado empleado)
        {
            bd.Abrir();
            int datosInsertados = bd.EjecutarOrden("insert into " +
                "empleado(dni,nombre,apellidos,fechanacimiento,fechaalta,telefono," +
                "direccion,imagen,activo) " +
                "values (" +
                "'" + empleado.Dni + "'," +
                "'" + empleado.Nombre + "'," +
                "'" + empleado.Apellidos + "'," +
                "'" + empleado.FechaNacimiento + "'," +
                "'" + empleado.FechaAlta + "'," +
                "'" + empleado.Telefono + "'," +
                "'" + empleado.Direccion + "'," +
                "'" + empleado.Imagen + "',true);");
            bd.Cerrar();
            return datosInsertados;
        }


        /*--------------------------------ASIGNATURA------------------------------------------*/

        //CARGO LA LISTA DE EMPLEADOS CON LOS EMPELADOS QUE HAY EN LA BD
        public void leerAsignaturas()
        {
            bd.Abrir();
            NpgsqlDataReader datosRecibidos = bd.EjecutarSelect("select * from asignatura;");
            while (datosRecibidos.Read())
            {
                listaAsignturas.Add(new Asignatura(
                    datosRecibidos.GetString(0),
                    datosRecibidos.GetString(1)));
            }

            bd.Cerrar();
        }

        //DEVUELVO LA LISTA DE ASIGNATURAS
        public List<Asignatura> GetListaAsignaturas()
        {
            return listaAsignturas;
        }
        //DEVUELVO UN ASIGNATURA
        public Asignatura GetAsignatura(int indice)
        {
            return listaAsignturas[indice];
        }
        //BORRO ASIGNATURA
        public int BorrarAsinatura(string codigoAsignatura)
        {
            bd.Abrir();
            int datosBorrados = bd.EjecutarOrden("delete from asignatura where codigoasignatura= '" + codigoAsignatura + "';");
            bd.Cerrar();
            return datosBorrados;
        }
        //MODIFICO ASIGNATURA
        public int Modificarasignatura(Asignatura asignatura)
        {
            bd.Abrir();
            int datosModificados = bd.EjecutarOrden("update asignatura set nombre='"
                +asignatura.Nombre+"' where codigoasignatura='"+asignatura.CodigoAsignatura+"';");
            bd.Cerrar();
            return datosModificados;
        }

        //INSERTAR ASIGNATURA
        public int insertarAsignatura(Asignatura asignatura)
        {
            bd.Abrir();
            int datosInsertados = bd.EjecutarOrden("insert into " +
                "empelado(codigoasignatura,nombre) " +
                "values (" +
                "'" + asignatura.CodigoAsignatura + "'," +
                "'" + asignatura.Nombre + "');");
            bd.Cerrar();
            return datosInsertados;
        }
    }
}



