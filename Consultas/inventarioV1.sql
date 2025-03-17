-- docker run --name inventario-mysql -e MYSQL_ROOT_PASSWORD=contrasenyaROOT -e MYSQL_DATABASE=inventariodb -e MYSQL_USER=usuarioDB -e MYSQL_PASSWORD=contrasenyaDB -p 3306:3307 -d mysql:latest

CREATE DATABASE inventariodb;
USE inventariodb;

CREATE TABLE producto
(
    sku         BIGINT PRIMARY KEY,
    descripcion VARCHAR(255),
    existencia  INT            NOT NULL,
    precio      DECIMAL(15, 2) NOT NULL,
    costo       DECIMAL(12, 2) NOT NULL
);

CREATE TABLE cliente
(
    cui    BIGINT PRIMARY KEY,
    nit    VARCHAR(12)  NOT NULL,
    nombre VARCHAR(150) NOT NULL
);

CREATE TABLE venta
(
    id_venta      BIGINT AUTO_INCREMENT PRIMARY KEY,
    fk_id_cliente BIGINT NOT NULL,
    fecha         DATE   NOT NULL,
    monto         DECIMAL(15, 2),
    FOREIGN KEY (fk_id_cliente)
        REFERENCES cliente (cui)
);

CREATE TABLE detalle_venta
(
    id_detalle_venta BIGINT PRIMARY KEY AUTO_INCREMENT,
    fk_id_venta      BIGINT         NOT NULL,
    fk_sku           BIGINT         NOT NULL,
    cantidad         INT            NOT NULL,
    precio           DECIMAL(15, 2) NOT NULL,
    costo            DECIMAL(15, 2) NOT NULL,
    total            DECIMAL(15, 2) NOT NULL,
    FOREIGN KEY (fk_id_venta) REFERENCES venta (id_venta),
    FOREIGN KEY (fk_sku) REFERENCES producto (sku)
);
