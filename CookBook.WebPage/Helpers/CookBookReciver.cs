using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Cookbook.Common.Constants;
using Cookbook.Common.Models;

namespace CookBook.WebPage.Helpers
{
    public static class CookBookReciver
    {
        public async static Task<IEnumerable<Ingredient>> GetAlIngredients()
        {
            return await _callGetCookBookApi<List<Ingredient>>(StringConstants.GetAllIngredientsApiAction);
        }

        public async static Task<Ingredient> GetIngredientByName(string name)
        {
            string actionString = string.Format(StringConstants.GetIngredientByNameApiAction, name);
            return await _callGetCookBookApi<Ingredient>(actionString);
        }

        public async static Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return await _callGetCookBookApi<List<Recipe>>(StringConstants.GetAllRecipesApiAction);
        }

        public async static Task<Recipe> GetRecipeById(int id)
        {
            string actionString = string.Format(StringConstants.GetRecipeByIdApiAction, id);
            return await _callGetCookBookApi<Recipe>(actionString);
        }

        private static async Task<T> _callGetCookBookApi<T>(string apiMethodUrl) where T : new()
        {
            var Baseurl = StringConstants.BaseUrl;
            T returnObject = new T();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(apiMethodUrl);

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    returnObject = JsonSerializer.Deserialize<T>(EmpResponse, options);
                }
                return returnObject;
            }
        }
    }
}