using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingAPI.Template
{
    class TEMOpenWeather
    {
        /// <summary>
        /// Define the body of template request here, parsed to JObject and update the body
        /// https://docs.microsoft.com/en-us/previous-versions/windows/apps/hh770289(v=win.10)?redirectedfrom=MSDN
        /// https://www.newtonsoft.com/json/help/html/ModifyJson.htm
        /// </summary>
        /// 

        public static string SomeAPIBodyJson = @"{
          'data': {
            'url': 'https://science.sciencemag.org/content/196/4287/293/tab-pdf',
            'type': 'article',
            '_id': 'aSXaGGgvbCPZWBiEw',
            'createdAt': 1579409922554,
            'created_date': '2020-01-19',
            'test': false,
            'count': 0,
            'keywords': [],
            'title': 'Ribulose bisphosphate carboxylase: a two-layered, square-shaped molecule of symmetry 422',
            'doi': '10.1126/science.196.4287.293',
            'author': [],
            'journal': '',
            'issn': '',
            'publisher': '',
            'year': 1977,
            'status': 'closed',
            'closed_on_create': true,
            'closed_on_create_reason': 'pre2000',
            'receiver': 'sqogWCSRXHgwY7j9Y',
            'updatedAt': 1579409922600,
            'updated_date': '2020-01-19 0458.42',
            'cache': true
          }
        }" ;

        public static string JsonToMerge = @"{
          'data': {
            
            'test': true,
            'count': 120,
            'title': 'demo a merge 2 json, only duplicated got update'
        
          }
        }";

        public static string JsonToAppend = @"{
          'updatedAt': {
            'Node': 'harry porter',
            'count': 120,
            'title': 'how its appended to'
          }
        }";

    }
}
