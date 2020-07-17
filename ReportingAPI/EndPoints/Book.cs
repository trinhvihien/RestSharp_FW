using Newtonsoft.Json;
using ReportingAPI.Core;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingAPI.EndPoints
{
    class Book
    {
        BaseClient baseClient = new BaseClient("https://openlibrary.org/api/books");

        //initSearchBookBody()
        //init each part of JObject and merge into one body

        public void SearchBook()
        {
            var parameters = new Dictionary<string, string>  {
                    { "bibkeys", "ISBN:0385472579,LCCN: 62019420" },
                    { "format", "json" }
            };

            baseClient.buildUrlParams(parameters);

            baseClient.sendGetRequest();
        }

    }
}
