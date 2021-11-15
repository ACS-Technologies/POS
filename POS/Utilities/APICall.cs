using POS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace POS.Utilities
{
    public static class APICall
    {
        public static T Get<T>(string url, string type, string token)
        {
            T obj;
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Method = "GET";
                webRequest.Headers.Add("Authorization", type + " " + token);
                webRequest.ContentType = "application/json; charset=utf-8";
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(responseStream))
                            obj = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("Web_APICall", ex.ToString(), EventLogEntryType.Error);
                obj = default(T);
            }
            return obj;
        }
        public static T Delete<T>(string url, string type, string token)
        {
            T obj;
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Method = "DELETE";
                webRequest.Headers.Add("Authorization", type + " " + token);
                webRequest.ContentType = "application/json; charset=utf-8";
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(responseStream))
                            obj = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("Web_APICall", ex.ToString(), EventLogEntryType.Error);
                obj = default(T);
            }
            return obj;
        }
        public static APIAuthorization GetAuthorization(
          string url,
          string username,
          string password)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(string.Format("username={0}&password={1}&grant_type=password", (object)username, (object)password));
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = (long)bytes.Length;
                using (Stream requestStream = httpWebRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                            return JsonConvert.DeserializeObject<APIAuthorization>(streamReader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
               // EventLog.WriteEntry("Web_APICall", ex.ToString(), EventLogEntryType.Error);
                return (APIAuthorization)null;
            }
        }

        public static T Post<T>(string url, string type, string token, object values = null)
        {
            T obj;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(type, token);
                    obj = JsonConvert.DeserializeObject<T>(client.PostAsJsonAsync<object>(url, values).Result.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
               // EventLog.WriteEntry("Web_APICall", ex.ToString(), EventLogEntryType.Error);
                obj = default(T);
            }
            return obj;
        }
    }
}