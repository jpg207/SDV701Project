using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Net.Http.Headers;

namespace AdminApp
{
    static class clsJSONConnection
    {

        private static string BaseAddress = "http://localhost/SDV701Project/Server/";

        internal async static Task<List<clsNation>> GetAllNations() {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsNation>>(await lcHttpClient.GetStringAsync(BaseAddress + "SelectAllNations"));
        }

        internal async static Task<List<clsOrder>> GetAllOrders() {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>(await lcHttpClient.GetStringAsync(BaseAddress + "SelectAllOrders"));
        }

        internal async static Task<clsNation> GetNation(string NationName) {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                using (var w = new WebClient())
                {
                    var lcJson = w.DownloadString(BaseAddress + "SelectNation/" + NationName);
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                    return JsonConvert.DeserializeObject<clsNation>(lcJson, settings);
                }  
            }
        }

        internal async static void DeleteOrder(string OrderID) {
            using (HttpClient lcHttpClient = new HttpClient())
                await lcHttpClient.GetStringAsync(BaseAddress + "DeleteOrder/" + OrderID);
        }

        internal async static void DeleteShip(string ShipID) {
            using (HttpClient lcHttpClient = new HttpClient())
                await lcHttpClient.GetStringAsync(BaseAddress + "DeleteShip/" + ShipID);
        }

        //internal async static void AddShip(clsShip Ship) {
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(Ship), Encoding.UTF8, "application/json");
        //    using (var client = new HttpClient())
        //    {
        //        var result = await client.PostAsync(BaseAddress + "AddShip", new StringContent(Ship.ToString(), Encoding.UTF8, "application/json"));
        //    }
        //}

        public static void AddShip(clsShip Ship) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonString = JsonConvert.SerializeObject(Ship);

            var response = client.PostAsJsonAsync("AddShip", Ship).Result;
        }
    }
}