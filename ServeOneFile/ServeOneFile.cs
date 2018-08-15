
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServeOneFile
{
    public static class ServeOneFile
    {
        //private readonly string jpgpath = @"D:\Stuff\Development\Windows\_static-files\512A5ZAR90L.jpg";

        [FunctionName("ServeOneFile")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            string text = "textfile text";
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(text));
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                FileName = "file.txt"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        [FunctionName("ServeIcs")]
        public static HttpResponseMessage Do([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            string text = File.ReadAllText(@"..\..\..\..\myevents.ics");
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(text));
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "file.ics"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
    }
}
