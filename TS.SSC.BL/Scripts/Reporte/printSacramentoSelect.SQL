select a.libro, a.folio, a.partida, a.fechaRegistro,a.nombrePadrino,a.nombreMadrina,a.nombreMinistro,
b.nombreSacramento,
c.nombre, c.fechaNacimiento,c.lugarNacimiento, c.nombrePadre, c.nombreMadre
from Tbl_RegistroSacramento a
inner join Tbl_Sacramentos b on a.idSacramento = b.id
inner join Tbl_Persona c on a.idPersona = c.id
where a.id = @id;