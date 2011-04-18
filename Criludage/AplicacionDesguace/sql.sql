CREATE TABLE empleados (
             id INTEGER PRIMARY KEY,
             usuario CHAR(30) NOT NULL,
             contrasena CHAR(40) NOT NULL,
             nombre CHAR(50) NOT NULL,
             nif CHAR(50) NOT NULL,
             correoElectronico CHAR(50) NOT NULL,
             administrador INT NOT NULL DEFAULT 1
);


CREATE TABLE solicitudes (
             id INT NOT NULL,
             idCliente INT NOT NULL,
             descripcion CHAR(500) NOT NULL,
             fecha CHAR(20) NOT NULL,
             fechaEntrega CHAR(20) NOT NULL,
             fechaRespuesta CHAR(20) NOT NULL,
             precioMax FLOAT(23),
             negociadoAutomatico INT NOT NULL DEFAULT 1,
             estado CHAR(30) NOT NULL,
             informacionAdicional CHAR(500) NOT NULL,
             idEmpleado INT NOT NULL,
             PRIMARY KEY (id)
);




CREATE TABLE propuestas (
             id INT NOT NULL,
             idSolicitud INT NOT NULL,
             idDesguace INT NOT NULL,
             descripcion CHAR(500) NOT NULL,
             fechaEntrega CHAR(20) NOT NULL,
             precioMax FLOAT(23),
             estado CHAR(30) NOT NULL,
             informacionAdicional CHAR(500) NOT NULL,
             PRIMARY KEY (id)
);