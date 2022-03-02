namespace MarineFarm.Services.MailServices
{
    public class MailData
    {
        #region propiedades
        /// <summary>
        /// enmail de destino
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// subject 
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// body o cuerppo
        /// </summary>
        public string Body { get; set; }
        #endregion

        #region contructor
        /// <summary>
        /// default
        /// </summary>
        public MailData()
        {

        }
        /// <summary>
        /// complete
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="email"></param>
        /// <param name="Subject"></param>
        public MailData(string Body, string email, string Subject)
        {
            this.Body = Body;
            this.Email = email;
            this.Subject = Subject;
        }
        /// <summary>
        /// constructor con una lista de correos
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="emails"></param>
        /// <param name="Subject"></param>
        public MailData(string Body, List<string> emails, string Subject)
        {
            this.Body = Body;
            this.Email = listaCorreos(emails);
            this.Subject = Subject;

        }


        #endregion


        #region correos en lista
        /// <summary>
        /// para retornar la lista como un str
        /// </summary>
        /// <param name="correos"></param>
        /// <returns></returns>
        public string listaCorreos(List<string> correos)
        {
            string ret = "";

            for (int i = 0; i < correos.Count; i++)
            {

                if (i == correos.Count - 1)
                    ret = correos[i];
                else
                    ret += $"{correos[i]}, ";

            }

            return ret;
        }


        #endregion
    }
}
