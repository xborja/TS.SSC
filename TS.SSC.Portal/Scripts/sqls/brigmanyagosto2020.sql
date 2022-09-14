CREATE TABLE [dbo].[Tbl_PlantillaCalculoNomina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Estado] [bit] NULL,
	[UsuarioCrea] [varchar](20) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioModi] [varchar](20) NULL,
	[FechaModi] [datetime] NULL
) ON [PRIMARY]
CREATE TABLE [dbo].[Tbl_ParametroCalculoDet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPlantilla] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[idPeriodoOperacion] [int] NULL,
	[IdRubro] [int] NULL,
	[Operador1] [int] NULL,
	[idOperacion] [int] NULL,
	[Valor] [numeric](18, 4) NULL,
	[Porcentaje] [bit] NULL
) ON [PRIMARY]


alter table Tbl_GrupoOperacion add idPlantilla int null;
alter table Tbl_LiquidacionRol add idPlantilla int null;