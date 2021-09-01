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
        //Metodo para Mostar Todo los Libros

        public async Task<IEnumerable<Books>> All()
        {

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



        public static async void  Add(int idCliente) 
        {
            Books receivedReservation = new Books();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(idCliente), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://fakerestapi.azurewebsites.net/api/v1/Books", content))
                {
                    if (idCliente == -1)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        receivedReservation = JsonConvert.DeserializeObject<Books>(apiResponse);
                    }
                    else
                    {

                    }

                }
            }
        }

    
    }
}
