using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingAPI.Models
{
    class AuthenticationInfos
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "Api-Key")]
        public string ApiKey { get; set; }

    }

    /// this the way deserialize object
   // var customerDto = JsonConvert.DeserializeObject<CustomerDto>(response.Content);
    /*
    
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
        The body will be like:

        {
            "credentials":
            {
                "username": "Uname", 
                "password": "password",
                "Api-Key": "myApiKey"
            }
        }

https://www.toolsqa.com/rest/deserialize-json-response-3/




     * VERIFY HEADER in restharp
     * 
     *  IRestResponse restResponse = restClient.Execute(restRequest);
              
         // Creating a dictionary and adding all headers and their values

         Dictionary<string, string> HeadersList = new Dictionary<string, string>();

                    foreach (var item in restResponse.Headers)
                    {
                        string[] KeyPairs=item.ToString().Split('=');
                        HeadersList.Add(KeyPairs[0],KeyPairs[1]);
                    }

             //Asserting content type from header                     
             Assert.AreEqual("application/json”, HeadersList["Content-Type"],"Content-type not matching");	

             //Asserting Server name from header
             Assert.AreEqual("nginx/1.14.0”, HeadersList["Server"]," Server not matching");	
     * 
     */


    /*
     * public static IRestResponse<UserAccount> addBook(AddBooksBody addBooksRequest, String token) {
        RestAssured.baseURI = BASE_URL;
        RequestSpecification request = RestAssured.given();
        request.header("Authorization", "Bearer " + token)
                .header("Content-Type", "application/json");
 
        Response response = request.body(addBooksRequest).post(Route.books());
        return new RestResponse(UserAccount.class, response);
    }
     * 
     * 
     */
}
