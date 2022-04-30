using Newtonsoft.Json;

namespace MarineFarm.Helpers
{
    /// <summary>
    /// clase para agregar genericos que consuman api
    /// </summary>
    public static class ConsumidorAPI
    {
        /// <summary>
        /// obtiene un listado de elementos de una api sin restricciones
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<List<T>> GetAll<T>(string url) where T : class, new()
        {
            HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
                return JsonConvert.DeserializeObject<List<T>>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n HTTP  Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new();
            }
            finally
            {
                client.Dispose();

            }

        }
    }
}
