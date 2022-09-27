CREATE DATABASE sin;
USE sin;

CREATE TABLE puesto (
	codigo_puesto VARCHAR(5),
    nombre_puesto VARCHAR(60),
    estatus_puesto VARCHAR(1),
    PRIMARY KEY (codigo_puesto)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE departamento (
	codigo_departamento VARCHAR(5),
    nombre_departamento VARCHAR(80),
    estatus_departamento VARCHAR(1),
    PRIMARY KEY (codigo_departamento)	
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE horasTrabajadas (
    codigo_horas_trabajadas VARCHAR(5),
    fecha date,
    hora_entrada VARCHAR(10),
    hora_salida VARCHAR(10),
    horas_totales VARCHAR(10),
    PRIMARY KEY (codigo_horas_trabajadas)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE empleado (
    codigo_empleado VARCHAR(5),
    nombre_empleado VARCHAR(60),
    codigo_puesto VARCHAR(5),
    codigo_departamento VARCHAR(5),
    codigo_horas_trabajadas VARCHAR(5),
    sueldo_empleado FLOAT(10,2),
    estatus_empleado VARCHAR(1),
    PRIMARY KEY (codigo_empleado),
    CONSTRAINT FK_puestoempleado FOREIGN KEY (codigo_puesto) REFERENCES puesto (codigo_puesto),
    CONSTRAINT FK_departamentoempleado FOREIGN KEY (codigo_departamento) REFERENCES departamento (codigo_departamento),
    CONSTRAINT FK_horasTrabajadasempleado FOREIGN KEY (codigo_horas_trabajadas) REFERENCES horasTrabajadas (codigo_horas_trabajadas)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


