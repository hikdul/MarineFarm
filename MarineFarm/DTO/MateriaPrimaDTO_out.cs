using OfficeOpenXml;

namespace MarineFarm.DTO
{
    /// <summary>
    /// datos que se muestran sobre la materia prima
    /// </summary>
    public class MateriaPrimaDTO_out
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// marisco id
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// Marisco
        /// </summary>

        public string Marisco { get; set; }
        /// <summary>
        /// Cantidad
        /// </summary>
        public double Cantidad { get; set; }
        #endregion


        #region excel
            /// <summary>
            /// Para generar el excel de la materia prima
            /// </summary>
            /// <param name="list"></param>
            /// <returns></returns>
            public static byte[] Excel(List<MateriaPrimaDTO_out> list)
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

                        ew.Cells[3,1].Value="Marisco";
                        ew.Cells[3,1].Value="Cantidad Cruda, Sin Procesar";
                        
                        int fila = 4;
                        foreach (var item in list)
                        {
                            
                        ew.Cells[fila,1].Value=item.Marisco;
                        ew.Cells[fila,2].Value=item.Cantidad;
                        fila++;
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
