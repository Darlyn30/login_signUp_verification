create database SendMail3

use sendMail3

create table cuentas
(
	Nombre varchar(255) not null,
	Email varchar(255) not null primary key,
	Clave varchar(255) not null,
	Estatus BIT,
	pin varchar(8)
)

create table sesion 
(
	Id int identity(1,1) primary key,
	Email varchar(255),
	Nombre varchar(255),
	Clave varchar(255),
	Estatus BIT,
	pin varchar(4),
)

create table cuenta_creadas --esta columna se guardara a traves de un disparador
(
	Id int identity(1,1) primary key,
	Pin varchar(4),
	Email varchar(255),

	foreign key(Email) references cuentas(Email)

)

alter table cuenta_creadas add Nombre varchar(255)
alter table cuenta_creadas add Clave varchar(255)

select * from cuenta_creadas

delete from cuenta_creadas


alter trigger almacenarPin
on cuentas
after insert
as
begin
	insert into cuenta_creadas(Email, Pin, Nombre, Clave)
	select Email, pin, Nombre, Clave
	from inserted
end


--este trigger se encarga de que la cuenta sea verificada luego de ingresar el codigo de verificacion que recibe por gmail

create trigger changeEstatus
on cuenta_creadas
instead of delete
as
begin
	    -- Actualizamos el campo Estatus en la tabla cuentas
    UPDATE c
    SET c.Estatus = 1  -- Cambia Estatus a 1 (activo)
    FROM cuentas AS c
    INNER JOIN deleted AS d ON c.Email = d.Email;

    -- Ahora procedemos con la eliminación del registro en cuenta_creadas
    DELETE FROM cuenta_creadas
end


select * from sesion

delete from sesion

select * from cuentas -- la columna pin se vacea luego de verificar la cuenta, ya que no lo necesita

delete from cuentas

CREATE PROCEDURE sp_ConsultaEInsertaEnSesion
    @Email varchar(255)
AS
BEGIN
    -- Selecciona los datos de la tabla cuentas
    DECLARE @Nombre varchar(255);
    DECLARE @Clave varchar(255);
    DECLARE @Estatus BIT;
    DECLARE @Pin varchar(4);

    SELECT 
        @Nombre = Nombre, 
        @Clave = Clave, 
        @Estatus = Estatus, 
        @Pin = pin
    FROM cuentas
    WHERE Email = @Email;

    -- Inserta los datos en la tabla sesion
    INSERT INTO sesion (Nombre, Email, Clave, Estatus, pin)
    VALUES (@Nombre, @Email, @Clave, @Estatus, @Pin);

    -- Devuelve los datos seleccionados, si también quieres mostrarlos como resultado
    SELECT @Nombre AS Nombre, @Email AS Email, @Clave AS Clave, @Estatus AS Estatus, @Pin AS pin;
END;

select * from sesion



delete from sesion

delete from cuentas

select * from cuentas

