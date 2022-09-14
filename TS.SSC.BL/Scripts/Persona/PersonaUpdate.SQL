Update Tbl_Persona
set
idParroquia= @idParroquia, 
cedula=@cedula, 
nombre=@nombre,nombrePadre=@nombrePadre, nombreMadre=@nombreMadre,
fechaNacimiento=@fechaNacimiento, lugarNacimiento=@lugarNacimiento, fechaBautismo=@fechaBautismo, 
lugarBautismo=@lugarBautismo,userModif=@userModif,fechaModif=getdate()
where id = @id;