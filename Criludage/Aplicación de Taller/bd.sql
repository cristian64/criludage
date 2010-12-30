delete from extrapropuestas;
delete from propuestas;
delete from extrasolicitudes;
delete from solicitudes;
delete from empleados;

drop table extrapropuestas;
drop table propuestas;
drop table extrasolicitudes;
drop table solicitudes;
drop table empleados;

-- Tabla de empleados.
create table empleados
(
	id int identity(1,1),
	usuario varchar(30) not null,
	contrasena varchar(40) not null,
	nombre varchar(50),
	nif varchar(15),
	correoElectronico varchar (50),
	administrador tinyint not null default 1,
	constraint pk_empleados_id primary key (id),
	constraint unq_empleados_usuario unique (usuario)
);

-- Tabla de solicitudes, tal como se almacena en el servicio.
create table solicitudes
(
	id int not null,
	idCliente int not null,
	descripcion varchar(5000) not null,
	fecha datetime not null,
	fechaEntrega datetime not null,
	precioMax decimal not null,
	negociadoAutomatico tinyint not null default 0,
	estado varchar(50) not null,
	constraint pk_solicitudes_id primary key (id)
);

-- Indica qué empleado realizó cada solicitud y una posible información adicional (información del cliente que ha ido al taller, por ejemplo).
-- Esta tabla sólo se utiliza cuando la aplicación sea de Taller.
create table extrasolicitudes
(
	idSolicitud int not null,
	idEmpleado int not null,
	informacionAdicional varchar(5000) not null,
	constraint pk_extrasolicitudes_id primary key (idSolicitud),
	constraint fk_extrasolicitudes_idSolicitud foreign key (idSolicitud) references solicitudes (id),
	constraint fk_extrasolicitudes_idEmpleado foreign key (idEmpleado) references empleados (id)
);

-- Tabla de propuestas.
create table propuestas
(
	id int not null,
	idSolicitud int not null,
	idDesguace int not null,
	descripcion varchar(5000) not null,
	fechaEntrega datetime not null,
	precio decimal not null,
	estado varchar(50) not null,
	constraint pk_propuestas_id primary key (id),
	constraint fk_propuestas_idSolicitud foreign key (idSolicitud) references solicitudes (id)
);

-- Indica qué empleado realizó la propuesta y una posible información adicional.
-- Esta tabla sólo se utiliza cuando la aplicación sea de Desguace.
create table extrapropuestas
(
	idPropuesta int not null,
	idEmpleado int not null,
	informacionAdicional varchar(5000) not null,
	constraint pk_extrapropuestas_id primary key (idPropuesta),
	constraint fk_extrapropuestas_idPropuesta foreign key (idPropuesta) references propuestas (id),
	constraint fk_extrapropuestas_idEmpleado foreign key (idEmpleado) references empleados (id)
);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('cristian', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Cristian Aguilera Martínez', '75555555A', 'cristian64@gmail.com', 1);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('damian', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Damián Moya Pérez', '75555555A', 'damianmp@gmail.com', 1);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('luis', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Luis Vivas Tejuelo', '75555555A', 'alexkidd88@gmail.com', 1);

insert into empleados (usuario, contrasena, nombre, nif, correoElectronico, administrador)
values ('jorge', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Jorge Calvo Zaragoza', '75555555A', 'jcz1710@gmail.com', 1);