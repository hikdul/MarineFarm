using MarineFarm.Data;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.DTO
{
    public class CostoEnTurno
    {
        #region props
        /// <summary>
        /// turno al que pertenece
        /// </summary>
        public int turnoid { get; set; }
        /// <summary>
        /// costo por dia para este turno
        /// </summary>
        public double  costo{ get; set; }
        /// <summary>
        /// si es el valor de mayor valor
        /// </summary>
        public bool mayor { get; set; }
        #endregion


        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public CostoEnTurno(double costo,bool mayor=true)
        {
            this.turnoid = 0;
            this.costo = costo;
            this.mayor = mayor;
        }
        #endregion



        #region calcular costos diario por turno
        /// <summary>
        /// retorna los valores maximo y minimo  de costos para un ano y mes especifico... 
        /// dando como costo el valos de 1 dia de traxajo 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="laborables"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static async Task<List<CostoEnTurno>> CalcularCostosMm(ApplicationDbContext context,int laborables,int month)
        {
            List<CostoEnTurno> ret = new();
            CostoEnTurno mayor = new(0,false);
            CostoEnTurno menor = new(double.MaxValue);

            int DiasHabiles = totalDiasHabiles(laborables, month);

            var turnos = await context.Turnos.Where(x => x.act == true).ToListAsync();

            if (turnos == null || turnos.Count < 0)
                return ret;

            foreach (var item in turnos)
            {
                var ent = await context.Equipos.Where(x => x.Turnoid == item.id).ToListAsync();
                double costo = 0;

                if (ent != null && ent.Count != 0)
                    foreach (var emp in ent)
                    {
                        costo += emp.CostoOperario * emp.CantCubierta;
                        costo = costo / DiasHabiles;
                    }

                if (menor.costo > costo)
                {
                    menor.turnoid = item.id;
                    menor.costo = costo;
                    menor.mayor = false;
                }
                if (mayor.costo < costo)
                {
                    mayor.turnoid = item.id;
                    mayor.costo = costo;
                    mayor.mayor = true;
                }
            }

            if (mayor.turnoid != 0)
                ret.Add(mayor);
            if (menor.turnoid != 0)
                ret.Add(menor);

            return ret;
        }


        /// <summary>
        /// para ver la cantidad de dias que se laboro 
        /// </summary>
        /// <param name="laborables"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int totalDiasHabiles(int laborables, int month)
        {


            laborables = laborables > 7 ? 5 : laborables;
            laborables = laborables < 1 ? 5 : laborables;
            
            int dias = 31;

            if (month == 2)
                dias = 28;
            if (month == 4 || month == 6 || month == 9 || month == 11)
                dias = 30;
             
            int semanas =(int)( dias / laborables);
            int descansos = semanas * (7 - laborables);

            return (int)(dias - descansos);
        }

        
        #endregion

    }
}
