
-- primero declaro y obtengo todos los posibles valores necesacios

-- Marisco
GO
declare @chorito int
declare @Choritos int
declare @Cholga int
declare @Juliada int
declare @Tumbao int
declare @Navajuela int
declare @Salmon int
declare @Culengues int
declare @Huepo int
declare @Lupa int
declare @Almeja int
declare @Piure int
declare @Pulpo int
declare @Centolla int
declare @Loco int


Select @Choritos=id from Mariscos where Name='Choritos'
Select @Cholga=id from Mariscos where Name='Cholga'
Select @Juliada=id from Mariscos where Name='Juliada'
Select @Tumbao=id from Mariscos where Name='Tumbao'
Select @Navajuela=id from Mariscos where Name='Navajuela'
Select @Salmon=id from Mariscos where Name='Salmon'
Select @Culengues=id from Mariscos where Name='Culengues'
Select @Huepo=id from Mariscos where Name='Huepo'
Select @Lupa=id from Mariscos where Name='Lupa'
Select @Almeja=id from Mariscos where Name='Almeja'
Select @Piure=id from Mariscos where Name='Piure'
Select @Pulpo=id from Mariscos where Name='Pulpo'
Select @Centolla=id from Mariscos where Name='Centolla'
Select @Loco=id from Mariscos where Name='Loco'

-- tipos de produccion
declare @tpIndustrial int
declare @tpmv int
declare @tpc int
declare @tpec	int
select @tpIndustrial =id from TiposProduccion where Name='Industrial'
select @tpmv=id from TiposProduccion where Name='1/2 Valva'
select @tpc=id from TiposProduccion where Name='Carne'
select @tpec=id from TiposProduccion where Name='Entera Crudo'

  
-- Calibres

declare @CSC int
declare @C4060 int
declare @C5080 int
declare @C80100 int
declare @C80120 int
declare @C50100 int
declare @C100200 int
declare @C200300 int
declare @C300500 int
declare @C500700 int
declare @CExclusivo int 

select @CSC = id from Calibre where Name ='S/C'
select @C4060=id from Calibres where Name='40-60'
select @C5080=id from Calibres where Name='50-80'
select @C80100=id from Calibres where Name='80-100'
select @C80120=id from Calibres where Name='80-120'
select @C50100=id from Calibres where Name='50-100'
select @C100200=id from Calibres where Name='100-200'
select @C200300=id from Calibres where Name='200-300'
select @C300500=id from Calibres where Name='300-500'
select @C500700=id from Calibres where Name='500-700'
select @CExclusivo=id from Calibres where Name='Exclusivo Corto'


-- Empaquetados
declare @E1X10 int
declare @E1X9 int
declare @E8X1 int
 
select @E1X10=id from Empaquetados where Name='1 X 10'
select @E1X9=id from Empaquetados where Name='1 X 9'
select @E8X1=id from Empaquetados where Name='8 X 1'


-- ahora si inserto los datos de choritos carne 50/100 1 ano
GO

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C50100,@E1X10,510,25)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C50100,@E1X10,630,30)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C50100,@E1X10,300,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C50100,@E1X10,240,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C50100,@E1X10,180,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C50100,@E1X10,50,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C50100,@E1X10,20,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C50100,@E1X10,50,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C50100,@E1X10,90,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C50100,@E1X10,60,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C50100,@E1X10,30,10)


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C50100,@E1X9,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C50100,@E1X9,510,25)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C50100,@E1X9,630,30)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C50100,@E1X9,300,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C50100,@E1X9,240,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C50100,@E1X9,180,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C50100,@E1X9,50,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C50100,@E1X9,20,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C50100,@E1X9,50,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C50100,@E1X9,90,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C50100,@E1X9,60,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C50100,@E1X9,30,10)




insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C50100,@E8X1,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C50100,@E8X1,510,25)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C50100,@E8X1,630,30)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C50100,@E8X1,300,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C50100,@E8X1,240,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C50100,@E8X1,180,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C50100,@E8X1,50,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C50100,@E8X1,20,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C50100,@E8X1,50,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C50100,@E8X1,90,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C50100,@E8X1,60,10)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C50100,@E8X1,30,10)
GO

