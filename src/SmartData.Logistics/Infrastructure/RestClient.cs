using System;
using System.IO;
using System.Net;
using System.Text;
using Jil;

namespace Infrastructure
{
    public class RestClient
    {
        public static RestClient AsJsonGetRequest(Uri endpoint)
        {
            return new RestClient(endpoint, "GET", "application/json");
        }

        public static RestClient AsJsonPostRequest(Uri endpoint)
        {
            return new RestClient(endpoint, "POST", "application/json");
        }

        public Uri EndPoint { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }

        protected RestClient(Uri endpoint, string method, string contentType)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = contentType;
        }

        public string Execute()
        {
            return Execute(string.Empty);
        }

        public string Execute(string postMessage)
        {
            return ExecuteRequest(postMessage);
        }

        private string ExecuteRequest(string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = Method;
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (IsPostRequest(postData))
            {
                var encoding = new UTF8Encoding();
                var bytes = encoding.GetBytes(postData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null) return responseValue;
                    
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseValue = reader.ReadToEnd();
                    }
                }

                return responseValue;
            }
        }

        bool IsPostRequest(string postData)
        {
            return !string.IsNullOrEmpty(postData)
                   && string.Equals(Method, "POST", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
