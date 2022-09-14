update Tbl_Sacramentos
set
nombreSacramento=@nombreSacramento,
estado=@estado,
fechaModif=getdate(),
userModif=@userModif
where id=@id;