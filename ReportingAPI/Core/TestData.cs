using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportingAPI.Core
{
    class TestData
    {
        public static List<Dictionary<string, string> > GetTestData(string dataFile)
        {
           
            var testCases = new List<object>();
            char delimeter = '\t';

            var dataList = new List <Dictionary<string, string> >();
            var keys = new List<string>();

            using (var fs = File.OpenRead(dataFile))
            using (var sr = new StreamReader(fs))
            {
                string line = string.Empty;
                

                //handle FIRST row as key
                line = sr.ReadLine();
                if (line != null)
                {
                    string[] split = line.Split(new char[] { delimeter },
                           StringSplitOptions.None);

                    foreach(var s in split)
                    {
                        keys.Add(s);
                    }
                }

                //handle data content
                while (line != null)
                {
                    line = sr.ReadLine();
                   
                    if (line != null)
                    {
                        string[] split = line.Split(new char[] { delimeter },
                            StringSplitOptions.None);

                        var data = new Dictionary<string, string>();

                        for(int i=0; i<split.Length; i++)
                        {
                            data.Add(keys[i], split[i]);
                        }

                        var newDictionary = data.ToDictionary(entry => entry.Key,
                                               entry => entry.Value);

                        dataList.Add(newDictionary);
                    }
                }

                return dataList;
            }

        }
    }
}
