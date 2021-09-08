using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace WEBCON.BPS.Importer.Logic
{
    public class RestRequestLogger
    {
        public void LogRequest(HttpResponseMessage request)
        {
            var sb = LogRequestToSB(request);

            new ExceptionsHandler().SaveErrorLogs(sb.ToString());
        }

        public StringBuilder LogRequestToSB(HttpResponseMessage request)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Request log:");
            sb.AppendLine($@"Headers:
{request.RequestMessage.Headers?.ToString()}");
            sb.AppendLine($"Uri: {request.RequestMessage.RequestUri?.ToString()}");

            if (request.RequestMessage.Content != null)
            {
                sb.AppendLine($"ContentHeaders: {request.RequestMessage.Content.Headers?.ToString()}");
            }

            return sb;
        }

        public void LogResponseMessage(HttpResponseMessage response, string responseContent, StringBuilder sb = null)
        {
            sb = sb ?? new StringBuilder();

            sb.AppendLine("Response");
            sb.AppendLine($"Response code: {ParseHttpCode(response.StatusCode)}");
            sb.AppendLine($"Response headers: {response.Headers?.ToString()}");
            sb.AppendLine($"Response message headers: {response.RequestMessage.Headers?.ToString()}");
            sb.AppendLine($"Uri: {response.RequestMessage.RequestUri?.ToString()}");
            sb.AppendLine($@"Response body: {PrettyPrintJson(responseContent)}");
            sb.AppendLine("Response end");

            new ExceptionsHandler().SaveErrorLogs(sb.ToString());
        }

        private string ParseHttpCode(HttpStatusCode code)
        {
            return string.Format("{0} ({1})", Enum.GetName(code.GetType(), code), ((int)code).ToString());
        }

        private string PrettyPrintJson(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }
}
