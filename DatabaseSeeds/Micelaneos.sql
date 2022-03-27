USE [aspnet-MarineFarm]
GO

--en este documento se encuentran los datos base para la generacion de productos

--empecemos con los mariscos

insert into Mariscos([Name],[Desc],act) values ('Choritos','Choritos',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Cholga','Cholga',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Juliada','Juliada',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Tumbao','Tumbao',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Navajuela','Navajuela',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Salmon','Salmon',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Culengues','Culengues',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Huepo','Huepo',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Lupa','Lupa',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Almeja','Almeja',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Piure','Piure',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Pulpo','Pulpo',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Centolla','Centolla',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Loco','Loco',1)
GO
insert into Mariscos([Name],[Desc],act) values ('Varios Al Vacio','Varios Al Vacio',1)
GO
-- ahora el tipo de produccion

insert into TiposProduccion([Name],[Desc],act) values ('Industrial','Industrial',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('1/2 Valva','1/2 Valva',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('Carne IQE','Carne IQE',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('Carne','Carne',1)
GO
insert into TiposProduccion([Name],[Desc],act) values ('Entera Crudo','Entera Crudo',1)
GO

-- Calibres

insert into Calibres([Name],[Desc],act) values ('S/C','S/C',1)
GO
insert into Calibres([Name],[Desc],act) values ('40-60','40-60',1)
GO
insert into Calibres([Name],[Desc],act) values ('50-80','50-80',1)
GO
insert into Calibres([Name],[Desc],act) values ('80-100','80-100',1)
GO
insert into Calibres([Name],[Desc],act) values ('80-120','80-120',1)
GO
insert into Calibres([Name],[Desc],act) values ('50-100','50-100',1)
GO
insert into Calibres([Name],[Desc],act) values ('100-200','100-200',1)
GO
insert into Calibres([Name],[Desc],act) values ('200-300','200-300',1)
GO
insert into Calibres([Name],[Desc],act) values ('300-500','300-500',1)
GO
insert into Calibres([Name],[Desc],act) values ('500-700','500-700',1)
GO
insert into Calibres([Name],[Desc],act) values ('Exclusivo Corto','Exclusivo Corto',1)
GO

-- por ultimo el empaquetado

insert into Empaquetados([Name],[Desc],act) values('1 X 10', '1 X 10', 1)
GO
insert into Empaquetados([Name],[Desc],act) values('1 X 9', '1 X 9', 1)
GO
insert into Empaquetados([Name],[Desc],act) values('8 X 1', '8 X 1', 1)
GO