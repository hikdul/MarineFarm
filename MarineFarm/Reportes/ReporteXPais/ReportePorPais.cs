
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace MarineFarm.Reportes.ReporteXPais
{
    /// <summary>
    /// Clase para generar el reporte por un pais seleccionado
    /// </summary>
    public class ReportePorPais : Periodo
    {
        #region props
        /// <summary>
        /// Pais al que se le hace el estudio
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        /// Marisco al que se le esta haciendo el estudio
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Calibre al que se le quiere hacer el estudio
        /// </summary>
        public string Calibre { get; set; }
        /// <summary>
        /// Cantidod de Marisco/calibre que se produjo
        /// </summary>
        public double CantidadProducido { get; set; }
        /// <summary>
        ///  Cantidad de pedidos que se completaron
        /// </summary>
        public int PedidosCompletados { get; set; }     
        /// <summary>
        ///  Cantidad de pedidos que se rechazaron
        /// </summary>
        public int PedidosRechazados { get; set; }   
        /// <summary>
        ///  Cantidad de pedidos que van con retrazo
        /// esta es tanta para los culminados como para los que aun no se entregan. 
        /// </summary>
        public int PedidosConRetrazo { get; set; }
        /// <summary>
        /// Para el pedido valido
        /// </summary>
        public bool Valid { get; set; } = true;

        #endregion

        #region  ctor


        /// <summary>
        /// empty ctor
        /// </summary>
        public ReportePorPais()
            {
              this.Pais=this.Marisco=this.Calibre=string.Empty;
              this.CantidadProducido=0;
              this.PedidosCompletados=this.PedidosRechazados=this.PedidosConRetrazo=0;
            this.Valid = true;
            }
            
            /// <summary>
            /// Constuctor 
            /// </summary>
            /// <param name="Pais"></param>
            /// <param name="Marisco"></param>
            /// <param name="Calibre"></param>
            /// <param name="CantidadProducida"></param>
            /// <param name="PedidosCompletados"></param>
            /// <param name="PedidosRechazados"></param>
            /// <param name="PedidosConRetrazo"></param>
            public ReportePorPais(string Pais, string Marisco, string Calibre, double CantidadProducida, int PedidosCompletados, int PedidosRechazados, int PedidosConRetrazo)
            {
              this.Pais=Pais;
              this.Marisco=Marisco;
              this.Calibre=Calibre;
              this.CantidadProducido=CantidadProducida;
              this.PedidosCompletados=PedidosCompletados;
              this.PedidosRechazados=PedidosRechazados;
              this.PedidosConRetrazo=PedidosConRetrazo;
            this.Valid = true;
            }

        #endregion

        #region Llenar datos
        /// <summary>
        /// Para generar el reporte en base a los datos ingresados
        /// </summary>
        /// <param name="data"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Up(RepotePorPaisDTO_in data,  ApplicationDbContext context)
        {
            var pedidos= await ObtenerListaActual(data,context);
            if(pedidos.Count <= 0)
            {
                this.Valid = false;
                return;
            }

            int Ccompletado=0;
            int Crechazado=0;
            int Cretrazados=0;
            double Aproducido=0;

            foreach (var pedido in pedidos)
            {
                
                if(pedido.estado==1)
                    Ccompletado++;
                if(pedido.estado==2)
                    Crechazado++;
                if(pedido.estado==1 && pedido.FechaEntrega  >   pedido.FechaEntregaPosible)
                    Cretrazados++;

                Aproducido+= pedido.PedidoProductos.Sum(y=>y.Cantidad);
            }

            this.Pais= data.Pais;
            this.Marisco = data.Mariscoid==0?"Todos": pedidos[0].PedidoProductos[0].Producto.Marisco.Name;
            this.Calibre = data.Calibreid==0?"Todos": pedidos[0].PedidoProductos[0].Producto.Calibre.Name;
            this.CantidadProducido=Aproducido;
            this.PedidosCompletados=Ccompletado;
            this.PedidosRechazados=Crechazado;
            this.PedidosConRetrazo=Cretrazados;   
        }

        

        /// <summary>
        ///  Para que me liste los pedidos en base a la solicitud en la request
        /// </summary>
        /// <param name="data"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task<List<Pedido>> ObtenerListaActual(RepotePorPaisDTO_in data,  ApplicationDbContext context)
        {

          var request = context.Pedidos
          .Include(x=>x.Cliente)
          .Include(x=>x.PedidoProductos).ThenInclude(x=>x.Producto).ThenInclude(m=>m.Marisco)
          .Include(x=>x.PedidoProductos).ThenInclude(x=>x.Producto).ThenInclude(m=>m.Calibre)
          .Where(y=>y.FechaSolicitud > data.Inicio.AddDays(-1) && y.FechaSolicitud<data.Fin.AddDays(1));

          request= request.Where(p=>p.Cliente.Desc==data.Pais);
           
           var pedidos= await request.ToListAsync();

          if(data.Mariscoid>0)
                {
                 List<Pedido> band=new();
                   foreach (var item in pedidos)
                   {
                        Pedido aux = new(item);
                        aux.PedidoProductos= new();

                        foreach (var elemento in item.PedidoProductos)
                            if (elemento.Producto.Mariscoid == data.Mariscoid)
                            {
                                aux.PedidoProductos.Add(elemento);
                                band.Add(aux);
                            }
                   }
                pedidos = band;
                }
          
          if(data.Calibreid>0)
                {
                 List<Pedido> band=new();
                   foreach (var item in pedidos)
                   {

                        Pedido aux = new(item);
                        aux.PedidoProductos = new();

                    foreach (var elemento in item.PedidoProductos)
                        if (elemento.Producto.Calibreid == data.Calibreid)
                        {
                            aux.PedidoProductos.Add(elemento);
                            band.Add(aux);
                        }
                    }
                pedidos = band;
                } 
          
          return pedidos;
    
        }



        #endregion

        #region excel
        /// <summary>
        /// Para gererar el excel del informe actual
        /// </summary>
        /// <returns>array de bites con los datos del informe </returns>
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
                        ew.Cells[1, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        ew.Cells[2, 1].Value = "Periodo de estudio";
                        ew.Cells[3, 1].Value = "Inicio Periodo";
                        ew.Cells[3, 2].Value = this.Inicio.ToString("dd/MM/yyyy");
                        ew.Cells[3, 3].Value = "Fin Periodo";
                        ew.Cells[3, 4].Value = this.Fin.ToString("dd/MM/yyyy");

                        ew.Cells[4,1].Value= "Pais de estudio";
                        ew.Cells[4,2].Value= this.Pais;

                        ew.Cells[5,1].Value="Marisco";
                        ew.Cells[5,2].Value=this.Marisco;
                        ew.Cells[5,3].Value="Calibre";
                        ew.Cells[5,4].Value=this.Calibre;
                        ew.Cells[5,5].Value="Cantidad Total Producida";
                        ew.Cells[5,6].Value=this.CantidadProducido;

                        ew.Cells[6,1].Value="Pedidos Completados";
                        ew.Cells[6,2].Value= this.PedidosCompletados;
                        ew.Cells[6,3].Value="Pedidos Rechazados";
                        ew.Cells[6,4].Value= this.PedidosRechazados;
                        ew.Cells[6,5].Value="Pedidos Con Retrazo";
                        ew.Cells[6,6].Value= this.PedidosConRetrazo;

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