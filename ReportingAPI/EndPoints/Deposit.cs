using Newtonsoft.Json.Linq;
using ReportingAPI.Core;
using ReportingAPI.Template;
using System;

namespace ReportingAPI.EndPoints
{
    class Deposit
    {
        BaseClient baseClient = new BaseClient("https://api.openaccessbutton.org/deposit");

        //initSearchBookBody()
        //init each part of JObject and merge into one body

        public void createDeposit()
        {
            //Read from template
            JObject parsed = JObject.Parse(TEMDesposit.despositBody);

            var response = baseClient.sendPostRequest(parsed.ToString());

            Console.Write(response.Content);
  
        }
    }
}
