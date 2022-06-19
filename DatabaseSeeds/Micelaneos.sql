USE [aspnet-MarineFarm]
GO

--en este documento se encuentran los datos base para la generacion de productos

--empecemos con los mariscos    -- Producto

insert into Mariscos([Name],[Desc],act) values ('Choritos','Choritos',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Luliada','Luliada',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Tumbao','Tumbao',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Navajuela','Navajuela',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Taquilla','Taquilla',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Surtido','Surtido',1)
GO
-- ahora el tipo de produccion  -- Variedad

insert into TiposProduccion([Name],[Desc],act) values ('Entero VP','Entero VP',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('Entera','Entera',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('Entero Granel','Entero Granel',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('1/2 Valva','1/2 Valva',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('Carne','Carne',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('Entera Crudo','Entera Crudo',1)
GO

-- Calibres

insert into Calibres([Name],[Desc],act) values ('S/C','S/C',1)
GO
insert into Calibres([Name],[Desc],act) values ('40-70','40-70',1)
GO
insert into Calibres([Name],[Desc],act) values ('40-80','40-80',1)
GO
insert into Calibres([Name],[Desc],act) values ('50-80','50-80',1)
GO
insert into Calibres([Name],[Desc],act) values ('50-100','50-100',1)
GO
insert into Calibres([Name],[Desc],act) values ('80-100','80-100',1)
GO
insert into Calibres([Name],[Desc],act) values ('80-120','80-120',1)
GO
insert into Calibres([Name],[Desc],act) values ('100-200','100-200',1)
GO
insert into Calibres([Name],[Desc],act) values ('100-300','100-300',1)
GO
insert into Calibres([Name],[Desc],act) values ('200-300','200-300',1)
GO
insert into Calibres([Name],[Desc],act) values ('300-500','300-500',1)
GO
insert into Calibres([Name],[Desc],act) values ('500-Up','500-Up',1)
GO

-- por ultimo el empaquetado

insert into Empaquetados([Name],[Desc],act) values('1 X 10', '1 X 10', 1)
GO
insert into Empaquetados([Name],[Desc],act) values('1 X 9', '1 X 9', 1)
GO
insert into Empaquetados([Name],[Desc],act) values('8 X 1', '8 X 1', 1)
GO
insert into Empaquetados([Name],[Desc],act) values('1 X 8', '1 X 8', 1)
GO
insert into Empaquetados([Name],[Desc],act) values('4 X 3.35', '4 X 3.35', 1)
GO
insert into Empaquetados([Name],[Desc],act) values('2 X 5', '2 X 5', 1)
GO
-- agrego mi propio super usuario

 insert into AspNetUsuario(Nombre,rut,Email,Telefono,Rol,act,Userid)
 values ('Hector Contreras','0','hikdul.dev@gmail.com','0','Administrador Del Sistema',1,'445f6fc1-5dd4-4c32-af61-19a91b8f1367')
GO

 insert into AspNetUsuario(Nombre,rut,Email,Telefono,Rol,act,Userid)
 values ('Angel Vargal','0','comercial.granjamar@gmail.com','0','Administrador Del Sistema',1,'1e20113c-7fef-c00-90b7-c286fba79757')