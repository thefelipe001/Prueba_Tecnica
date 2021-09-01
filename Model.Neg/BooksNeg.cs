using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using Model.Entity;
using Newtonsoft.Json;

namespace Model.Neg
{
   public class BooksNeg
    {
        private static BooksData dao = new BooksData();
        //Mostrar Libros

        public static  async Task<IEnumerable<Books>> All()
        {
         return await  dao.All();
           
        }


        //Agregar Libros
        public static async void Add(int idCliente) 
        {
             dao.Add(idCliente);
        }
    }
}
