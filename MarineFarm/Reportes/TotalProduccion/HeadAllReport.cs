using MarineFarm.Entitys;

namespace MarineFarm.Reportes.TotalProduccion
{
    /// <summary>
    /// Contiene los datos de cabecera del reporte
    /// </summary>
    public class HeadAllReport
    {
        #region props
        /// <summary>
        /// marisco de estudio
        /// </summary>
        public Marisco Marisco { get; set; }
        /// <summary>
        /// contidad utilizada
        /// </summary>
        public double CantidadUtilizada { get; set; }
        /// <summary>
        /// merma generada durante el periodo
        /// </summary>
        public double Merma { get; set; }
        /// <summary>
        /// Para indicar el rendimiento en baso a la produccion
        /// este valor se da porcentual
        /// </summary>
        /// <value></value>
        public double Rendimiento { get; set; }

        /// <summary>
        /// cantidad de elementos obtenidos
        /// </summary>
        public List<loopAllReport>  loop{ get; set; }
        /// <summary>
        /// para indicar algo en caso de ser necesario
        /// </summary>
        public string Mensaje { get; set; } = string.Empty;

        #endregion

        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public HeadAllReport()
        {
            this.loop = new();
        }
        /// <summary>
        /// para llenar este elemento
        /// </summary>
        /// <param name="marisco"></param>
        /// <param name="produccion"></param>
        public HeadAllReport(PMariscoProduccion marisco, List<PProductoProduccion>  produccion)
        {
            this.loop = new();
            double AcumProducido = 0;
            this.Merma = 0;


            if (marisco == null || produccion == null || produccion.Count < 1)
            {
                this.Mensaje = $"no hay elementos producidos";
                return;
            }
            else
                this.Mensaje = String.Empty;

            this.Marisco = marisco.Marisco;
            this.CantidadUtilizada = marisco.CantidadUtilizada;

            foreach (var item in produccion)
            {
                this.loop.Add(new(item.Producto.TipoProduccion, item.Producto.Calibre, item.CantidadProducida));
                AcumProducido += item.CantidadProducida;
            }

            this.Merma = marisco.CantidadUtilizada - AcumProducido < 0 ? 0 : marisco.CantidadUtilizada - AcumProducido;
            this.Rendimiento = AcumProducido*100 / this.CantidadUtilizada;
        }

        #endregion
    }
}
