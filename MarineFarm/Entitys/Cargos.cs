using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// Cargos que se almacenan por equipo de trabajo
    /// </summary>
    public class Cargos :  ITipo
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del cargo
        /// </summary>
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        /// <summary>
        /// descripcion del cargo
        /// </summary>
        [StringLength(50)]
        public string Desc { get; set; } = string.Empty;
        /// <summary>
        /// si el cargo esta activo o no
        /// </summary>
        public bool act { get; set; } = true;
        /// <summary>
        /// Cantidad Operadores Necesaria
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CantOperadoresNecesario { get; set; } = 1;
        /// <summary>
        /// esta es parte de la tabla que se asocia 
        /// 0 => indiferente
        /// 1 => hombre
        /// 2 => operaria
        /// </summary>
        [Range(0, 2)]
        public int sexo { get; set; } = 0;
        #endregion


        #region sexo
        /// <summary>
        /// solo para obtener los valores
        /// </summary>
        /// <returns></returns>
        public string VerSexo()
        {
            string resp = "Indiferente";
            switch (this.sexo)
            {
                case 0:
                    resp =  "Indiferente";
                    break;
                case 1:
                    resp = "Hombre";
                    break;
                case 2:
                    resp = "Operaria";
                    break;
                default:
                    resp = "Indiferente";
                    break;
            }
            return resp;
        }
        /// <summary>
        /// auxiliar para las vistas
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> SexoToSelect()
        {
            List<SelectListItem> list = new();
            
            list.Add(new SelectListItem() {
            Selected = true,
            Text = " === Seleccione Sexo Operador ===",
            Value = ""
            });



            list.Add(new SelectListItem()
            {
                Selected = false,
                Text = " Indiferente ",
                Value = "0"
            });
            list.Add(new SelectListItem()
            {
                Selected = false,
                Text = " Hombre ",
                Value = "0"
            });
            list.Add(new SelectListItem()
            {
                Selected = false,
                Text = " Operaria ",
                Value = "0"
            });


            return list;
        }


        #endregion


    }
}
