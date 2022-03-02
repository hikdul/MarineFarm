namespace MarineFarm.Services.MailServices
{
    /// <summary>
    /// interface del servicio para enviar Email
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// funcion que envia los correos
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task EmailSender(MailData data);
    }
}
