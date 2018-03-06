
create table empleado
(
	dni varchar(50),
	nombre varchar(50),
	apellidos varchar(50),
	fechaNacimiento date,
	fechaAlta date,
	telefono varchar(15),
	direccion varchar(100),
    imagen varchar(100),
	activo boolean,
	primary key(dni,fechaNacimiento)
)

create table profesor
(
	dni varchar(50),
	nombre varchar(50),
	apellidos varchar(50),
	fechaNacimiento date,
	fechaAlta date,
	telefono varchar(15),
	direccion varchar(100),
	estudios varchar(200),
    imagen varchar(100),
	activo boolean,
	primary key(dni,fechaNacimiento)
)

create table alumno
(
	dni varchar(50),
	nombre varchar(50),
	apellidos varchar(50),
	fechaNacimiento date,
	fechaAlta date,
	telefono varchar(15),
	direccion varchar(100),
	estudios varchar(200),
	anoCurso integer,
	personaContacto varchar(50),
    imagen varchar(100),
	activo boolean,
	primary key(dni,fechaNacimiento)
);

create table asignatura
(
	codigoAsignatura varchar(10),
	nombre varchar(10),
	primary Key(codigoAsignatura)
)

create table matriculado
(
	codigoAlumno varchar(10) references alumno(codigoalumno),
	codigoProfesor varchar(10)references profesor(codigoprofesor),
	codigoAsignatura varchar(10) references asignatura(codigoasignatura),
	primary key(codigoAlumno,codigoProfesor,codigoAsignatura)
);

create table usuarios
(
	usuario varchar(50),
	pass varchar(50),
	primary key(usuario)
);
