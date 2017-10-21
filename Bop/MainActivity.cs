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

namespace Bop
{
    [Activity(Label = "Bop", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;
        private List<Locations> locations;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListView);
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
            RetrieveLocationData();
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

        public void RetrieveLocationData()
        {
            Task.Run(async () =>
            {
                // Initialization for Azure Mobile Apps
                Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

                // This MobileServiceClient has been configured to communicate with the Azure Mobile App and
                // Azure Gateway using the application url. You're all set to start working with your Mobile App!
                MobileServiceClient testbopClient = new MobileServiceClient(
                "https://testbop.azurewebsites.net");

                Console.WriteLine("MOBILE SERVICE CLIENT CONNECTED");

                //Mobile stored version of database.
                IMobileServiceTable<Locations> table = testbopClient.GetTable<Locations>();

                Console.WriteLine("MOBILE SERVICE TABLE CONNECTED");

                try
                {
                    locations = await table.ToListAsync();

                    Console.WriteLine("LOCATL TABLE CONNECTED. Size of array is == " + locations.Count);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }

                Console.WriteLine($"Are we on the UI thread? {Looper.MainLooper.Thread == Looper.MyLooper()?.Thread}");

                Console.WriteLine("Done fetching/calculating data");

                RunOnUiThread(() =>
                {
                    // Update the data fetched/calculated on the UI thread;
                    Console.WriteLine($"Are we on the UI thread? {Looper.MainLooper.Thread == Looper.MyLooper().Thread}");
                });

            }).Wait();

            Console.WriteLine("retrieveLocationData");
        }
    }
}

