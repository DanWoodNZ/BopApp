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

        public int LocationImageUrl { get; set; }

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

            locations[0].LocationImageUrl = (Resource.Drawable.locCitizen);
            locations[1].LocationImageUrl = (Resource.Drawable.locFedDeli);
            locations[2].LocationImageUrl = (Resource.Drawable.locCassette);
            locations[3].LocationImageUrl = (Resource.Drawable.locBCC);
            locations[4].LocationImageUrl = (Resource.Drawable.locLaZeppa);
            locations[5].LocationImageUrl = (Resource.Drawable.locSwashbucklers);
            locations[6].LocationImageUrl = (Resource.Drawable.locAtomic);
            locations[7].LocationImageUrl = (Resource.Drawable.locOrphans);
            locations[8].LocationImageUrl = (Resource.Drawable.locCocos);
            locations[9].LocationImageUrl = (Resource.Drawable.locSkycity);
            locations[10].LocationImageUrl = (Resource.Drawable.locZoo);
            locations[11].LocationImageUrl = (Resource.Drawable.locBridge);
            locations[12].LocationImageUrl = (Resource.Drawable.locBungy);
            locations[13].LocationImageUrl = (Resource.Drawable.locKellyTarltons);
            locations[14].LocationImageUrl = (Resource.Drawable.locMotat);
            locations[15].LocationImageUrl = (Resource.Drawable.locAucklandMuseum);
            locations[16].LocationImageUrl = (Resource.Drawable.locRainbowsEnd);
            locations[17].LocationImageUrl = (Resource.Drawable.locWaiheke);
            locations[18].LocationImageUrl = (Resource.Drawable.locHunua);
            locations[19].LocationImageUrl = (Resource.Drawable.locKitekite);
            locations[20].LocationImageUrl = (Resource.Drawable.locMission);
            locations[21].LocationImageUrl = (Resource.Drawable.locRangitoto);
            locations[22].LocationImageUrl = (Resource.Drawable.locOneTreeHill);
            locations[23].LocationImageUrl = (Resource.Drawable.locPiha);
            locations[24].LocationImageUrl = (Resource.Drawable.locMtEden);
            locations[25].LocationImageUrl = (Resource.Drawable.locParnellRose);

            return locations;

        }
            
    }
}