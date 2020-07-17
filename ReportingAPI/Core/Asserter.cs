using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingAPI.Core
{
    public class Asserter 
    {
        private const string BASE_URL = "";

        public Asserter(string route)
        {
            RestClient restClient = new RestClient("https://restapi.demoqa.com/utilities/weather/city/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Guntur", Method.GET);

            restRequest.AddHeaders(new Dictionary<string, string>());

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            string response = restResponse.Content;

        }


        public RestClient Create(string baseUrl)
        {
            return new RestClient(baseUrl);
        }

        public string getRoute()
        {
            return "";
        }
        public RestRequest MakeRequest(string url, Method method, Dictionary<string, string> header )
        {
            var request = new RestRequest(url, method);
            //request.AddParameter()
         
            //build header
            //build body
            return new RestRequest(url, method);
        }


        public IRestResponse SendRequest(RestClient client, RestRequest request, int STATUS_OK = 200)
        {
            var response = client.Execute(request);
            var statusCode = response.StatusCode;
            if ((int)statusCode != STATUS_OK)
                throw new Exception(string.Format("request sent unsuccessfully, response status code is : {0}", statusCode));

            return response;
        }

        public IRestResponse sendPostRequest(RestClient client, RestRequest request, int STATUS_OK = 200)
        {

            return SendRequest(client, request, STATUS_OK);
        }

        //Config.json :BASEURL, username, pwd authentication


        /*
         *  class MyExampleClass

    private IRestClientFactory restClientFactory; 
    private IRestRequestFactory restRequestFactory;
 if (string.IsNullOrWhiteSpace(postData)) throw new ArgumentNullException("postData");
            if (string.IsNullOrWhiteSpace(endPoint)) throw new ArgumentNullException("endPoint");

            

    public MyExampleClass(IRestClientFactory restClientFactory, IRestRequestFactory restRequestFactory)
    {
        this.restClientFactory = restClientFactory;
        this.restRequestFactory = restRequestFactory;
    }
 
         *  public IRestResponse GetById(string id)
    {
        var restClient = restClientFactory.Create(configurationSettings.BaseUrl);
        var restRequest = restRequestFactory.Create(string.Format("myendpoint/{0}", id), Method.GET);
        var response = restClient.Execute(restRequest);

        RestResponse response = client.Execute(request);
HttpStatusCode statusCode = response.StatusCode;
int numericStatusCode = (int)statusCode;

        return response;
    }
         */


    }


}
