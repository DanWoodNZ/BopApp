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
        private ListView lv;
        private ListViewCustomAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);


            Locations loc = new Locations();

            locations = loc.getLocationsList();

            //locations = connection.RetrieveLocationData();

            //Console.WriteLine("User location from MAIN = "+userLocation.GetUserPosition());

            //SetContentView(Resource.Layout.MapView);


            //SetUpMap();



            //Console.WriteLine("User location from MAIN = " + userLocation.GetUserPosition());

            SetListView();


            //Console.WriteLine("User location from MAIN = "+userLocation.GetUserPosition());

            //SetContentView(Resource.Layout.MapView);

            //SetUpMap();

        }

        public void SetListView()
        {
            SetContentView(Resource.Layout.ListView);
            lv = FindViewById<ListView>(Resource.Id.listView1);
            adapter = new ListViewCustomAdapter(this, Resource.Layout.ListLayout, locations);

            lv.Adapter = adapter;

            lv.ItemClick += ListViewItemClick;

            ImageButton mapButton = FindViewById<ImageButton>(Resource.Id.floatMapButton);
            mapButton.Click += (s, e) =>
            {
                SetUpMap();
            };
        }

        public void ListViewItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            GetLocationView();
        }

        private void SetUpMap()
        {
            SetContentView(Resource.Layout.MapView);

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
            SetContentView(Resource.Layout.LocationView);

            ImageButton backButton = FindViewById<ImageButton>(Resource.Id.backButton);
            backButton.Click += (s, e) =>
            {
                SetListView();
            };
        }
    }
}

