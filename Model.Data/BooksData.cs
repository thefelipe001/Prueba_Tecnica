using Model.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class BooksData
    {
        public  async Task<IEnumerable<Books>> All()
        {

            //Metodo para Mostar Todo los Libros
            List<Books> reservationList = new List<Books>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                return  reservationList = JsonConvert.DeserializeObject<List<Books>>(apiResponse);
                }
            }

         
        }
    }
}
