using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Data;
using Model.Entity;
using Model.Neg;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        //Listado
        public async Task<IActionResult> Listado()
        {
            List<Books> reservationList = new List<Books>();

            ViewBag.ListadoCliente = await BooksNeg.All();


            return PartialView();
        }



        //Agregar
        [HttpPost]
        public async Task<ActionResult> Add(int idCliente)
        {
            bool receivedReservation = true;
            if (true)
            {
                BooksNeg.Add(idCliente);


            }
            return Json(receivedReservation);
        }


       //Filtrar por Id

        public ViewResult Get() => View();


        [HttpPost]
        public async Task<IActionResult> Get(int id)
        {
            Books reservation = new Books();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Books>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(reservation);
        }




        //Eliminar

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            bool existo = true;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://fakerestapi.azurewebsites.net/api/v1/Books/" + id))
                {
                    if (existo == true)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                    }
                }
            }

            return Json(existo);

        }
        //Editar


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Books reservation = new Books();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Books>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(reservation);
        }

        [HttpPost, ActionName("Update")]
        public async Task<ActionResult> ActionUpdate(int id, Books books)
        {
            using (var httpClient = new HttpClient())
            {

                using (var responseedit = await httpClient.PutAsync("https://fakerestapi.azurewebsites.net/api/v1/Books/" + id, books, new JsonMediaTypeFormatter()))
                {

                    if (responseedit.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        string apiResponseedit = await responseedit.Content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<Books>(apiResponseedit);

                    }
                    else
                    {
                        ViewBag.StatusCode = responseedit.StatusCode;

                    }
                    return View(books);

                }
            }
        }







        [HttpGet]

        public async Task<ActionResult> GetId(int id)
        {
            Books reservation = new Books();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Books>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(reservation);
        }

    }
}
