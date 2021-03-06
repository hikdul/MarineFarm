using MarineFarm.Data;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

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


        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public ReporteTotalProduccion()
        {
            this.fechaGenerado = this.Inicio = this.Fin = DateTime.Now;
            this.Estudio = new();
        }
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
                    .Include(y=>y.MariscosProduccion).ThenInclude(y=>y.Marisco)
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
                clear();
                Reduce();

            }
            catch (Exception ee )
            {
                Console.WriteLine(ee.Message);
            }

            
        }

        /// <summary>
        /// para organizar el reporte
        /// </summary>
        public void Reduce()
        {
            List<HeadAllReport> copy = this.Estudio;
            List<HeadAllReport> finaly=new();
            List<int> usados = new();
            foreach (var item in copy)
            {
                if (!usados.Contains(item.Marisco.id))
                {
                    usados.Add(item.Marisco.id);

                    HeadAllReport headBand = new();
                    double AMerma = 0;
                    double AUtilizado = 0;
                    var complete = copy.Where(y => y.Marisco.id == item.Marisco.id).ToList();
                    foreach (var ind in complete)
                    {
                        AUtilizado += ind.CantidadUtilizada;
                        AMerma += ind.Merma;
                        List<twoInt> tiTemp = new();
                        double cantProducida = 0;
                        
                        foreach (var prod in ind.loop)
                            if(tiTemp.FirstOrDefault(ti=>ti.entero1== prod.TipoProd.id && ti.entero2 == prod.Calibre.id) == null)
                            {
                                tiTemp.Add(new(prod.TipoProd.id, prod.Calibre.id));

                                var todos = ind.loop
                                    .Where(y => y.TipoProd.id == prod.TipoProd.id
                                && y.Calibre.id == prod.Calibre.id)
                                    .ToList();
                                todos.ForEach(y => cantProducida += y.TotalProducido);

                                loopAllReport band = new(prod.TipoProd, prod.Calibre, cantProducida);
                                headBand.loop.Add(band);

                            }
                        headBand.Merma = AMerma;
                        headBand.CantidadUtilizada = AUtilizado;
                        headBand.Mensaje = string.Empty;
                        headBand.Marisco = ind.Marisco;
                    }


                    finaly.Add(headBand);
                
                }
            }

            this.Estudio.Clear();
            this.Estudio = finaly;
        }


        private void clear()
        {
            var copy = this.Estudio;
            List<HeadAllReport> end = new();

            foreach (var item in copy)
            {
                if (item.CantidadUtilizada > 0)
                    end.Add(item);
            }

            this.Estudio.Clear();
            this.Estudio = end;

            
        }
        #endregion


        #region excel
        /// <summary>
        /// para generar un excel con los datos ya cargados de la clase
        /// </summary>
        /// <returns></returns>
        public byte[] Excel()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage ep = new ExcelPackage())
                    {
                        ep.Workbook.Worksheets.Add("Reporte Poduccion Entre Periodos");
                        ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                        ew.Cells.Style.Font.Size = 10;
                        ew.Cells.Style.Font.Name = "Arial";

                        ew.Cells[1, 1].Value = "Reporte Generado ";
                        ew.Cells[1, 2].Value = this.fechaGenerado.ToString("dd/MM/yyyy HH:mm:ss");

                        ew.Cells[2, 1].Value = "Periodo de estudio";
                        ew.Cells[3, 1].Value = "Inicio Periodo";
                        ew.Cells[3, 2].Value = this.Inicio.ToString("dd/MM/yyyy");
                        ew.Cells[3, 3].Value = "Fin Periodo";
                        ew.Cells[3, 4].Value = this.Fin.ToString("dd/MM/yyyy");

                        ew.Cells[5, 2].Value = "Periodo de estudio";


                        int columna = 7;

                        foreach (var head in this.Estudio)
                        {
                            ew.Cells[columna, 1].Value = head.Marisco.Name;
                            columna++;
                            ew.Cells[columna, 1].Value = "Cantidad Utilizado";
                            ew.Cells[columna, 2].Value = head.CantidadUtilizada;
                            ew.Cells[columna, 3].Value = "Rendimiento";
                            ew.Cells[columna, 4].Value = $"{head.Merma}%";
                            columna+=2;
                            ew.Cells[columna, 1].Value = "Tipo Produccion";
                            ew.Cells[columna, 2].Value = "Calibre";
                            ew.Cells[columna, 3].Value = "Total Producido";
                            columna++;
                            foreach (var item in head.loop)
                            {
                                ew.Cells[columna, 1].Value = item.TipoProd.Name;
                                ew.Cells[columna, 2].Value = item.Calibre.Name;
                                ew.Cells[columna, 3].Value = item.TotalProducido.ToString();

                                columna++;
                            }
                            columna+=3;
                        }

                        ep.SaveAs(ms);
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ee)
            {
                Console.Write(ee.Message);
            }

            return new byte[0];
        }


        #endregion


    }


}
