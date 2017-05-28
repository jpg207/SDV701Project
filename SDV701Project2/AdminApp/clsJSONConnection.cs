using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace AdminApp
{
    static class clsJSONConnection
    {
        internal async static Task<List<clsNation>> GetAllNations() {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsNation>>(await lcHttpClient.GetStringAsync("http://localhost/SDV701Project/Server/SelectAllNations"));
        }

        internal async static Task<List<clsOrder>> GetAllOrders() {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>(await lcHttpClient.GetStringAsync("http://localhost/SDV701Project/Server/SelectAllOrders"));
        }

        internal async static Task<clsNation> GetNation(string NationName) {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                using (var w = new WebClient())
                {
                    var lcJson = w.DownloadString("http://localhost/SDV701Project/Server/SelectNation/" + NationName);
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
                await lcHttpClient.GetStringAsync("http://localhost/SDV701Project/Server/DeleteOrder/" + OrderID);
        }

        internal async static void DeleteShip(string ShipID) {
            using (HttpClient lcHttpClient = new HttpClient())
                await lcHttpClient.GetStringAsync("http://localhost/SDV701Project/Server/DeleteShip/" + ShipID);
        }
    }
}