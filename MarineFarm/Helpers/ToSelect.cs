using MarineFarm.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Helpers
{
    /// <summary>
    /// clase para generar los ToSelect basados en su valor
    /// </summary>
    public static class ToSelect
    {


        #region to Select ITipo

        /// <summary>
        /// para generar una lista amigable para el uso en la vista y en los selects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public static async Task<List<SelectListItem>> ToSelectITipo<T>(ApplicationDbContext context, int select = 0) where T : class, ITipo
        {
            List<SelectListItem> ret = new();
            ret.Add(new()
            {
                Selected = select <= 0,
                Text = "=== SELECCIONE UN ELEMENTO ===",
                Value = ""
            });

            try
            {
                var ents = await context.Set<T>().Where(tt => tt.act == true).ToListAsync();

                if (ents != null && ents.Count > 0)
                    foreach (var item in ents)
                        ret.Add(new()
                        {
                            Text = item.Name,
                            Value = item.id.ToString(),
                            Selected = item.id == select

                        });
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }


            return ret;

        }


        #endregion





    }
}
