using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace POS.API.Utilities
{
  public static class APICall
  {
    public static T Get<T>(string url)
    {
      try
      {
        T obj = default (T);
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(url));
        httpWebRequest.Method = "GET";
        httpWebRequest.ContentType = "application/json; charset=utf-8";
        httpWebRequest.KeepAlive = false;
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
          using (Stream responseStream = response.GetResponseStream())
          {
            using (StreamReader streamReader = new StreamReader(responseStream))
              obj = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
          }
        }
        response.Close();
        return obj;
      }
      catch (WebException ex)
      {
        throw new Exception(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    public static T Post<T>(string url, object values = null)
    {
      try
      {
        using (HttpClient client = new HttpClient())
        {
          client.BaseAddress = new Uri(url);
          return JsonConvert.DeserializeObject<T>(client.PostAsJsonAsync<object>(url, values).Result.Content.ReadAsStringAsync().Result);
        }
      }
      catch (WebException ex)
      {
        throw new Exception(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
