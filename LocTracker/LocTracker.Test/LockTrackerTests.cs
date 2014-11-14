using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using LocTracker.Domain.Model;
using Newtonsoft.Json;

namespace LocTracker.Test
{
    [TestClass]
    public class LockTrackerTest
    {
        [TestMethod]
        public void AssertImagesExistTest()
        {
            var exit = LocTracker.Properties.Resources.Exit;
            Assert.IsInstanceOfType(exit, typeof(Bitmap));
        }

        [TestMethod]
        public void TestLocationApiTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://freegeoip.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("json").Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Assert.IsTrue(response.IsSuccessStatusCode);
                IpLocation loc = JsonConvert.DeserializeObject<IpLocation>(result);
                Assert.IsTrue(loc.IP != null);
            }    
        }


    }
}
