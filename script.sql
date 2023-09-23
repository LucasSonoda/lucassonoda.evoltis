IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DesafioDB')
BEGIN
    CREATE DATABASE DesafioDB;
    PRINT 'Base de datos DesafioDB creada';
END
ELSE
BEGIN
    PRINT 'La base de datos DesafioDB ya existe';
END
GO

USE DesafioDB;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Empleados')
BEGIN
    CREATE TABLE Empleados (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(30) NOT NULL,
        Apellido VARCHAR(30) NOT NULL,
        Email VARCHAR(100) NOT NULL,
        Salario DECIMAL(8,2) NOT NULL
    );
    PRINT 'Tabla Empleados creada';
END
ELSE
BEGIN
    PRINT 'La tabla Empleados ya existe';
END
GO

-- Inserta los datos si la tabla está vacía
IF NOT EXISTS (SELECT TOP 1 1 FROM Empleados)
BEGIN
    INSERT INTO Empleados (Nombre, Apellido, Email, Salario)
    VALUES
        ('Martin', 'Ramirez', 'MartinRamirez@outlook.com', 3000.00),
        ('Laura', 'Garcia', 'LauraGarcia@gmail.com', 3500.50),
        ('Carlos', 'Lopez', 'CarlosLopez@yahoo.com', 2800.75),
        ('Ana', 'Perez', 'AnaPerez@hotmail.com', 3200.25),
        ('Pedro', 'Sanchez', 'PedroSanchez@gmail.com', 4000.00),
        ('María', 'Rodriguez', 'MariaRodriguez@yahoo.com', 3100.75),
        ('Luis', 'Martinez', 'LuisMartinez@outlook.com', 2900.50),
        ('Sofia', 'Gonzalez', 'SofiaGonzalez@hotmail.com', 3800.00),
        ('Alejandro', 'Torres', 'AlejandroTorres@gmail.com', 3400.25),
        ('Isabel', 'Diaz', 'IsabelDiaz@yahoo.com', 2700.75),
        ('Miguel', 'Ortega', 'MiguelOrtega@outlook.com', 4200.50),
        ('Elena', 'Fernandez', 'ElenaFernandez@gmail.com', 3100.00),
        ('David', 'Jimenez', 'DavidJimenez@hotmail.com', 3600.25),
        ('Carolina', 'Lopez', 'CarolinaLopez@yahoo.com', 2900.75),
        ('Javier', 'Ramirez', 'JavierRamirez@gmail.com', 3300.50);
    PRINT 'Datos insertados en la tabla Empleados';
END
ELSE
BEGIN
    PRINT 'La tabla Empleados ya contiene datos, no se insertaron nuevos datos';
END
GO