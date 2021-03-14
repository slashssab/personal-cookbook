using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Cookbook.Common.Constants;
using Cookbook.Common.Models;

namespace CookBook.WebPage.Helpers
{
    public static class CookBookExporter
    {
        public async static Task InsertIngredient(Ingredient model)
        {
            await _callPostCookBookApi<Ingredient>(StringConstants.InsertIngredientApiAction, model);  
        }

        public async static Task InsertRecipe(Recipe model)
        {
           await _callPostCookBookApi<Recipe>(StringConstants.InsertRecipeApiAction, model);          
        }

        private static async Task _callPostCookBookApi<T>(string apiMethodUrl, T model)
        {
            var Baseurl = StringConstants.BaseUrl;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var objectJson = JsonSerializer.Serialize<T>(model);
                HttpResponseMessage Res = await client.PostAsync(apiMethodUrl, new StringContent(objectJson, Encoding.UTF8, "application/json"));
 
                if (!Res.IsSuccessStatusCode)
                {   
                    throw new Exception("POST operation failed");
                }
            }
        }
    }
}