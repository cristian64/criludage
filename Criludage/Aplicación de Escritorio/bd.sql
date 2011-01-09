delete from propuestas;
delete from solicitudes;
delete from empleados;

drop table propuestas;
drop table solicitudes;
drop table empleados;

create table configuracion
(
	usuario varchar(1000) not null,
	contrasena varchar(1000) not null,
	activemq varchar(1000) not null,
	servicioweb varchar(1000) not null,
	pop varchar(1000) not null,
	popPuerto varchar(1000) not null,
	popContrasena varchar(1000) not null
);

-- Tabla de empleados.
create table empleados
(
	id int identity(1,1),
	usuario varchar(30) not null,
	contrasena varchar(40) not null,
	nombre varchar(50) not null,
	nif varchar(50) not null,
	correoElectronico varchar (50),
	administrador tinyint not null default 1,
	foto image,
	constraint pk_empleados_id primary key (id),
	constraint unq_empleados_usuario unique (usuario)
);

-- Tabla de solicitudes, tal como se almacena en el servicio.
-- Nótese que el idEmpleado puede ser NULL, porque si la aplicación es la de desguace, no introducirá qué empleado realizó la solicitud.
create table solicitudes
(
	id int not null,
	idCliente int not null,
	descripcion varchar(5000) not null,
	fecha datetime not null,
	fechaEntrega datetime not null,
	fechaRespuesta datetime not null,
	precioMax float(23) not null,
	negociadoAutomatico tinyint not null default 0,
	estado varchar(50) not null,
	informacionAdicional varchar(5000) not null,
	idEmpleado int,
	constraint pk_solicitudes_id primary key (id),
	constraint fk_solicitudes_idEmpleado foreign key (idEmpleado) references empleados (id) on delete set null
);

-- Tabla de propuestas.
-- Nótese que el empleado puede ser NULL. Si se trata de la aplicación de taller, no se indica qué empleado realizó la propuesta.
create table propuestas
(
	id int not null,
	idSolicitud int not null,
	idDesguace int not null,
	descripcion varchar(5000) not null,
	fechaEntrega datetime not null,
	precio float(23) not null,
	estado varchar(50) not null,
	informacionAdicional varchar(5000) not null,
	idEmpleado int,
	foto image,
	constraint pk_propuestas_id primary key (id),
	constraint fk_propuestas_idSolicitud foreign key (idSolicitud) references solicitudes (id) on delete cascade,
	constraint fk_propuestas_idEmpleado foreign key (idEmpleado) references empleados (id) on delete set null
);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('cristian', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Cristian Aguilera Martínez', '75555555A', 'cristian64@gmail.com', 1);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('damian', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Damián Moya Pérez', '75555555A', 'damianmp@gmail.com', 1);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('luis', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Luis Vivas Tejuelo', '75555555A', 'alexkidd88@gmail.com', 1);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('jorge', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Jorge Calvo Zaragoza', '75555555A', 'jcz1710@gmail.com', 1);