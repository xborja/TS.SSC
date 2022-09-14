update Tbl_Usuario
Set
"password"=@password,
passwordHash=@passwordHash, 
fechaModif= getdate(), 
userModif=@userModif
where id= @id;