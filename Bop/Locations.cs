using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps.Model;
using Newtonsoft.Json;
using Android.Media;
using System.Collections;

namespace Bop
{
    public class Locations
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("locationAddress")]
        public string LocationAddress { get; set; }

        [JsonProperty("locationPhone")]
        public string LocationPhone { get; set; }

        [JsonProperty("locationWebsite")]
        public string LocationWebsite { get; set; }

        [JsonProperty("locationDescription")]
        public string LocationDescription { get; set; }

        [JsonProperty("locationType")]
        public string LocationType { get; set; }

        [JsonProperty("locationPoints")]
        public int LocationPoints { get; set; }

        [JsonProperty("locationX")]
        public double LocationX { get; set; }

        [JsonProperty("locationY")]
        public double LocationY { get; set; }

        [JsonProperty("listImageUrl")]
        public string ListImageUrl { get; set; }

        public Locations()
        {
           
        }

        public List<Locations> getLocationsList()
        {
            DatabaseConnection connection = new DatabaseConnection();
            List<Locations> locations = connection.RetrieveLocationData();
            return locations;
        }
            
    }
}