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

        
        public int ListImageUrl { get; set; }

        public Locations()
        {
           
        }

        public List<Locations> getLocationsList()
        {
            DatabaseConnection connection = new DatabaseConnection();
            List<Locations> locations = connection.RetrieveLocationData();

            locations[0].ListImageUrl = (Resource.Drawable.ListCitizenPark);
            locations[1].ListImageUrl = (Resource.Drawable.ListFedDeli);
            locations[2].ListImageUrl = (Resource.Drawable.ListCassetteNine);
            locations[3].ListImageUrl = (Resource.Drawable.ListBCC);
            locations[4].ListImageUrl = (Resource.Drawable.ListLaZeppa);
            locations[5].ListImageUrl = (Resource.Drawable.ListSwashbucklers);
            locations[6].ListImageUrl = (Resource.Drawable.ListAtomic);
            locations[7].ListImageUrl = (Resource.Drawable.ListOrphansKitchen);
            locations[8].ListImageUrl = (Resource.Drawable.ListCocos);
            locations[9].ListImageUrl = (Resource.Drawable.ListSkycity);
            locations[10].ListImageUrl = (Resource.Drawable.ListAucklandZoo);
            locations[11].ListImageUrl = (Resource.Drawable.ListAucklandBridge);
            locations[12].ListImageUrl = (Resource.Drawable.ListAucklandBungy);
            locations[13].ListImageUrl = (Resource.Drawable.ListKellyTarltons);
            locations[14].ListImageUrl = (Resource.Drawable.ListMotat);
            locations[15].ListImageUrl = (Resource.Drawable.ListAucklandMuseum);
            locations[16].ListImageUrl = (Resource.Drawable.ListRainbows);
            locations[17].ListImageUrl = (Resource.Drawable.ListWaiheke);
            locations[18].ListImageUrl = (Resource.Drawable.ListHunuaFalls);
            locations[19].ListImageUrl = (Resource.Drawable.ListKitekiteFalls);
            locations[20].ListImageUrl = (Resource.Drawable.ListMissionBay);
            locations[21].ListImageUrl = (Resource.Drawable.ListRangitotoIsland);
            locations[22].ListImageUrl = (Resource.Drawable.ListOneTreeHill);
            locations[23].ListImageUrl = (Resource.Drawable.ListPiha);
            locations[24].ListImageUrl = (Resource.Drawable.ListMtEden);
            locations[25].ListImageUrl = (Resource.Drawable.ListParnellGardens);
          
            

            return locations;

        }
            
    }
}