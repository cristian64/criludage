delete from propuestas;
delete from solicitudes;
delete from desguaces;
delete from clientes;

drop table propuestas;
drop table solicitudes;
drop table desguaces;
drop table clientes;

create table clientes
(
	id int identity(1,1),
	usuario varchar(30) not null,
	contrasena varchar(40) not null,
	nombre varchar(50) not null,
	nif varchar(50) not null,
	correoElectronico varchar (50) not null,
	direccion varchar(100) not null,
	telefono varchar(100) not null,
	informacionAdicional varchar(5000) not null,
	constraint pk_clientes_id primary key (id),
	constraint unq_clientes_usuario unique (usuario)
);

create table desguaces
(
	id int identity(1,1),
	usuario varchar(30) not null,
	contrasena varchar(40) not null,
	nombre varchar(50) not null,
	nif varchar(50) not null,
	correoElectronico varchar (50) not null,
	direccion varchar(100) not null,
	telefono varchar(100) not null,
	informacionAdicional varchar(5000) not null,
	constraint pk_desguaces_id primary key (id),
	constraint unq_desguaces_usuario unique (usuario)
);

create table solicitudes
(
	id int identity(1,1),
	idCliente int not null,
	descripcion varchar(5000) not null,
	fecha datetime not null,
	fechaEntrega datetime not null,
	fechaRespuesta datetime not null,
	precioMax float(23) not null,
	negociadoAutomatico tinyint not null default 0,
	estado varchar(50) not null,
	informacionAdicional varchar(5000) not null,
	remitida tinyint not null default 0,
	constraint pk_solicitudes_id primary key (id),
	constraint fk_solicitudes_idCliente foreign key (idCliente) references clientes (id)
);

create table propuestas
(
	id int identity(1,1),
	idSolicitud int not null,
	idDesguace int not null,
	descripcion varchar(5000) not null,
	fechaEntrega datetime not null,
	precio float(23) not null,
	estado varchar(50) not null,
	informacionAdicional varchar(5000) not null,
	foto image,
	constraint pk_propuestas_id primary key (id),
	constraint fk_propuestas_idSolicitud foreign key (idSolicitud) references solicitudes (id),
	constraint fk_propuestas_idDesguace foreign key (idDesguace) references desguaces (id)
);

insert into clientes (usuario,contrasena,nombre,nif,correoElectronico,direccion,telefono,informacionAdicional) values ('gitano','qwerty','killo','12345678','gitano@yopmail.com','descampao de la esquina','1111111111','No hay informacion adicional');
