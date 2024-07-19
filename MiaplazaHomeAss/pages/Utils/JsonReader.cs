using MiaplazaHomeAss.tests.TestData;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiaplazaHomeAss.pages.Utils
{
    public class JsonReader
    {
        public static TestDataModel ReadJsonFile(string fileName)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var jsonString = File.ReadAllText(jsonFilePath);

            return JsonConvert.DeserializeObject<TestDataModel>(jsonString);
        }
    }
}
