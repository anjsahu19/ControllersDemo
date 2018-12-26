using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ControllersDemo.Models
{
    public class ApiCall
    {
        public HttpClient client = new HttpClient();
        public ApiCall(string BaseUrl)
        {
            client.BaseAddress = new Uri(BaseUrl);
        }
        public HttpResponseMessage FetchCall(string url, string parameters)
        {          
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));         
            HttpResponseMessage response = client.GetAsync(url + parameters).Result;
           // client.Dispose();
            return response;
        }

        public HttpResponseMessage PostCall(string url, object obj)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var DictionaryObj = GetValues(obj);
            var content = new FormUrlEncodedContent(DictionaryObj);
            HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
            return responseMessage;
        }

        public IDictionary<string, string> GetValues(object obj)
        {
            return obj
                    .GetType()
                    .GetProperties()
                    .ToDictionary(p => p.Name, p => p.GetValue(obj).ToString());
        }


        public List<Student> GetStudents(string url)
        {
            var response = FetchCall(url, "");
            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<List<Student>>().Result;
                return students;
            }
            else
                return null;

        }

    }
}