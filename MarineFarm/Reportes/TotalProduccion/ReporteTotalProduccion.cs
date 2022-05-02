using MarineFarm.Data;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Reportes.TotalProduccion
{
    /// <summary>
    /// reporte total de produccion
    /// </summary>
    public class ReporteTotalProduccion
    {
        #region props
        /// <summary>
        /// fecha de generado
        /// </summary>
        public DateTime fechaGenerado { get; set; }
        /// <summary>
        /// Inicio del periodo de solicitud
        /// </summary>
        public DateTime Inicio { get; set; }
        /// <summary>
        /// fin del pediodo
        /// </summary>
        public DateTime Fin { get; set; }
        /// <summary>
        /// datos o resultados del estudio
        /// </summary>
        public List<HeadAllReport> Estudio { get; set; }
        #endregion

        #region generate
        /// <summary>
        /// para generar un reporte, basado en los datos ingresados
        /// </summary>
        /// <param name="_in"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Generate(AllReportDTO_in _in, ApplicationDbContext context)
        {

            try
            {
                List<Marisco> maricos = new();
                if (!_in.validate())
                    return;
                this.fechaGenerado = DateTime.Now;
                this.Inicio = _in.Inicio;
                this.Fin = _in.Fin;

                foreach (var mm in _in.Mariscoid)
                    maricos.Add(await context.Mariscos.Where(y => y.id == mm).FirstOrDefaultAsync());

                var block = await context.Produccion
                    .Include(y=>y.MariscosProduccion)
                    .Include(y=>y.ProductoProduccion).ThenInclude(x=>x.Producto).ThenInclude(e=>e.Calibre)
                    .Include(y=>y.ProductoProduccion).ThenInclude(x=>x.Producto).ThenInclude(e=>e.TipoProduccion)
                    .Where(y => y.Fecha > _in.Inicio.AddDays(-1) && y.Fecha < _in.Fin.AddDays(1))
                    .ToListAsync();

                foreach (var marisco in maricos)
                    foreach (var b in block)
                    {
                        var prod = b.MariscosProduccion.Where(y => y.Mariscoid == marisco.id).FirstOrDefault();
                        var res = b.ProductoProduccion.Where(y => y.Producto.Mariscoid == marisco.id).ToList();
                        this.Estudio.Add(new(prod, res));
                    }

            }
            catch (Exception ee )
            {
                Console.WriteLine(ee.Message);
            }

            
        }

        #endregion
        

    }


}
