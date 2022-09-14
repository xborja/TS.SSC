Insert into Tbl_Sacramentos
(nombreSacramento,
estado,
fechaCrea,
userCrea)
Values
(@nombreSacramento,
@estado,
getdate(),
@userCrea);