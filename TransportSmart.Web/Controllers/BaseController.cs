using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading;
using System.Net;
using Newtonsoft.Json;

namespace TransportSmart.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }

        protected T WebApiRequest<T,D> (string url, string paramName, D data , string methodType = "Get")
        {
            HttpContent content;

            HttpClient client = new HttpClient { BaseAddress = new Uri(url) };
            var username = "turk";
            var password = "pass";
            string encoded = Convert.ToBase64String(Encoding.GetEncoding("IOS-8859-1").GetBytes($"{username}:{password}"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
            client.DefaultRequestHeaders.Accept.Add(new  MediaTypeWithQualityHeaderValue( "application/json"));

            if (data == null)
                content = new StringContent("");
            else if(data.GetType().FullName == "System.String")
            {
                content = new StringContent("");
                url = url + "?" + paramName + "=" + data.ToString();
            }
            else
            {
                content = new ObjectContent(data.GetType(), data, new JsonMediaTypeFormatter());
            }
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url)
            };
            request.Headers.Add("lang", Thread.CurrentThread.CurrentUICulture.Name);

            if(methodType.ToUpper() == "POST")
            {
                request.Method = HttpMethod.Post;
                request.Content = content;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            else
            {
                request.Method = HttpMethod.Get;
            }
            var response = client.SendAsync(request).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            if(Convert.ToInt32(response.StatusCode) >= 400)
            {
                throw new HttpException(Convert.ToInt16(HttpStatusCode.BadRequest), "");
            }
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}