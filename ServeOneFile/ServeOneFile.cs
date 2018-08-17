
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;


namespace ServeOneFile
{
    public static class ServeOneFile
    {
        //[FunctionName("ServeOneFile")]
        //public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        //{
        //    string text = "textfile text";
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    result.Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(text));
        //    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
        //        FileName = "file.txt"
        //    };
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //    return result;
        //}

        [FunctionName("ServeIcs")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "{calendarNumber}")]HttpRequest req, string calendarNumber, TraceWriter log)
        {
            string[] files = Directory.GetFiles(@"..\..\..\..", calendarNumber);

            if (files.Length == 1)
            {
                string text = File.ReadAllText(@"..\..\.." + files[0]);
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(text));
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = files[0]
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return result;
            }
            else
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                return result;
            }

        }
    }
}
