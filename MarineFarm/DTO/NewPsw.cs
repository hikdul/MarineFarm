using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{

    public class NewPsw : IValidatableObject
    {

        /// <summary>
        /// Old Password
        /// </summary>
        public string OPsw { get; set; }
        /// <summary>
        /// New Password
        /// </summary>
        public string Npsw { get; set; }
        /// <summary>
        /// Confirm New Password
        /// </summary>
        public string ConfirmNpsw { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // TODO Valida que el pasword tenga al menos una MAY min num y caracter especial

            if(!string.IsNullOrEmpty(this.OPsw) || !string.IsNullOrEmpty(this.Npsw) || !string.IsNullOrEmpty(this.ConfirmNpsw) )
            {
               if(OPsw == Npsw)
                      yield return new ValidationResult("La Nueva y Antigua Contraseña no pueden coincidir", new string[] { nameof(Npsw) });
                if(Npsw != ConfirmNpsw)
                      yield return new ValidationResult("Las Contraseñas no coinciden", new string[] { nameof(ConfirmNpsw) });
            }

        }
    }
}