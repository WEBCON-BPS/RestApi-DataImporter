using Newtonsoft.Json;
using System;

namespace WEBCON.BPS.Importer.Model
{
    public class ApiException : Exception
    {
        public string Guid { get; set; }

        public ApiException CreateEx(string response)
        {
            try
            {
                var failure = JsonConvert.DeserializeObject<ApiFailureResponse>(response);
                var message = $"{failure.type}: {failure.description}";

                return new ApiException(message) { Guid = failure.errorGuid };
            }
            catch(Exception ex)
            {
                return new ApiException(response, ex);
            }
        }

        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
