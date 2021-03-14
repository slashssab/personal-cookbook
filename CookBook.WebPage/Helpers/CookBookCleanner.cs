using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Cookbook.Common.Constants;

namespace CookBook.WebPage.Helpers
{
    public static class CookBookCleanner
    {
        public async static Task DeleteIngredient(int id)
        {
            await _callDeleteCookBookApi(StringConstants.DeleteIngredientApiAction, id);  
        }

        public async static Task DeleteRecipe(int id)
        {
            await _callDeleteCookBookApi(StringConstants.DeleteRecipeApiAction, id);  
        }

        private static async Task _callDeleteCookBookApi(string apiMethodUrlScheme, int id)
        {
            var apiMethodUrl = string.Format(apiMethodUrlScheme, id);
            var Baseurl = StringConstants.BaseUrl;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.DeleteAsync(apiMethodUrl);
 
                if (!Res.IsSuccessStatusCode)
                {   
                    throw new Exception("Delete operation failed");
                }
            }
        }
    }
}