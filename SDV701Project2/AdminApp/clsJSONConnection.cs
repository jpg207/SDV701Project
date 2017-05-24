using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Net.Http;
using Newtonsoft.Json;

namespace AdminApp
{
    static class clsJSONConnection
    {




        //internal async static Task<List<DTO.RootOrder>> GetNationNamesAsync() {
        //    using (HttpClient lcHttpClient = new HttpClient())
        //       return JsonConvert.DeserializeObject<List<DTO.RootOrder>>
        //    (await lcHttpClient.GetStringAsync("http://localhost/SDV701Project/Server/SelectAllNations"));
        //}



        //public static T _download_serialized_json_data<T>(string url) where T : new() {
        //    using (var w = new WebClient())
        //    {
        //        var json_data = string.Empty;
        //        // attempt to download JSON data as a string
        //        try
        //        {
        //            json_data = w.DownloadString(url);
        //        }
        //        catch (Exception) { }
        //        // if string with JSON data is not empty, deserialize it to class and return its instance 
        //        return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        //    }
        //}



        //public static List<RootNation> GetAllNations() {
        //    var json_data = string.Empty;
        //    using (var w = new WebClient())
        //        json_data = w.DownloadString("http://localhost/SDV701Project/Server/SelectAllNations");
        //    List<RootNation> myDeserializedObjList = (List<RootNation>)JsonConvert.DeserializeObject(json_data);

        //    return myDeserializedObjList;
        //}



        //public static List<RootNation> GetAllNations() {
        //    List<RootNation> rootobject = new List<RootNation>();
        //    using (var webclient = new WebClient())
        //    {
        //        var Ids = webclient.DownloadString("http://localhost/SDV701Project/Server/SelectAllNations");
        //        foreach (var NationID in Ids.Substring(1, 2).Split(','))
        //        {
        //            string url = string.Format("{0}/{1}", "http://localhost/SDV701Project/Server/SelectAllNations", NationID);
        //            var res = webclient.DownloadString(url);
        //            var jsonObject = JsonConvert.DeserializeObject<RootNation>(res);
        //            rootobject.Add(jsonObject);
        //        }
        //    }
        //    return rootobject;
        //}



        //public static string GetAllNations() {
        //    var json_data = string.Empty;
        //       using (var w = new WebClient()) 
        //            json_data = w.DownloadString("http://localhost/SDV701Project/Server/SelectAllNations");
        //    string rootobject = json_data;
        //    return rootobject;
        //}



        //internal async static Task<List<RootNation>> GetAllNations() {
        //    using (HttpClient lcHttpClient = new HttpClient())
        //        return JsonConvert.DeserializeObject<List<RootNation>>
        //    (await lcHttpClient.GetStringAsync("http://localhost/SDV701Project/Server/SelectAllNations"));
        //}



        //    public obj GetAllNations() {
        //        string baseURL = "http://localhost/SDV701Project/Server/SelectAllNations";
        //        var obj = new RootNation { NationID = "NationID", Name = "Name", BuildingCapacity = "BuildingCapacity" };
        //        HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(baseURL);
        //        POSTRequest.Accept = "application/json";
        //        POSTRequest.ContentType = "application/json";
        //        POSTRequest.Method = "POST";
        //        HttpWebResponse GETResponse = (HttpWebResponse)POSTRequest.GetResponse();
        //        return obj;
        //    }
        //}



            internal async static Task<List<clsNation>> GetAllNations() {
                using (HttpClient lcHttpClient = new HttpClient())
                    return JsonConvert.DeserializeObject<List<clsNation>>
                (await lcHttpClient.GetStringAsync
            ("http://localhost/SDV701Project/Server/SelectAllNations"));
            }

        }
    }