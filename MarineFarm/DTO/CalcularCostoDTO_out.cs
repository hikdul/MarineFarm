using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para calcular el total del costo de un producto por produccion
    /// </summary>
    public class CalcularCostoDTO_out
    {
        #region props  
        /// <summary>
        /// costo minimo
        /// </summary>
        public double  min { get; set; }
        /// <summary>
        /// maximo
        /// </summary>
        public double max { get; set; }
        /// <summary>
        /// bono a pagar
        /// </summary>
        public double bono { get; set; }
        /// <summary>
        /// total minimo
        /// </summary>
        public double Tmin { get; set; }
        /// <summary>
        /// total maximo
        /// </summary>
        public double Tmax { get; set; }
        #endregion


        #region ctor   
        /// <summary>
        /// ctor
        /// </summary>
        public CalcularCostoDTO_out()
        {
            this.min = this.max = this.bono = this.Tmax = this.Tmin = 0;
        }

        #endregion

        #region llenado de datos
        /// <summary>
        /// para llenar los datos necesarios
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cantDias"></param>
        /// <param name="TotalAProducir"></param>
        /// <param name="diasLaborales"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task Up(ApplicationDbContext context, double TotalAProducir, int month)
        {
            var config = await context.Config.FirstOrDefaultAsync();
            var costos = await CostoEnTurno.CalcularCostosMm(context, config.DiasHabiles, month);

            if (config == null || config.PagoBono < 1 || config.KgBono < 1 || TotalAProducir < config.KgBono)
                this.bono = 0;
            else
                this.bono = config.PagoBono * (int)(TotalAProducir / config.KgBono);

            foreach (var calculo in costos)
            {
                if (calculo.mayor)
                    this.max = calculo.costo;
                else
                    this.min = calculo.costo;
            }

            this.Tmax = this.max + this.bono;
            this.Tmin = this.min + this.bono;


        }
        #endregion
    }




}
