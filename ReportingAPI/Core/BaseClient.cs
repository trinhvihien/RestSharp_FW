using Newtonsoft.Json;
using NUnit.Framework;
using ReportingAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingAPI.Core
{
    class BaseClient : RestClient
    {
      

        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private IRestRequest request;

        public BaseClient(string baseUrl = "some default URL")
        {
            BaseUrl = new Uri(baseUrl);
            request = new RestRequest();
        }

        public T ToObject<T>(IRestResponse response) => JsonConvert.DeserializeObject<T>(response.Content);

       
        public IRestRequest buildHeaders (Dictionary<string, string> headers)
        {
            //Add some default in headers
            request.AddHeader("Content-Type", "application/json");

            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            return request;
        }

        public IRestRequest buildUrlParams(Dictionary<string, string> parameters)
        {
            foreach (var p in parameters)
            {
                request.AddParameter(p.Key, p.Value);
            }

            return request;
        }

        public IRestResponse sendPostRequest(string jsonBody)
        {
            request.Method = Method.POST;
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            return SendRequest();
        }

        public IRestResponse sendGetRequest()
        {
            request.Method = Method.GET;
            return SendRequest();
        }

        private IRestResponse SendRequest(int STATUS_OK = 200)
        {
            logger.Info("SendRequest ");
            logger.Warn("STATUS_OK " + STATUS_OK);

            var response = base.Execute(request);

            //Reponse has error
            if (response.ErrorException != null)
            {
                throw new Exception(string.Format("request sent unsuccessfully: {0}", response.ErrorException.Message));
            }
            
            var statusCode = response.StatusCode;

            //Code is not 200
            if ((int)statusCode != STATUS_OK)
            {
                //Get the values of the parameters passed to the API
                string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

                string info = "Request to " + BaseUrl.AbsoluteUri
                      + request.Resource + " failed with status code "
                      + response.StatusCode + ", parameters: "
                      + parameters + ", and content: " + response.Content;

                Exception ex = new Exception(info);
                throw new Exception(string.Format("request sent unsuccessfully: {0}", info));
            }

            return response;
        }

        private void LogError(IRestResponse response)
        {

            /*
            //POST : Body
            var body = new
            {
                credentials =
                    new AuthenticationInfos()
                    {
                        Username = "Uname",
                        Password = "password",
                        ApiKey = "myApiKey"
                    }
            };

            var serializedBody = JsonConvert.SerializeObject(body);
            request.AddParameter("application/json", serializedBody, ParameterType.RequestBody);
            */

        }
    }
}
