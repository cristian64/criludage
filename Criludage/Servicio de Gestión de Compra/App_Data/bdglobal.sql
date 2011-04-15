drop database if exists criludage;
create database criludage;
use criludage;

drop table if exists registro;
drop table if exists propuestas;
drop table if exists solicitudes;
drop table if exists desguaces;
drop table if exists clientes;


create table clientes
(
        id int auto_increment,
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
) engine = innodb default charset=utf8 collate=utf8_spanish_ci;

create table desguaces
(
        id int auto_increment,
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
) engine = innodb default charset=utf8 collate=utf8_spanish_ci;

create table solicitudes
(
        id int auto_increment,
        idCliente int not null,
        descripcion varchar(5000) not null,
        fecha datetime not null,
        fechaEntrega datetime not null,
        fechaRespuesta datetime not null,
        precioMax float(23) not null,
        negociadoAutomatico tinyint not null default 0,
        estado varchar(50) not null,
        remitida tinyint not null default 0,
        sincronizada tinyint not null default 0,
        constraint pk_solicitudes_id primary key (id),
        constraint fk_solicitudes_idCliente foreign key (idCliente) references clientes (id)
) engine = innodb default charset=utf8 collate=utf8_spanish_ci;

create table propuestas
(
        id int auto_increment,
        idSolicitud int not null,
        idDesguace int not null,
        descripcion varchar(5000) not null,
        fechaEntrega datetime not null,
        precio float(23) not null,
        estado varchar(50) not null,
        foto longblob,
        confirmada tinyint not null default 0,
        constraint pk_propuestas_id primary key (id),
        constraint fk_propuestas_idSolicitud foreign key (idSolicitud) references solicitudes (id),
        constraint fk_propuestas_idDesguace foreign key (idDesguace) references desguaces (id)
) engine = innodb default charset=utf8 collate=utf8_spanish_ci;

create table registro
(
        id int auto_increment,
        fecha datetime not null,
        tipo varchar(30) not null,
        usuario varchar(30) not null,
        descripcion varchar(5000) not null,
        constraint pk_registro_id primary key (id),
        constraint ck_registro_tipo check (tipo in ('acceso', 'registro', 'solicitud', 'propuesta', 'modificación', 'otro'))
) engine = innodb default charset=utf8 collate=utf8_spanish_ci;

