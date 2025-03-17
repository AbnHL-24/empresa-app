-- Consultas para empresadb
USE empresadb;

-- 1) Obtener todos los apellidos de los empleados.
SELECT apellidos
FROM empleado;

-- 2) Obtener los apellidos de los empleados sin repeticiónes.
SELECT DISTINCT apellidos
FROM empleado;

-- 3) Obtener todos los datos de los empleados que se apellidan "Pérez".
SELECT
	*
FROM empleado
WHERE apellidos LIKE '%Pérez%';

-- 4) Obtener todos los datos de los empleados que se apellidan "Pérez"o "López"
SELECT *
FROM empleado
WHERE apellidos LIKE '%Pérez%'
   OR '%López%';

-- 5) Obtener todos los datos de los empleados que trabajan para el departamento “Contabilidad
SELECT
	e.cui_empleado,
  e.nombre,
  e.apellidos,
  e.telefono,
  e.correo,
  e.salario,
  e.fecha_ingreso,
  p.nombre AS puesto,
  d.nombre AS departamento
FROM empleado e
         JOIN puesto p ON e.fk_id_puesto = p.id_puesto
         JOIN departamento d ON p.fk_id_departamento = d.id_departamento
WHERE d.nombre = 'Contabilidad';

-- 6) Obtener todos los datos de los empleados que trabajan para el departamento “Contabilidad” y “Gerencial General”
SELECT
	e.cui_empleado,
  e.nombre,
  e.apellidos,
  e.telefono,
  e.correo,
  e.salario,
  e.fecha_ingreso,
  p.nombre AS puesto,
  d.nombre AS departamento
FROM empleado e
         JOIN puesto p ON e.fk_id_puesto = p.id_puesto
         JOIN departamento d ON p.fk_id_departamento = d.id_departamento
WHERE d.nombre = 'Contabilidad'
   OR 'Gerencia General';

-- 7) Obtener todos los datos de los empleados cuyo apellido comienza por la letra “P”
SELECT
	e.cui_empleado,
  e.nombre,
  e.apellidos,
  e.telefono,
  e.correo,
  e.salario,
  e.fecha_ingreso,
  p.nombre AS puesto,
  d.nombre AS departamento
FROM empleado e
         JOIN puesto p ON e.fk_id_puesto = p.id_puesto
         JOIN departamento d ON p.fk_id_departamento = d.id_departamento
WHERE e.apellidos LIKE 'P%'
   OR '% P%';

-- 8) Obtener el presupuesto total de todos los departamentos.
SELECT SUM(d.presupuesto) AS presupuesto_total
FROM departamento d;

-- 9) Obtener el número de empleados por cada departamento.
SELECT d.id_departamento, d.nombre, COUNT(*) AS empleados_por_departamento
FROM departamento d
				 JOIN puesto p ON d.id_departamento = p.fk_id_departamento
         JOIN empleado e ON p.id_puesto = e.fk_id_puesto
GROUP BY d.id_departamento, d.nombre;

-- 10) Obtener un listado completo de empleados, incluyendo por cada empleado los datos del empleado y de su departamento.
SELECT
	e.cui_empleado,
  e.nombre,
  e.apellidos,
  e.telefono,
  e.correo,
  e.salario,
  e.fecha_ingreso,
  p.nombre AS puesto,
  d.id_departamento,
  d.nombre AS departamento
FROM empleado e
         JOIN puesto p ON e.fk_id_puesto = p.id_puesto
         JOIN departamento d ON p.fk_id_departamento = d.id_departamento;

-- 11) Obtener un listado completo de empleados, mostrando su nombre y apellido, junto con el nombre y presupuesto del departamento. Todo ordenado descendentemente por el apellido.
SELECT e.apellidos   AS apellidos_empleado,
       e.nombre      AS nombre_empleado,
       d.nombre      AS nombre_departamento,
       d.presupuesto AS presupuesto_departamento
FROM empleado e
         JOIN puesto p ON e.fk_id_puesto = p.id_puesto
         JOIN departamento d ON p.fk_id_departamento = d.id_departamento
ORDER BY e.apellidos DESC;

-- 12) Obtener los nombres y apellidos de los empleados que trabajen en departamentos cuyo presupuesto sea mayor a 60,000.
SELECT e.nombre AS nombres_empleados, e.apellidos AS apellidos_empleados
FROM empleado e
         JOIN puesto p ON e.fk_id_puesto = p.id_puesto -- este JOIN esta de mas porque no mostras el nombre del puesto
         JOIN departamento d ON p.fk_id_departamento = d.id_departamento
WHERE d.presupuesto >= 60000;

-- 13) Obtener los datos de los departamentos cuyo presupuesto es superior al presupuesto medio de todos los departamentos.
SELECT *
FROM departamento d
WHERE d.presupuesto > (SELECT AVG(d2.presupuesto) FROM departamento d2);

-- 14) Obtener los nombres de los departamentos que tienen más de 2 empleados.
SELECT d.nombre AS nombre_departamento, COUNT(e.cui_empleado) numero_empleados
FROM departamento d
         JOIN puesto p ON d.id_departamento = p.fk_id_departamento
         JOIN empleado e ON p.id_puesto = e.fk_id_puesto
GROUP BY d.nombre
HAVING COUNT(e.cui_empleado) > 2;

-- 15) Agregar un nuevo departamento “Control de Calidad”, con presupuesto de 40,000 y código 11. Y agregar un empleado vinculado a este departamento de nombre Esther Vásquez y con DNI: 28948238
INSERT INTO departamento(id_departamento, nombre, presupuesto)
VALUES (11, 'Control de calidad', 40000);
INSERT INTO puesto(nombre, fk_id_departamento)
VALUES ('Supervisora de calidad', 11);
INSERT INTO empleado(cui_empleado, nombre, apellidos, telefono, correo, usuario, contrasenya, fk_id_puesto, salario, fecha_ultimo_aumento, fecha_ingreso, fecha_de_baja)
VALUES (28948238, 'Esther', 'Vasquez', NULL, NULL, 'estherUser', 'estherPassword', 35, 10000, NULL, '2025-03-01', NULL);

-- 16) ¿Optimice una consulta SQL lenta en MySQL? Menciona al menos tres estrategias.
    -- 1. Utilizar indices en las columnas de uso frecuente que no lo tengan por defecto como es el caso de una primary key.
    -- 2. De ser posible no usar `SELECT *` ya que dependiendo del caso pueda ser que se necesiten solo algunos campos especificos.
    -- 3. Analizar la consulta con alguna herramienta que permita identificar los cuellos de botella.


-- 17) ¿Cuál es la diferencia entre transacción y bloqueo en bases de datos?
