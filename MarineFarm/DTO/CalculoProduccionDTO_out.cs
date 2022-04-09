using AutoMapper;
using MarineFarm.Data;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para entregar informacion generica de el tiempo de entrega de un producto
    /// </summary>
    public class CalculoProduccionDTO_out 
    {
        #region props
        /// <summary>
        /// marisco id
        /// </summary>
        public string Mariscoid { get; set; }
        /// <summary>
        /// Tipo de produccion id
        /// </summary>
        public string TipoProduccionid { get; set; }
        /// <summary>
        /// Calibre id
        /// </summary>
        public string Calibreid { get; set; }
        /// <summary>
        /// Empaquetado id
        /// </summary>
        public string Empaquetadoid { get; set; }
        /// <summary>
        /// Marisco
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Tipo de produccion
        /// </summary>
        public string TipoProduccion { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        public string Calibre { get; set; }
        /// <summary>
        /// Empaquetado
        /// </summary>
        public string Empaquetado { get; set; }
        /// <summary>
        /// Cantidad de dias para producir
        /// </summary>
        public double dias { get; set; }
        /// <summary>
        /// posible fecha de entrega
        /// </summary>
        public DateTime PosibleEntrega { get; set; }
        /// <summary>
        /// true => Indicar que si hay muestra 
        /// False => Insdica que se uso el calculo por defecto
        /// </summary>
        public bool UsaMuestra { get; set; } = false;

        #endregion


        #region Calcular

        /// <summary>
        /// Para retornar una lista con los datos de los calculos. para ser usados en varias funciones
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static async Task<List<CalculoProduccionDTO_out>> Calcular(PedidoDTO_in ins, ApplicationDbContext context, IMapper mapper)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            List<CalculoProduccionDTO_out> resp = new();

            double valorDefaultDia = 1000;

            try
            {
                foreach (var item in ins.Productos)
                {

                    var muestra = await context.MuestrasDiarias
                        .Include(y => y.Marisco)
                        .Include(y => y.TipoProduccion)
                        .Include(y => y.Calibre)
                        .Include(y => y.Empaquetado)
                        .Where(y =>
                   y.ano > year - 5
                   && y.mes == month
                   && y.Mariscoid == item.Mariscoid
                   && y.TipoProduccionid == item.TipoProduccionid
                   && y.Calibreid == item.Calibreid
                   && y.Empaquetadoid == item.Empaquetadoid)
                        .ToListAsync();

                    if (muestra.Count() > 0)
                    {
                        var dto = mapper.Map<CalculoProduccionDTO_out>(muestra[0]);

                        double prodDiaria = 0;
                        muestra.ForEach(y => prodDiaria += y.ProduccionDiaria);
                        prodDiaria = prodDiaria / muestra.Count();
                        dto.dias = item.Cantidad / prodDiaria;

                        dto.PosibleEntrega = Periodo.DiasValidos(ins.fecha, dto.dias);   // DateTime.Now.AddDays(auxd);
                        dto.UsaMuestra = true;
                        resp.Add(dto);
                    }
                    else
                    {

                        var flag = new MuestraDiaria()
                        {
                            ano = year,
                            mes = month,
                            Mariscoid = item.Mariscoid,
                            TipoProduccionid = item.TipoProduccionid,
                            Calibreid = item.Calibreid,
                            Empaquetadoid = item.Empaquetadoid,
                            Marisco = await context.Mariscos.Where(y => y.id == item.Mariscoid).FirstOrDefaultAsync(),
                            TipoProduccion = await context.TiposProduccion.Where(y => y.id == item.TipoProduccionid).FirstOrDefaultAsync(),
                            Calibre = await context.Calibres.Where(y => y.id == item.Calibreid).FirstOrDefaultAsync(),
                            Empaquetado = await context.Empaquetados.Where(y => y.id == item.Empaquetadoid).FirstOrDefaultAsync(),
                            ProduccionDiaria = valorDefaultDia,
                            TotalProducido = 0
                        };
                        var dto = mapper.Map<CalculoProduccionDTO_out>(flag);
                        dto.dias = item.Cantidad / valorDefaultDia;
                        dto.PosibleEntrega = Periodo.DiasValidos(ins.fecha, dto.dias);
                        dto.UsaMuestra = false;
                        resp.Add(dto);

                    }
                }


            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);

            }


            return resp;
        }


        #endregion


        #region Calcular Fecha de entrega
        /// <summary>
        /// da solo el resultado de la fecha de entrega
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<DateTime> CalcularFechaEntrega(PedidoDTO_in ins, ApplicationDbContext context)
        {
            var fechaEntrega = DateTime.Now;
            double dias = 0;

            try
            {

                foreach (var item in ins.Productos)
                {

                    var muestra = await context.MuestrasDiarias
                        .Where(y =>
                   y.ano > fechaEntrega.Year - 5
                   && y.mes == fechaEntrega.Month
                   && y.Mariscoid == item.Mariscoid
                   && y.TipoProduccionid == item.TipoProduccionid
                   && y.Calibreid == item.Calibreid
                   && y.Empaquetadoid == item.Empaquetadoid)
                        .ToListAsync();

                    if (muestra.Count() > 0)
                    {
                        double prodDiaria = 0;
                        muestra.ForEach(y => prodDiaria += y.ProduccionDiaria);
                        prodDiaria = prodDiaria / muestra.Count();
                        double dia = item.Cantidad / prodDiaria;
                        if (dia > dias)
                            dias = dia;
                        
                    }
                }


                }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }

            return fechaEntrega.AddDays(dias);
        }


        #endregion


        #region ver mayor fecha

        /// <summary>
        /// para que me entrego la fecha con el valor de mas valor
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DateTime VerMayor(List<CalculoProduccionDTO_out> list)
        {
            var mayor = DateTime.Now;

            foreach (var item in list)
                if(item.PosibleEntrega > mayor)
                    mayor = item.PosibleEntrega;
            return mayor;
        }

        #endregion
    }
}
