using Newtonsoft.Json;

namespace MarineFarm.Helpers.Alertas
{
  /// <summary>
  /// Clase Para generar las alertas para enviar por medio de MVC
  /// </summary>
  public class Alert
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public string Key { get; set; } = "0";
        /// <summary>
        /// Título de Alerta
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Tipo de Alerta
        /// </summary>
        public AlertType Type { get; set; }
        /// <summary>
        /// Color de Alerta
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Icono de Alerta
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public Alert()
        {

        }
        /// <summary>
        /// Alerta Práctica
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public Alert(string title, string message, AlertType type)
        {
            this.Title = title;
            this.Message = message;
            this.Type = type;
            switch (type)
            {
                case AlertType.Success: Icon = "ft-check-circle"; Color = "bg-success"; break;
                case AlertType.Warning: Icon = "ft-alert-triangle"; Color = "bg-warning"; break;
                case AlertType.Info: Icon = "ft-info"; Color = "bg-info"; break;
                case AlertType.Error: Icon = "ft-x-circle"; Color = "bg-danger"; break;
            }
        }

        /// <summary>
        /// Alerta Práctica
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public Alert(string title, string message, int type)
        {
            this.Title = title;
            this.Message = message;
            this.Type = (AlertType)type;

            switch (this.Type)
            {
                case AlertType.Success: Icon = "ft-check-circle"; Color = "bg-success"; break;
                case AlertType.Warning: Icon = "ft-alert-triangle"; Color = "bg-warning"; break;
                case AlertType.Info: Icon = "ft-info"; Color = "bg-info"; break;
                case AlertType.Error: Icon = "ft-x-circle"; Color = "bg-danger"; break;
            }
        }
        /// <summary>
        /// Utilizado para guardar el valor de la alerta en un TempData.
        /// </summary>
        /// <returns></returns>
        public string SerializeAlert() => JsonConvert.SerializeObject(this);

        /// <summary>
        /// Utilizado para Convertir el codigo del TempData a una Alerta
        /// </summary>
        /// <param name="codeAlert">Es el código guardado para el TempData.</param>
        /// <returns></returns>
        public Alert? DeserializeAlert(string codeAlert) => codeAlert != null ? JsonConvert.DeserializeObject<Alert>(codeAlert) : null;
    }


}