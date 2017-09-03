using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using os.FileParser.Api.Models;

namespace os.FileParser.Test
{
    /// <summary>
    /// Summary description for NamesFileTests
    /// </summary>
    [TestClass]
    public class NamesFileTests
    {
        private HttpClient _client;
        private string baseAddress = "http://localhost:65286";

        [TestMethod]
        public void NamesHappyScenarioShouldPass()
        {
            var bytes = File.ReadAllBytes(Environment.CurrentDirectory + "/TestCases/names/namesHappyScenario.csv");
            var fileContent = Convert.ToBase64String(bytes);

            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);

            var file = new FileObject { Name = "namesHappyScenario.csv", Data = fileContent };

            var content = new StringContent(JsonConvert.SerializeObject(file));

            var response = _client.PostAsync("/files/names", content);

            object t = null;
            if (response.Result.IsSuccessStatusCode)
            {
                t = JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result);

            }

            Assert.IsNotNull(t);
        }
    }
}
