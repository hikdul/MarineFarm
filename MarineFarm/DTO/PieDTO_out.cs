using MarineFarm.Entitys;

namespace MarineFarm.DTO
{
    /// <summary>
    /// esta es la data que se envia para generar los pies de la pagina inicial
    /// </summary>
    public class PieDTO_out
    {
        #region props
        /// <summary>
        /// datos con totales mensuales
        /// </summary>
        public List<elemento>? mes { get; set; }
        /// <summary>
        /// datos con promedios por dia de produccion
        /// </summary>
        public List<elemento>? dia { get; set; }
        #endregion

        #region ctor
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="list"></param>
        public PieDTO_out(List<MuestraDiaria> list)
        {
            if (list == null || list.Count < 0)
                return;

            this.mes = new();
            this.dia = new();

            foreach (var item in list)
            {
                string name = $"{item.Marisco.Name} {item.TipoProduccion.Name} {item.Calibre.Name} {item.Empaquetado.Name}";
                this.mes.Add(new(name, item.TotalProducido));
                this.dia.Add(new(name, item.ProduccionDiaria));
            }

        }

        #endregion

    }

    #region subclass
    public class elemento
    {
        /// <summary>
        /// texto a mostrar
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// valor para anteponer en el pie
        /// </summary>
        public double y { get; set; }
        /// <summary>
        /// si va seleccionado o no
        /// </summary>
        public bool selected { get; set; } = false;
        /// <summary>
        /// si se desliza o no
        /// </summary>
        public bool sliced { get; set; } = false;

        public elemento(string t, double v, bool s=false)
        {
            this.name = t;
            this.y = v;
            this.selected = s;
            this.sliced = s;
        }

    }
    #endregion
}
