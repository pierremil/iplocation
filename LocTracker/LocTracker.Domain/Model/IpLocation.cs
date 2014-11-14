using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LocTracker.Domain.Model
{
    [Serializable]
    [XmlRoot("IpLocation")]
    public class IpLocation
    {
        public IpLocation()
        {
            this.IP= string.Empty;
            this.Country_Code= string.Empty;
            this.Country_Name= string.Empty;
            this.City= string.Empty;
            this.ZipCode= string.Empty;
            this.Latitude= string.Empty;
            this.Longitude= string.Empty;
            this.Region_Name= string.Empty;
            this.Metro_Code= string.Empty;
            this.Areaode = string.Empty;
        }
        [XmlElement("ip")]
        public string IP { get; set; }
        [XmlElement("country_code")]
        public string Country_Code { get; set; }
        [XmlElement("country_name")]
        public string Country_Name { get; set; }
        [XmlElement("region_name")]
        public string Region_Name { get; set; }
        [XmlElement("city")]
        public string City { get; set; }
        [XmlElement("zipcode")]
        public string ZipCode { get; set; }
        [XmlElement("latitude")]
        public string Latitude { get; set; }
        [XmlElement("longitude")]
        public string Longitude { get; set; }
        [XmlElement("metro_code")]
        public string Metro_Code { get; set; }
        [XmlElement("area_code")]
        public string Areaode { get; set; }
    }
}
