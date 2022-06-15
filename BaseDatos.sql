\connect PruebaTecnicaBP
create table Persona(
personaid serial PRIMARY KEY,
nombre VARCHAR(200) NOT NULL,
genero VARCHAR(3) NOT NULL,
edad INT NOT NULL, 
identificacion VARCHAR(11) UNIQUE NOT NULL, 
direccion VARCHAR(200) NOT NULL, 
telefono VARCHAR(11) NOT NULL
);

create table Cliente(
clienteid serial PRIMARY KEY,
contra VARCHAR(200) NOT NULL,
estado boolean NOT NULL,
personaid INT NOT NULL,
CONSTRAINT fk_persona
      FOREIGN KEY(personaid) 
	  REFERENCES Persona(personaid)
	  ON DELETE CASCADE
);
create table TipoCuenta(
tipocuentaid serial PRIMARY KEY,
tipo varchar(12) NOT NULL
);
CREATE TABLE Cuenta(
numerocuenta int PRIMARY KEY, 
tipocuentaid INT NOT NULL,
saldoinicial DECIMAL(18,2) NOT NULL, 
estado boolean NOT NULL,
clienteid INT NOT NULL,
CONSTRAINT fk_tipocuenta
      FOREIGN KEY(tipocuentaid) 
	  REFERENCES TipoCuenta(tipocuentaid)
	  ON DELETE CASCADE,
CONSTRAINT fk_cliente
      FOREIGN KEY(clienteid) 
	  REFERENCES Cliente(clienteid)
	  ON DELETE CASCADE
);
CREATE TABLE TipoMovimiento(
tipomovimientoid serial PRIMARY KEY,
tipo varchar(8) NOT NULL
);
CREATE TABLE Movimientos(
movimientoid serial PRIMARY KEY,
fecha DATE NOT NULL,
tipomovimientoid INT NOT NULL, 
valor DECIMAL(18,2) NOT NULL, 
saldo DECIMAL(18,2) NOT NULL,
numerocuenta INT NOT NULL,
CONSTRAINT fk_tipomovimiento
      FOREIGN KEY(tipomovimientoid) 
	  REFERENCES TipoMovimiento(tipomovimientoid)
	  ON DELETE CASCADE,
CONSTRAINT fk_cuenta
      FOREIGN KEY(numerocuenta) 
	  REFERENCES Cuenta(numerocuenta)
	  ON DELETE CASCADE
);

CREATE TABLE Parametros(
parametroid serial PRIMARY KEY,
descripcion varchar(250) NOT NULL,
valor varchar(250) NOT NULL
);

INSERT INTO Parametros(descripcion, valor) VALUES('Limite diario','1000');

INSERT INTO TipoCuenta(tipo) VALUES('Ahorro');
INSERT INTO TipoCuenta(tipo) VALUES('Corriente');

INSERT INTO TipoMovimiento(tipo) VALUES('Debito');
INSERT INTO TipoMovimiento(tipo) VALUES('Credito');

INSERT INTO Persona(nombre, genero, edad, identificacion, direccion, telefono) VALUES('Juan Simbaña', 'M', 25, '17198015019', 'Calle falsa 123', 123456789);

INSERT INTO Cliente(contra, estado, personaid) VALUES('91011', true, 1);
INSERT INTO Cuenta(numerocuenta,tipocuentaid, saldoinicial, estado, clienteid) VALUES(496824,2, 10000, true, 1);