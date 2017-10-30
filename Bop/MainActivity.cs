using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Bop
{
    [Activity(Label = "Bop", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback
    {

        private GoogleMap GMap;
        private List<Locations> locations;
        private DatabaseConnection connection = new DatabaseConnection();
        private UserLocationData userLocation = new UserLocationData();
        private ListViewCustomAdapter adapter;
        private ListView lv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            //locations = connection.RetrieveLocationData();

            locations = new List<Locations>()
            {
                new Locations(Resource.Drawable.ListFedDeli),
                new Locations(Resource.Drawable.ListBCC),
                new Locations(Resource.Drawable.ListCocos),
                new Locations(Resource.Drawable.ListFedDeli),
                new Locations(Resource.Drawable.ListBCC),
                new Locations(Resource.Drawable.ListCocos),
                new Locations(Resource.Drawable.ListFedDeli),
                new Locations(Resource.Drawable.ListBCC),
                new Locations(Resource.Drawable.ListCocos),
            };

            //Console.WriteLine("User location from MAIN = " + userLocation.GetUserPosition());

            SetContentView(Resource.Layout.ListView);

            lv = FindViewById<ListView>(Resource.Id.listView1);
            adapter = new ListViewCustomAdapter(this, Resource.Layout.ListLayout, locations);

            lv.Adapter = adapter;


            //SetUpMap();

        }




        private void SetUpMap()
        {
            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            this.GMap = googleMap;
            GMap.SetMapStyle(MapStyleOptions.LoadRawResourceStyle(this, Resource.Raw.style_json));
            GMap.UiSettings.ZoomControlsEnabled = true;

            List<MarkerOptions> markers = new List<MarkerOptions>();
            MarkerOptions userMarker = new MarkerOptions().SetPosition(userLocation.GetUserPosition()).SetTitle("INSERT USERNAME").SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.uber));
            GMap.AddMarker(userMarker);

            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(userLocation.GetUserPosition(), 15);
            GMap.MoveCamera(camera);

            GMap.MyLocationChange += (s, e) =>
            {
                LatLng currentLatLng = userLocation.GetUserPosition();
                Console.WriteLine("New user location = " + currentLatLng);

            };

            markers = GenerateMarkers();
            PlaceMarkers(markers);
        }

        public List<MarkerOptions> GenerateMarkers()
        {
            List<MarkerOptions> markers = new List<MarkerOptions>();
            LatLng coordinates;

            for (int i = 0; i < locations.Count; i++)
            {
                coordinates = new LatLng(locations[i].LocationX, locations[i].LocationY);
                markers.Add(new MarkerOptions().SetPosition(coordinates).SetTitle(locations[i].LocationName).SetIcon(BitmapDescriptorFactory.DefaultMarker(14)));
            }

            return markers;
        }

        public void PlaceMarkers(List<MarkerOptions> markers)
        {
            for (int i = 0; i < markers.Count; i++)
            {
                GMap.AddMarker(markers[i]);
            }
        }

       










        //Method to create 
        public void GetLocationListView()
        {
            ImageButton mapButton = FindViewById<ImageButton>(Resource.Id.floatMapButton);
        }

        public void GetLocationView()
        {
            Console.WriteLine("LOCATL TABLE CONNECTED. Size of array is == " + locations.Count);
        }
    }
}