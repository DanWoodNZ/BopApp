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
            List<Locations> databaseLocs = connection.RetrieveLocationData();

            databaseLocs[0].ListImageUrl = (Resource.Drawable.ListCitizenPark);
            databaseLocs[1].ListImageUrl = (Resource.Drawable.ListFedDeli);
            databaseLocs[2].ListImageUrl = (Resource.Drawable.ListCassetteNine);
            databaseLocs[3].ListImageUrl = (Resource.Drawable.ListBCC);
            databaseLocs[4].ListImageUrl = (Resource.Drawable.ListLaZeppa);
            databaseLocs[5].ListImageUrl = (Resource.Drawable.ListSwashbucklers);
            databaseLocs[6].ListImageUrl = (Resource.Drawable.ListAtomic);
            databaseLocs[7].ListImageUrl = (Resource.Drawable.ListOrphansKitchen);
            databaseLocs[8].ListImageUrl = (Resource.Drawable.ListCocos);
            databaseLocs[9].ListImageUrl = (Resource.Drawable.ListSkycity);
            databaseLocs[10].ListImageUrl = (Resource.Drawable.ListAucklandZoo);
            databaseLocs[11].ListImageUrl = (Resource.Drawable.ListAucklandBridge);
            databaseLocs[12].ListImageUrl = (Resource.Drawable.ListAucklandBungy);
            databaseLocs[13].ListImageUrl = (Resource.Drawable.ListKellyTarltons);
            databaseLocs[14].ListImageUrl = (Resource.Drawable.ListMotat);
            databaseLocs[15].ListImageUrl = (Resource.Drawable.ListAucklandMuseum);
            databaseLocs[16].ListImageUrl = (Resource.Drawable.ListRainbows);
            databaseLocs[17].ListImageUrl = (Resource.Drawable.ListWaiheke);
            databaseLocs[18].ListImageUrl = (Resource.Drawable.ListHunuaFalls);
            databaseLocs[19].ListImageUrl = (Resource.Drawable.ListKitekiteFalls);
            databaseLocs[20].ListImageUrl = (Resource.Drawable.ListMissionBay);
            databaseLocs[21].ListImageUrl = (Resource.Drawable.ListRangitotoIsland);
            databaseLocs[22].ListImageUrl = (Resource.Drawable.ListOneTreeHill);
            databaseLocs[23].ListImageUrl = (Resource.Drawable.ListPiha);
            databaseLocs[24].ListImageUrl = (Resource.Drawable.ListMtEden);
            databaseLocs[25].ListImageUrl = (Resource.Drawable.ListParnellGardens);

            databaseLocs[0].LocationImageUrl = (Resource.Drawable.locCitizen);
            databaseLocs[1].LocationImageUrl = (Resource.Drawable.locFedDeli);
            databaseLocs[2].LocationImageUrl = (Resource.Drawable.locCassette);
            databaseLocs[3].LocationImageUrl = (Resource.Drawable.locBCC);
            databaseLocs[4].LocationImageUrl = (Resource.Drawable.locLaZeppa);
            databaseLocs[5].LocationImageUrl = (Resource.Drawable.locSwashbucklers);
            databaseLocs[6].LocationImageUrl = (Resource.Drawable.locAtomic);
            databaseLocs[7].LocationImageUrl = (Resource.Drawable.locOrphans);
            databaseLocs[8].LocationImageUrl = (Resource.Drawable.locCocos);
            databaseLocs[9].LocationImageUrl = (Resource.Drawable.locSkycity);
            databaseLocs[10].LocationImageUrl = (Resource.Drawable.locZoo);
            databaseLocs[11].LocationImageUrl = (Resource.Drawable.locBridge);
            databaseLocs[12].LocationImageUrl = (Resource.Drawable.locBungy);
            databaseLocs[13].LocationImageUrl = (Resource.Drawable.locKellyTarltons);
            databaseLocs[14].LocationImageUrl = (Resource.Drawable.locMotat);
            databaseLocs[15].LocationImageUrl = (Resource.Drawable.locAucklandMuseum);
            databaseLocs[16].LocationImageUrl = (Resource.Drawable.locRainbowsEnd);
            databaseLocs[17].LocationImageUrl = (Resource.Drawable.locWaiheke);
            databaseLocs[18].LocationImageUrl = (Resource.Drawable.locHunua);
            databaseLocs[19].LocationImageUrl = (Resource.Drawable.locKitekite);
            databaseLocs[20].LocationImageUrl = (Resource.Drawable.locMission);
            databaseLocs[21].LocationImageUrl = (Resource.Drawable.locRangitoto);
            databaseLocs[22].LocationImageUrl = (Resource.Drawable.locOneTreeHill);
            databaseLocs[23].LocationImageUrl = (Resource.Drawable.locPiha);
            databaseLocs[24].LocationImageUrl = (Resource.Drawable.locMtEden);
            databaseLocs[25].LocationImageUrl = (Resource.Drawable.locParnellRose); 

            return databaseLocs;
        }
            
    }
}