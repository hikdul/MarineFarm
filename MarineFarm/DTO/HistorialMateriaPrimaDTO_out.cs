using OfficeOpenXml;

namespace MarineFarm.DTO
{
    /// <summary>
    /// data que se entrega al hacer la consulta
    /// </summary>
    public class HistorialMateriaPrimaDTO_out
    {

        #region props

        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Marisco que ingreso
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Cantidad que ha ingresado
        /// </summary>
        public double Cantidad { get; set; }
        /// <summary>
        /// fecha en la que ingreso
        /// </summary>
        public DateTime Fecha { get; set; } 
        /// <summary>
        /// Nombre de quien registro
        /// </summary>
        public string NombreQuienRegistro { get; set; }
        /// <summary>
        /// rut de quien registro
        /// </summary>
        public string rutQuienRegistro { get; set; }
        /// <summary>
        /// afirma si es un ingreso o egreso
        /// </summary>
        public bool Ingreso { get; set; }

        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public HistorialMateriaPrimaDTO_out()
        {
            this.Marisco = this.NombreQuienRegistro = this.rutQuienRegistro = String.Empty;
            this.Cantidad = 0;
            this.Ingreso = true;
            this.id = 0;
        }

        #endregion

        #region Excel
            /// <summary>
            /// Genera el exportable excel,
            /// </summary>
            /// <param name="list"></param>
            /// <param name="periodo"></param>
            /// <returns></returns>
        public static   byte[] Excel(List<HistorialMateriaPrimaDTO_out> list, Periodo periodo)
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
                        int fila =6;
                        ew.Cells[5, 1].Value = "Fecha";
                        ew.Cells[5, 2].Value = "Accion";
                        ew.Cells[5, 3].Value = "Marisco";
                        ew.Cells[5, 4].Value = "Cantidad";
                        ew.Cells[5, 5].Value = "Quien Realizo Accion";
                        foreach (var item in list)
                        {
                            ew.Cells[fila, 1].Value = item.Fecha.ToString("dd/MM/yyyy");
                            ew.Cells[fila, 2].Value = item.Ingreso?"Ingreso":"Egreso";
                            ew.Cells[fila, 3].Value = item.Marisco;
                            ew.Cells[fila, 4].Value = item.Ingreso?"Ingreso":"Egreso";
                            ew.Cells[fila, 5].Value = $"{item.NombreQuienRegistro} {item.rutQuienRegistro}";
                            fila++;
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
