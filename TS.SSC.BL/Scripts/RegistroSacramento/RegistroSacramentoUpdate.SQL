Update Tbl_RegistroSacramento
set
idParroquia=@idParroquia,
idPersona=@idPersona,
idSacramento=@idSacramento,
fechaRegistro=@fechaRegistro,
libro=@libro,
folio=@folio,
partida=@partida,
nombrePadrino=@nombrePadrino,
nombreMadrina=@nombreMadrina,
nombreMinistro=@nombreMinistro,
nombreDaFe=@nombreDaFe,
fechaModif = getdate(),
userModif = @userModif
where id=@id