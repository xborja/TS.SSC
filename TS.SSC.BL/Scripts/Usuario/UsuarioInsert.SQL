insert into Tbl_Usuario
(idParroquia, userName, "password",passwordHash, 
tipoUsuario, nombreUsuario, estado,
fechaCrea, userCrea)
values
(
@idParroquia, @userName, @password,@passwordHash, 
@tipoUsuario, @nombreUsuario, @estado,
getdate(), @userCrea
)