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

select * from cuentas -- la columna pin se vacea luego de verificar la cuenta, ya que no lo necesita

delete from cuentas