-- chorito carno 100/200 all year


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C100200,@E1X10,20290,1240)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C100200,@E1X10,18930,946)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C100200,@E1X10,24252,1102)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C100200,@E1X10,30850,1402)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C100200,@E1X10,27270,1239)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C100200,@E1X10,14850,742)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C100200,@E1X10,9140,415)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C100200,@E1X10,4010,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C100200,@E1X10,6800,309)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C100200,@E1X10,12200,610)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C100200,@E1X10,25080,1254)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C100200,@E1X10,13940,697)

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C100200,@E1X9,20290,1240)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C100200,@E1X9,18930,946)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C100200,@E1X9,24252,1102)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C100200,@E1X9,30850,1402)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C100200,@E1X9,27270,1239)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C100200,@E1X9,14850,742)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C100200,@E1X9,9140,415)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C100200,@E1X9,4010,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C100200,@E1X9,6800,309)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C100200,@E1X9,12200,610)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C100200,@E1X9,25080,1254)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C100200,@E1X9,13940,697)

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C100200,@E8X1,20290,1240)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C100200,@E8X1,18930,946)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C100200,@E8X1,24252,1102)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C100200,@E8X1,30850,1402)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C100200,@E8X1,27270,1239)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C100200,@E8X1,14850,742)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C100200,@E8X1,9140,415)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C100200,@E8X1,4010,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C100200,@E8X1,6800,309)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C100200,@E8X1,12200,610)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C100200,@E8X1,25080,1254)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C100200,@E8X1,13940,697)
GO


-- Choritos carne 200/300


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C200300,@E1X10,30810,1400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C200300,@E1X10,31335,1566)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C200300,@E1X10,24252,1107)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C200300,@E1X10,12370,618)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C200300,@E1X10,8000,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C200300,@E1X10,23200,1080)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C200300,@E1X10,11240,562)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C200300,@E1X10,15000,750)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C200300,@E1X10,17290,365)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C200300,@E1X10,13730,686)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C200300,@E1X10,22380,1119)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C200300,@E1X10,19670,983)

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C200300,@E1X9,30810,1400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C200300,@E1X9,31335,1566)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C200300,@E1X9,24252,1107)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C200300,@E1X9,12370,618)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C200300,@E1X9,8000,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C200300,@E1X9,23200,1080)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C200300,@E1X9,11240,562)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C200300,@E1X9,15000,750)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C200300,@E1X9,17290,365)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C200300,@E1X9,13730,686)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C200300,@E1X9,22380,1119)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C200300,@E1X9,19670,983)

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C200300,@E8X1,30810,1400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C200300,@E8X1,31335,1566)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C200300,@E8X1,24252,1107)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C200300,@E8X1,12370,618)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C200300,@E8X1,8000,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C200300,@E8X1,23200,1080)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C200300,@E8X1,11240,562)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C200300,@E8X1,15000,750)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C200300,@E8X1,17290,365)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C200300,@E8X1,13730,686)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C200300,@E8X1,22380,1119)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C200300,@E8X1,19670,983)
GO


-- Chorita Carne 300/500 All Year

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C300500,@E8X1,18920,946)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C300500,@E8X1,23730,1186)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C300500,@E8X1,22000,1100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C300500,@E8X1,12370,618)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C300500,@E8X1,10880,1230)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C300500,@E8X1,14930,746)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C300500,@E8X1,13010,650)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C300500,@E8X1,17450,872)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C300500,@E8X1,12070,603)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C300500,@E8X1,16750,837)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C300500,@E8X1,13610,680)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C300500,@E8X1,11700,585)




insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C300500,@E1X10,18920,946)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C300500,@E1X10,23730,1186)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C300500,@E1X10,22000,1100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C300500,@E1X10,12370,618)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C300500,@E1X10,10880,1230)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C300500,@E1X10,14930,746)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C300500,@E1X10,13010,650)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C300500,@E1X10,17450,872)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C300500,@E1X10,12070,603)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C300500,@E1X10,16750,837)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C300500,@E1X10,13610,680)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C300500,@E1X10,11700,585)


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C300500,@E1X9,18920,946)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C300500,@E1X9,23730,1186)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C300500,@E1X9,22000,1100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C300500,@E1X9,12370,618)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C300500,@E1X9,10880,1230)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C300500,@E1X9,14930,746)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C300500,@E1X9,13010,650)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C300500,@E1X9,17450,872)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C300500,@E1X9,12070,603)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C300500,@E1X9,16750,837)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C300500,@E1X9,13610,680)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C300500,@E1X9,11700,585)

GO

-- Chorito carno 500/Up all year


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C500700,@E1X9,2840,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C500700,@E1X9,2110,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C500700,@E1X9,2300,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C500700,@E1X9,2140,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C500700,@E1X9,1230,12)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C500700,@E1X9,2040,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C500700,@E1X9,2960,30)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C500700,@E1X9,3420,34)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C500700,@E1X9,2290,22)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C500700,@E1X9,2620,26)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C500700,@E1X9,2290,22)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C500700,@E1X9,2290,22)


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C500700,@E1X10,2840,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C500700,@E1X10,2110,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C500700,@E1X10,2300,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C500700,@E1X10,2140,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C500700,@E1X10,1230,12)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C500700,@E1X10,2040,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C500700,@E1X10,2960,30)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C500700,@E1X10,3420,34)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C500700,@E1X10,2290,22)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C500700,@E1X10,2620,26)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C500700,@E1X10,2290,22)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C500700,@E1X10,2290,22)


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C500700,@E8X1,2840,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C500700,@E8X1,2110,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C500700,@E8X1,2300,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C500700,@E8X1,2140,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C500700,@E8X1,1230,12)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C500700,@E8X1,2040,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C500700,@E8X1,2960,30)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C500700,@E8X1,3420,34)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C500700,@E8X1,2290,22)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C500700,@E8X1,2620,26)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C500700,@E8X1,2290,22)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C500700,@E8X1,2290,22)

