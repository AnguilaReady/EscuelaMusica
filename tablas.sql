
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
	primary key(dni)
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
	primary key(dni)
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
	personaContacto varchar(50),
    imagen varchar(100),
	activo boolean,
	primary key(dni)
);

create table matricula
(
	codigo serial,
	dniAlumno varchar(50),
	asignatura varchar(100),
	anoCurso integer,
	primary key(codigo),
	FOREIGN key (dniAlumno) references alumno(dni)
);

create table notas
(
	dniAlumno varchar(50),
	anoCurso integer,
	asignatura varchar(200),
	primerTrimestre integer,
	segundoTrimestre integer,
	tercerTrimestre integer,
	notaglobal integer,
	primary key(dniAlumno,anoCurso,asignatura),
	FOREIGN key (dniAlumno) references alumno(dni)
);

create table usuarios
(
	usuario varchar(50),
	pass varchar(50),
	primary key(usuario)
);
