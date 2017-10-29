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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            //Call to method to fill local locations with location data from Azure Database

            locations = connection.RetrieveLocationData();
            GetLocationListView();
        }

        private void SetUpMap()
        {
            Button backButton = FindViewById<Button>(Resource.Id.mapBackButton);
            backButton.Click += (o, e) =>
            {
               


            };


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

            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(new LatLng(-36.873887, 174.737457), 15);
            GMap.MoveCamera(camera);

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

        }



        public void GetLocationView()
        {
            Console.WriteLine("LOCATL TABLE CONNECTED. Size of array is == " + locations.Count);
        }



    }
}

