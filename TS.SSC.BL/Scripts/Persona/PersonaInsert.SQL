insert into Tbl_Persona
(idParroquia, cedula, nombre,nombrePadre, nombreMadre,
fechaNacimiento, lugarNacimiento, fechaBautismo, lugarBautismo,
fechaCrea,userCrea)
values
(@idParroquia, @cedula,@nombre,@nombrePadre,@nombreMadre,
@fechaNacimiento,@lugarNacimiento,@fechaBautismo,
@lugarBautismo,Getdate(),@userCrea);
SELECT SCOPE_IDENTITY();