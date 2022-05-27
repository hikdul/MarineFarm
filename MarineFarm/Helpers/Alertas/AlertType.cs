namespace MarineFarm.Helpers.Alertas
{
    /// <summary>
    /// tipos de alertas que se generan en la pantalla
    /// </summary>
    public enum AlertType
    {
    /// <summary>
    /// en caso de error
    /// </summary>
        Error=0,
    /// <summary>
    /// En Caso de advertencia, o posible peligro 
    /// </summary>
        Warning=1,
    /// <summary>
    /// en caso de bindar alguna informacion extra
    /// </summary>
        Info=2,
    /// <summary>
    ///  en caso de algun mensaje positivo
    /// </summary>
        Success=3
    }
}