using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para obtener un listado de paises
    /// </summary>
    public class Paises
    {
        #region props
        public string Code { get; set; }
        public string Pais { get; set; }


        #endregion

        #region obtener api
        /// <summary>
        /// api desde la que obtengo el listado
        /// </summary>
        /// <returns></returns>
        public static string URLPaises()
        {
            return "http://country.io/names.json";
        }
        #endregion

        #region obtener listado de paises
        /// <summary>
        /// funcion para obtener los paises
        /// </summary>
        /// <returns></returns>
        public async static Task<List<SelectListItem>> ObtenerPaises(string selected = "naiden")
        {
            HttpClient client = new();
            List<SelectListItem> list = new();
            try
            {

                HttpResponseMessage response = await client.GetAsync(URLPaises());

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
                var resp = JsonConvert.DeserializeObject<Dictionary<string,string>>(responseBody);
                if(resp!=null && resp.Count>0)
                foreach (var item in resp)
                    list.Add(new(item.Value, item.Value, item.Value == selected));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            finally
            {
                client.Dispose();
            }
            return list;
        }

        #endregion

    }
}
