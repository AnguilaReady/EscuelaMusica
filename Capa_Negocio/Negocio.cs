﻿using System;
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
        private ObservableCollection<Usuario> listaUsuarios;
        private ObservableCollection<Alumno> listaAlumnos;
        private ObservableCollection<Profesor> listaProfesores;
        private ObservableCollection<Empleado> listaEmpleados;
        private ObservableCollection<Matriculado> listaMatriculados;
        private ObservableCollection<Alumno_Notas> listaNotasAlumnos;

        public Negocio()
        {
            bd = new BD();

            listaUsuarios = new ObservableCollection<Usuario>();
            listaAlumnos = new ObservableCollection<Alumno>();
            listaProfesores = new ObservableCollection<Profesor>();
            listaEmpleados = new ObservableCollection<Empleado>();
            listaMatriculados = new ObservableCollection<Matriculado>();
            listaNotasAlumnos = new ObservableCollection<Alumno_Notas>();

            leerUsuarios();
            leerAlumnos();
            leerProfesores();
            leerEmpleados();
            leerNotasAlumnos();
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
        public ObservableCollection<Usuario> GetListaUsuarios()
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
                    datosRecibidos.GetString(8),
                    datosRecibidos.GetBoolean(9)));
            }

            bd.Cerrar();
        }

        //DEVUELVO LA LISTA DE ALUMNOS
        public ObservableCollection<Alumno> GetListaAlumnos()
        {
            return listaAlumnos;
        }

        public void borrarListaAlumnos()
        {
            listaAlumnos.Clear();
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
                "direccion,personacontacto,imagen,activo) " +
                "values (" +
                "'" + alumno.Dni + "'," +
                "'" + alumno.Nombre + "'," +
                "'" + alumno.Apellidos + "'," +
                "'" + alumno.FechaNacimiento + "'," +
                "'" + alumno.FechaAlta + "'," +
                "'" + alumno.Telefono + "'," +
                "'" + alumno.Direccion + "'," +
                "'" + alumno.PersonaContacto + "'," +
                "'" + alumno.Imagen + "', true);");
            bd.Cerrar();
            return datosInsertados;
        }

        /*--------------------------------PROFESORES------------------------------------------*/

        //CARGO LA LISTA DE PROFESORES QUE HAY EN LA BD
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

        public void borrarListaProfesores()
        {
            listaProfesores.Clear();
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

        public void borrarListaEmpleados()
        {
            listaEmpleados.Clear();
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


        /*--------------------------------MATRICULADO------------------------------------------*/

        //CARGO LA LISTA DE MATRICULADOS QUE HAY EN LA BD
        public void leerAsignaturas()
        {
            bd.Abrir();
            NpgsqlDataReader datosRecibidos = bd.EjecutarSelect("select * from matricula;");
            while (datosRecibidos.Read())
            {
                listaMatriculados.Add(new Matriculado(
                    datosRecibidos.GetString(0),
                    datosRecibidos.GetString(1),
                    datosRecibidos.GetInt32(2)));
            }

            bd.Cerrar();
        }

        //DEVUELVO LA LISTA DE MATRICULADOS
        public ObservableCollection<Matriculado> GetListaAsignaturas()
        {
            return listaMatriculados;
        }

        //BORRO MATRICULADO
        public int BorrarAsinatura(Matriculado matriculado)
        {
            bd.Abrir();
            int datosBorrados = bd.EjecutarOrden("delete from matricula where " +
                "dnialumno='"+matriculado.Dni+"' and asignatura='"+matriculado.Asignatura+"';");
            bd.Cerrar();
            return datosBorrados;
        }

        //INSERTAR MATRICULA
        public int insertarMatricula(Matriculado matriculado)
        {
            bd.Abrir();
            int datosInsertados = bd.EjecutarOrden("insert into " +
                "matricula(dniAlumno,asignatura,anoCurso) " +
                "values (" +
                "'" + matriculado.Dni + "'," +
                "'" + matriculado.Asignatura+ "'," + matriculado.AnoCurso + ");");
            bd.Cerrar();
            return datosInsertados;
        }



        /*--------------------------------EMPLEADO------------------------------------------*/

        //CARGO LA LISTA DE MATRICULADOS QUE HAY EN LA BD
        public void leerNotasAlumnos()
        {
            bd.Abrir();
            NpgsqlDataReader datosRecibidos = bd.EjecutarSelect("select dnialumno,nombre,apellidos,anocurso,asignatura,primertrimestre,segundotrimestre,tercertrimestre,notaglobal,imagen from notas, alumno where notas.dnialumno = alumno.dni; ");
            while (datosRecibidos.Read())
            {
                listaNotasAlumnos.Add(new Alumno_Notas(
                    datosRecibidos.GetString(0),
                    datosRecibidos.GetString(1),
                    datosRecibidos.GetString(2),
                    datosRecibidos.GetInt32(3),
                    datosRecibidos.GetString(4),
                    datosRecibidos.GetInt32(5),
                    datosRecibidos.GetInt32(6),
                    datosRecibidos.GetInt32(7),
                    datosRecibidos.GetInt32(8),
                    datosRecibidos.GetString(9)));
            }

            bd.Cerrar();
        }

        public int insertarNotasAlumno(Matriculado alumno)
        {
            bd.Abrir();
            int datosInsertados = bd.EjecutarOrden("insert into " +
                "notas(dnialumno, anocurso, asignatura)"+
                "values (" +
                "'" + alumno.Dni + "'," +
                "" + alumno.AnoCurso + ",'" +alumno.Asignatura +"');");
            bd.Cerrar();
            return datosInsertados;
        }

        public int updatePrimerTrimestre(int nota,Alumno_Notas alumno)
        {
            bd.Abrir();
            int datosModificados = bd.EjecutarOrden("update notas set primertrimestre="+nota+
                " where dnialumno='"+alumno.Dni+"';");
            bd.Cerrar();
            return datosModificados;
        }

        public int updateSegundoTrimestre(int nota, Alumno_Notas alumno)
        {
            bd.Abrir();
            int datosModificados = bd.EjecutarOrden("update notas set segundotrimestre=" + nota +
                " where dnialumno='" + alumno.Dni + "';");
            bd.Cerrar();
            return datosModificados;
        }

        public int updateTercerTrimestre(int nota, Alumno_Notas alumno)
        {
            bd.Abrir();
            int datosModificados = bd.EjecutarOrden("update notas set tercertrimestre=" + nota +
                " where dnialumno='" + alumno.Dni + "';");
            bd.Cerrar();
            return datosModificados;
        }

        public int updateNotaGlobal(int nota, Alumno_Notas alumno)
        {
            bd.Abrir();
            int datosModificados = bd.EjecutarOrden("update notas set notaglobal=" + nota +
                " where dnialumno='" + alumno.Dni + "';");
            bd.Cerrar();
            return datosModificados;
        }



        public ObservableCollection<Alumno_Notas> GetListaNotasAlumnos()
        {
            return listaNotasAlumnos;
        }

        public void borrarListaNotasAlumnos()
        {
            listaNotasAlumnos.Clear();
        }
    }
}



