
-- primero declaro y obtengo todos los posibles valores necesacios

-- Marisco
GO
declare @Choritos int
declare @Navajuela int
declare @Taquilla int
declare @Luliada int
declare @Tumbao int


Select @Choritos=id from Mariscos where Name='Choritos'
Select @Navajuela=id from Mariscos where Name='Navajuela'
Select @Taquilla=id from Mariscos where Name='Taquilla'
Select @Luliada=id from Mariscos where Name='Luliada'
Select @Tumbao=id from Mariscos where Name='Tumbao'

-- tipos de produccion
declare @tpIndustrial int
declare @tpmv int
declare @tpc int
declare @tpec	int
declare @tpCarneCruda	int

select @tpIndustrial =id from TiposProduccion where Name='Industrial'
select @tpmv=id from TiposProduccion where Name='1/2 Valva'
select @tpc=id from TiposProduccion where Name='Carne'
select @tpec=id from TiposProduccion where Name='Entera Crudo'
select @tpCarneCruda=id from TiposProduccion where Name='Carne Cruda'

  
-- Calibres

declare @CSC int
declare @C5080 int
declare @C80100 int
declare @C80120 int
declare @C100200 int
declare @C200300 int
declare @C300500 int
declare @C500700 int

select @CSC = id from Calibre where Name ='S/C'
select @C5080=id from Calibres where Name='50-80'
select @C80100=id from Calibres where Name='80-100'
select @C80120=id from Calibres where Name='80-120'
select @C100200=id from Calibres where Name='100-200'
select @C200300=id from Calibres where Name='200-300'
select @C300500=id from Calibres where Name='300-500'
select @C500700=id from Calibres where Name='500-Up'

-- Empaquetados
declare @E1X10 int
declare @E1X9 int
declare @E8X1 int
declare @E1X8 int
declare @E4X335 int
declare @E2X5 int
 
select @E1X10=id from Empaquetados where Name='1 X 10'
select @E1X9=id from Empaquetados where Name='1 X 9'
select @E8X1=id from Empaquetados where Name='8 X 1'
select @E1X8=id from Empaquetados where Name='1 X 8'
select @E4X335=id from Empaquetados where Name='4 X 3.35'
select @E2X5=id from Empaquetados where Name='2 X 5'


-- ahora si inserto los datos de choritos carne 50/100 1 ano
GO
-- gererando choritos carne
-- calibre 50/100
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C50100,@E1X10,420,20)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C50100,@E1X10,420,50)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C50100,@E1X10,420,50)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C50100,@E1X10,420,100)

-- calibre 100/200

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C100200,@E1X10,420,1000)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C100200,@E1X10,420,1800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C100200,@E1X10,420,1800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C100200,@E1X10,420,2000)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C100200,@E1X10,420,2000)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C100200,@E1X10,420,900)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C100200,@E1X10,420,900)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C100200,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C100200,@E1X10,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C100200,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C100200,@E1X10,420,1000)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C100200,@E1X10,420,1500)

--calibre 200X300


insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C200300,@E1X10,420,1000)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C200300,@E1X10,420,1000)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C200300,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C200300,@E1X10,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C200300,@E1X10,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C200300,@E1X10,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C200300,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C200300,@E1X10,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C200300,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C200300,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C200300,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C200300,@E1X10,420,500)

-- calibre 300X500

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C300500,@E1X10,420,550)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C300500,@E1X10,420,550)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C300500,@E1X10,420,700)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C300500,@E1X10,420,450)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C300500,@E1X10,420,450)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C300500,@E1X10,420,700)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C300500,@E1X10,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C300500,@E1X10,420,700)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C300500,@E1X10,420,550)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C300500,@E1X10,420,550)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C300500,@E1X10,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C300500,@E1X10,420,500)

-- calibre 500/up

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@C500700,@E1X10,420,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@C500700,@E1X10,420,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@C500700,@E1X10,420,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@C500700,@E1X10,420,250)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@C500700,@E1X10,420,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@C500700,@E1X10,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@C500700,@E1X10,420,350)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@C500700,@E1X10,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@C500700,@E1X10,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@C500700,@E1X10,420,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@C500700,@E1X10,420,450)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@C500700,@E1X10,420,300)

-- sin calibre

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@Carne,@CSC,@E1X10,420,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@Carne,@CSC,@E1X10,420,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@Carne,@CSC,@E1X10,420,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@Carne,@CSC,@E1X10,420,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@Carne,@CSC,@E1X10,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@Carne,@CSC,@E1X10,420,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@Carne,@CSC,@E1X10,420,150)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@Carne,@CSC,@E1X10,420,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@Carne,@CSC,@E1X10,420,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@Carne,@CSC,@E1X10,420,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@Carne,@CSC,@E1X10,420,200)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@Carne,@CSC,@E1X10,420,300)


-- choritas media valva empaquetado 1X9

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@tpmv,@C5080,@E1X9,420,300)

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@tpmv,@C80100,@E1X9,420,300)

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@tpmv,@C80120,@E1X9,420,300)

-- choritos carne cruda colibre 4,35

insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(1,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(2,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(3,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,100)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(4,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(5,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,500)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(6,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,250)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(7,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,900)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(8,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,800)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(9,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,300)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(10,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,250)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(11,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,400)
insert into MuestrasDiarias(mes,ano,Mariscoid,TipoProduccionid,Calibreid,Empaquetadoid,TotalProducido,ProduccionDiaria)
values(12,2020,@chorito,@tpCarneCruda,@CSC,@E4X335,420,300)