using Allure.Commons;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using ReportingAPI.Core;
using ReportingAPI.EndPoints;
using ReportingAPI.Models;
using ReportingAPI.Template;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ReportingAPI
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //https://stackoverflow.com/questions/44122398/object-to-json-issue-in-restsharp

            //https://docs.nunit.org/articles/nunit/running-tests/Console-Command-Line.html

            //https://json2csharp.com/
        }

        [Test(Description = "api fund", Author = "hien")]
        [Category("LongRunning")]
        [AllureTag("smoke")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureSubSuite("sub smoke Test")]

        public void Test_Books()
        {
            Book book = new Book();
            book.SearchBook();

        }


        [Test(Description = "just for fun")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void Test_DeserializeObject()
        {

            string data = "{\"ID\": 123,\"Name\": \"Afzaal Ahmad Zeeshan\",\"Gender\":true, \"DateOfBirth\": \"1995-08-29T00:00:00\", \"DOB\": \"19T00:00:00\"}";

            Person obj = JsonConvert.DeserializeObject<Person>(data);

            // Print on the screen.  
            Console.WriteLine(obj.ID);

            Assert.IsTrue(true);

            Assert.AreEqual('d', 'e');
        }

        [Test]
        public void testManipulateJson()
        {
            var data = @"{
                ""data1"": {
                    ""EntityList"": ""Attribute"",
                    ""KeyName"": ""AkeyName"",
                    ""Value"": ""Avalue""
                        },
                ""data2"": {
                    ""Id"": ""jsdksjkjdiejkwp12193jdmsldm"",
                    ""Status"": ""OK""
                }
            }"; //variable with json string

            dynamic myData = JObject.Parse(data);
            Console.WriteLine($"EntityList:{myData.data1.EntityList}, KeyName:{myData.data1.KeyName}");

            //Read from template
            JObject parsed = JObject.Parse(TEMOpenWeather.SomeAPIBodyJson);
            var node = parsed.SelectToken("data.title").Value<string>();
            var dateNode = parsed.SelectToken("data.created_date").Value<DateTime>();
            Console.WriteLine(node);
            Console.WriteLine(dateNode);

            //demo to update a node in json
            parsed["data"]["title"] = "updated the title in json";
            node = parsed.SelectToken("data.title").Value<string>();
            Console.WriteLine(node);

            //merge 2 json : Override
            JObject jObject2 = JObject.Parse(TEMOpenWeather.JsonToMerge);
            parsed.Merge(jObject2);
            Console.WriteLine("Json " + parsed.ToString());

            //merge 2 json : append to original
            jObject2 = JObject.Parse(TEMOpenWeather.JsonToAppend);
            parsed["data"]["updated_date"] = jObject2;
            Console.WriteLine("Json " + parsed.ToString());
        }

        [Test]
        public void testFailed()
        {
            BaseClient baseClient = new BaseClient("https://openlibrary.orgdf");

            var parameters = new Dictionary<string, string>  {
                    { "bibkeys", "ISBN:0385472579,LCCN: 62019420" },
                    { "format", "json" }
            };

            baseClient.buildUrlParams(parameters);
            baseClient.sendGetRequest();
        }
    }
}