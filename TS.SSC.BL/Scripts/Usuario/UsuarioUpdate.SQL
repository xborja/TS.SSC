update Tbl_Usuario
Set
idParroquia=@idParroquia, 
userName=@userName, 
"password"=@password,
passwordHash=@passwordHash, 
tipoUsuario=@tipoUsuario, 
nombreUsuario=@nombreUsuario, 
estado=@estado,
fechaModif= getdate(), 
userModif=@userModif
where id= @id;