GO

-- chorita Carne Industrial


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C500700,@E8X1,9020,410)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C500700,@E8X1,10530,526)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C500700,@E8X1,9980,499)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C500700,@E8X1,6030,301)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C500700,@E8X1,6030,334)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C500700,@E8X1,7690,384)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C500700,@E8X1,4210,210)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C500700,@E8X1,4580,229)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C500700,@E8X1,4150,207)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C500700,@E8X1,4060,203)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C500700,@E8X1,8010,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C500700,@E8X1,5620,282)


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C500700,@E1X10,9020,410)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C500700,@E1X10,10530,526)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C500700,@E1X10,9980,499)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C500700,@E1X10,6030,301)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C500700,@E1X10,6030,334)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C500700,@E1X10,7690,384)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C500700,@E1X10,4210,210)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C500700,@E1X10,4580,229)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C500700,@E1X10,4150,207)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C500700,@E1X10,4060,203)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C500700,@E1X10,8010,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C500700,@E1X10,5620,282)


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@Carne,@C500700,@E1X9,9020,410)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@Carne,@C500700,@E1X9,10530,526)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@Carne,@C500700,@E1X9,9980,499)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@Carne,@C500700,@E1X9,6030,301)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@Carne,@C500700,@E1X9,6030,334)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@Carne,@C500700,@E1X9,7690,384)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@Carne,@C500700,@E1X9,4210,210)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@Carne,@C500700,@E1X9,4580,229)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@Carne,@C500700,@E1X9,4150,207)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@Carne,@C500700,@E1X9,4060,203)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@Carne,@C500700,@E1X9,8010,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@Carne,@C500700,@E1X9,5620,282)


-- chorito 1/2 valva S/C E[all] all year



insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@tpmv,@CSC,@E1X9,11844,538)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@tpmv,@CSC,@E1X9,10422,521)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@tpmv,@CSC,@E1X9,9540,499)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@tpmv,@CSC,@E1X9,1629,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@tpmv,@CSC,@E1X9,3546,177)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@tpmv,@CSC,@E1X9,12313,615)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@tpmv,@CSC,@E1X9,3105,115)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@tpmv,@CSC,@E1X9,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@tpmv,@CSC,@E1X9,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@tpmv,@CSC,@E1X9,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@tpmv,@CSC,@E1X9,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@tpmv,@CSC,@E1X9,0,100)



insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@tpmv,@CSC,@E1X10,11844,538)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@tpmv,@CSC,@E1X10,10422,521)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@tpmv,@CSC,@E1X10,9540,499)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@tpmv,@CSC,@E1X10,1629,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@tpmv,@CSC,@E1X10,3546,177)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@tpmv,@CSC,@E1X10,12313,615)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@tpmv,@CSC,@E1X10,3105,115)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@tpmv,@CSC,@E1X10,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@tpmv,@CSC,@E1X10,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@tpmv,@CSC,@E1X10,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@tpmv,@CSC,@E1X10,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@tpmv,@CSC,@E1X10,0,100)

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(1 ,2020,@chorito,@tpmv,@CSC,@E8X1,11844,538)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(2 ,2020,@chorito,@tpmv,@CSC,@E8X1,10422,521)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(3 ,2020,@chorito,@tpmv,@CSC,@E8X1,9540,499)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(4 ,2020,@chorito,@tpmv,@CSC,@E8X1,1629,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(5 ,2020,@chorito,@tpmv,@CSC,@E8X1,3546,177)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(6 ,2020,@chorito,@tpmv,@CSC,@E8X1,12313,615)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(7 ,2020,@chorito,@tpmv,@CSC,@E8X1,3105,115)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(8 ,2020,@chorito,@tpmv,@CSC,@E8X1,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(9 ,2020,@chorito,@tpmv,@CSC,@E8X1,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(10,2020,@chorito,@tpmv,@CSC,@E8X1,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(11,2020,@chorito,@tpmv,@CSC,@E8X1,0,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)values(12,2020,@chorito,@tpmv,@CSC,@E8X1,0,100)