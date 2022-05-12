using OfficeOpenXml;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para enviar los datos de la produccion
    /// </summary>
    public class ProduccionDTO_out
    {
    #region  props
        public int id { get; set; }
        /// <summary>
        /// fecha en que fue realizado la produccion
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// quien esta a cargo de la produccion
        /// </summary>
        public string SupervName { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string SupervEmail { get; set; }

        /// <summary>
        /// detalles de lo producido
        /// </summary>
        public List<DatosProduccion_out> productos { get; set; }
    #endregion

        #region  Excel
        /// <summary>
        /// Para exportar el excel entregando el periodo y una lista de elementos
        /// </summary>
        /// <param name="list"></param>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public static byte[] Excel(List<ProduccionDTO_out> list, Periodo periodo)
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
                        ew.Cells[1, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        ew.Cells[2, 1].Value = "Periodo de estudio";
                        ew.Cells[3, 1].Value = "Inicio Periodo";
                        ew.Cells[3, 2].Value = periodo.Inicio.ToString("dd/MM/yyyy");
                        ew.Cells[3, 3].Value = "Fin Periodo";
                        ew.Cells[3, 4].Value = periodo.Fin.ToString("dd/MM/yyyy");

                        int fila=5;

                        foreach (var produccion in list)
                        {
                            ew.Cells[fila,1].Value="Fecha Produccion";
                            ew.Cells[fila,2].Value= produccion.Fecha.ToString("dd/MM/yyyy");
                            ew.Cells[fila,3].Value="Hora Carga Datos";
                            ew.Cells[fila,4].Value=produccion.Fecha.ToString("HH:mm:ss");
                            fila++;
                            ew.Cells[fila,1].Value="Supervisor A Cargo";
                            ew.Cells[fila,2].Value=produccion.SupervName;
                            ew.Cells[fila,3].Value=produccion.SupervEmail;
                                fila++;
                            foreach (var producto in produccion.productos)
                            {
                                ew.Cells[fila,1].Value="Marisco";
                                ew.Cells[fila,2].Value=producto.Marisco;
                                ew.Cells[fila,3].Value="Cantidad Marisco Usada(cruda)";
                                ew.Cells[fila,4].Value=producto.CantUsada;
                                fila++;
                                ew.Cells[fila,1].Value="Tipo Produccion";
                                ew.Cells[fila,2].Value="Calibre";
                                ew.Cells[fila,3].Value="Empaquetado";
                                ew.Cells[fila,4].Value="Cantidad Producida";
                                fila++;
                                foreach (var obj in producto.Productos)
                                {
                                    ew.Cells[fila,1].Value=obj.TipoProduccion;       
                                    ew.Cells[fila,2].Value=obj.Calibre;       
                                    ew.Cells[fila,3].Value=obj.Empaquetado;       
                                    ew.Cells[fila,4].Value=obj.CantProduccida;       
                                fila++;
                                }
                            }
                            fila+=3;
                        }

                        ep.SaveAs(ms);
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ee)
            {
               Console.WriteLine(ee.Message);
            }
            return new byte[0];
        }

        #endregion


    }
}
