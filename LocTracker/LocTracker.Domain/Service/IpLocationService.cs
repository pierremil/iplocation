using LocTracker.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LocTracker.Domain.Service
{
    public class IpLocationService 
    {
        public static async Task GetIpLocation()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://freegeoip.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("json").Result;

                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    
                    IpLocation loc = JsonConvert.DeserializeObject<IpLocation>(result);

                    IpLocation ip = response.Content.ReadAsAsync<IpLocation>().Result;
                    Console.WriteLine("{0}\t${1}\t{2}", ip.IP , ip.Country_Name, loc.ZipCode);
                }
            }
        }


       
    }
}
