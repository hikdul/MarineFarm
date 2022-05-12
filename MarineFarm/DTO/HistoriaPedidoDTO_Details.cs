

using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace MarineFarm.DTO
{
    /// <summary>
    /// datos que se muestran en el historial de pedidos
    /// </summary>
    class HistorialPedidoDTO_Details:PedidoDTO_out
    {
        #region props
        /// <summary>
        /// Razon por la que eliminaron el pedido
        /// </summary>
        public string? EliminadoRazon { get; set; }
        /// <summary>
        ///  Quien elimino el pedido
        /// </summary>
        public string? EliminadoQuien { get; set; }
        #endregion

        #region  complete

        public async Task Completar(ApplicationDbContext context)
        {
            await Complete(context);

                var aux = await context.PedidosEliminados
                .Include(y=>y.QuienElimino)
                .Where(y=>y.Eliminadoid==this.id)
                .FirstOrDefaultAsync();

                if(aux!=null && aux.Eliminadoid == this.id && aux.QuienEliminoid>0)
                {
                   this.EliminadoQuien=$"{aux.QuienElimino.Nombre} || {aux.QuienElimino.rut}";
                   this.EliminadoRazon=aux.Razon; 
                }
                else
                    this.EliminadoRazon=this.EliminadoQuien=string.Empty;
            }

        

        #endregion

        #region Expor Excel

        public byte[] Excel(bool EsSuperv)
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

                        ew.Cells[1, 1].Value = "Documento Generado ";
                        ew.Cells[1, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        if(!EsSuperv)
                        {
                            ew.Cells[2, 1].Value = "Cliente";
                            ew.Cells[2, 2].Value = this.Cliente;
                            ew.Cells[2, 3].Value = "Solicitante";
                            ew.Cells[2, 4].Value = this.Solicitante;
                        }
                        ew.Cells[2, 5].Value = "Estado";
                        ew.Cells[2, 6].Value = this.EstadoDesc;

                        ew.Cells[3,1].Value = "Fecha Solicitud";
                        ew.Cells[3,2].Value = this.FechaSolicitud.ToString("dd/MM/yyyy");
                        ew.Cells[3,3].Value = "Fecha Posible Entrega";
                        ew.Cells[3,4].Value = this.FechaEntregaPosible.ToString("dd/MM/yyyy");
                        ew.Cells[3,5].Value = "Fecha Entrega";
                        ew.Cells[3,6].Value = this.FechaEntrega==null ? "" : this.FechaEntrega;

                        ew.Cells[5,1].Value = "Productos Solicitados";

                        ew.Cells[6,1].Value = "Marisco";
                        ew.Cells[6,2].Value = "Tipo Produccion";
                        ew.Cells[6,3].Value = "Calibre";
                        ew.Cells[6,4].Value = "Empaquetado";
                        ew.Cells[6,5].Value = "Cantidad Solicitada";
                        
                        int f=7;
                        foreach (var item in this.Productos)
                        {
                            ew.Cells[f,1].Value = item.Marisco;
                            ew.Cells[f,2].Value = item.TipoProduccion;
                            ew.Cells[f,3].Value = item.Calibre;
                            ew.Cells[f,4].Value = item.Empaquetado;
                            ew.Cells[f,5].Value = item.Cantidad;
                            f++;
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
