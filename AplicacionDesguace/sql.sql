CREATE TABLE empleados (
             id INT NOT NULL AUTO_INCREMENT,
             usuario CHAR(30) NOT NULL,
             contrasena CHAR(40) NOT NULL,
             nombre CHAR(50) NOT NULL,
             nif CHAR(50) NOT NULL,
             correoElectronico CHAR(50) NOT NULL,
             administrador tinyint NOT NULL DEFAULT 1,
             PRIMARY KEY (id)
);

insert into empleados (usuario, contrasena, correoElectronico, administrador) values ('damian', '7c4a8d09ca3762af61e59520943dc26494f8941b', 'Damián Moya Pérez', '75555555A', 'damianmp@gmail.com', 1);

CREATE TABLE solicitudes (
             id INT NOT NULL AUTO_INCREMENT,
             idCliente INT NOT NULL,
             descripcion BLOB(5000) NOT NULL,
             fecha DATE NOT NULL,
             hora TIME NOT NULL,
             fechaEntrega DATE NOT NULL,
             horaEntrega TIME NOT NULL,
             fechaRespuesta DATE NOT NULL,
             horaRespuesta TIME NOT NULL,
             precioMax FLOAT(23),
             negociadoAutomatico tinyint NOT NULL DEFAULT 1,
             estado CHAR(30) NOT NULL,
             informacionAdicional BLOB(5000) NOT NULL,
             empleado INT NOT NULL,
             PRIMARY KEY (id)
);

INSERT INTO SOLICITUDES (id, idCliente,descripcion,fecha,hora,fechaEntrega,horaEntrega,fechaRespuesta,horaRespuesta,precioMax,negociadoAutomatico,estado,informacionAdicional,idEmpleado)
VALUES  (1,1,'','1997-12-31','21:56:54','1997-12-31','21:56:54','1997-12-31','21:56:54',10.0,1,'','',1);

CREATE TABLE propuestas (
             id INT NOT NULL AUTO_INCREMENT,
             idSolicitud INT NOT NULL,
             idDesguace INT NOT NULL,
             descripcion BLOB(5000) NOT NULL,
             fechaEntrega DATE NOT NULL,
             horaEntrega TIME NOT NULL,
             precioMax FLOAT(23),
             estado CHAR(30) NOT NULL,
             informacionAdicional BLOB(5000) NOT NULL,
             PRIMARY KEY (id)
);