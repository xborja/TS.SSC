update Tbl_Parroquia
set
nombre=@nombre,
lugar=@lugar,
direccion=@direccion,
telefono=@telefono,
parroco=@parroco,
fechaModif=getdate(),
userModif=@userModif;
