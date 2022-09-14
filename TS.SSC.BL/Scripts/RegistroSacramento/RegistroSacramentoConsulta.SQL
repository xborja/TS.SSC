select a.*,
b.nombre as Parroquia,
c. nombreSacramento as Sacramento,
d.nombre as Persona
from Tbl_RegistroSacramento a
inner join Tbl_Parroquia b on a.idParroquia = b.id
inner join Tbl_Sacramentos c on a.idSacramento = c.id
inner join Tbl_Persona d on  a.idPersona = d.id
where a.idParroquia = @idParroquia
and a.id = @id;