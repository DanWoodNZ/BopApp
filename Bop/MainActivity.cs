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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            //Call to method to fill local locations with location data from Azure Database
            RetrieveLocationData();

            GetLocationListView();
        }


        //Setups the the button the the LocationView to go back to the ListView
        private void SetupBackButton()
        {
            ImageButton button1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
            button1.Click += (o, e) =>
            {
                Toast.MakeText(this, "Pressed imageButton1", ToastLength.Short).Show();
                SetContentView(Resource.Layout.ListView);

                RetrieveLocationData();

                SetupListView();
            };
        }

        //Setups the ImageButton to go from a item in the list view to that items page.
        private void SetupListView()
        {
            //Controlling the first image button with a click event
            ImageButton button = FindViewById<ImageButton>(Resource.Id.test1); //Select the FIrstImage button in the list view
            button.Click += (o, e) =>
            {
                Toast.MakeText(this, "Pressed test1", ToastLength.Short).Show(); //When clicked, shows a toast message on screen
                SetContentView(Resource.Layout.LocationView);
                PopulateLocationPage(2);
                SetupBackButton();
            };

            //Add a event to the map button click, which takes the user to the map screen
            ImageButton mapButton = FindViewById<ImageButton>(Resource.Id.floatMapButton);
            mapButton.Click += (o, e) =>
            {
                Toast.MakeText(this, "Pressed map button", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Map);
                SetUpMap();

            };

        }

        private void SetUpMap()
        {
            Button backButton = FindViewById<Button>(Resource.Id.mapBackButton);
            backButton.Click += (o, e) =>
            {
                SetContentView(Resource.Layout.ListView);
                SetupListView();

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

        public void RetrieveLocationData ()
        {
            Task.Run(async () =>
            {
                // Initialization for Azure Mobile Apps
                Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
                // This MobileServiceClient has been configured to communicate with the Azure Mobile App and
                // Azure Gateway using the application url. You're all set to start working with your Mobile App!
                Microsoft.WindowsAzure.MobileServices.MobileServiceClient BopAppClient = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
                "https://bopapp.azurewebsites.net");

                Console.WriteLine("MOBILE SERVICE CLIENT CONNECTED");

                //Mobile stored version of database.
                IMobileServiceTable<Locations> table = BopAppClient.GetTable<Locations>();

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

        public void PopulateLocationPage(int SelectedLocation)
        {
            SetContentView(Resource.Layout.LocationView);

            TextView locationName = FindViewById<TextView>(Resource.Id.locationHeader);
            locationName.Text = locations[SelectedLocation].LocationName;

            TextView locationDescription = FindViewById<TextView>(Resource.Id.textView1);
            locationDescription.Text = locations[SelectedLocation].LocationDescription;
        }

       //method to get images adreseses stored in the rsources/drable folder and add them to 
       public void getImageAdresses()
        {
            for (int i = 0; i < locations.Count; i++)
            {
                string locationName = locations[i].LocationName;
                locationName = locationName.Replace(" ", String.Empty);
                locations[i].ImageAdresses.Add( "Resource/drawable/List" + locationName);
            }
        } 

        public void GetLocationListView()
        {
            SetContentView(Resource.Layout.ListView);
            int numberOfLocations = 7;
            List<ImageButton> locationListButtons= new List<ImageButton>();
        
            locationListButtons.Add(FindViewById<ImageButton>(2131558439));
            locationListButtons.Add(FindViewById<ImageButton>(2131558440));
            locationListButtons.Add(FindViewById<ImageButton>(2131558441));
            locationListButtons.Add(FindViewById<ImageButton>(2131558442));
            locationListButtons.Add(FindViewById<ImageButton>(2131558443));
            locationListButtons.Add(FindViewById<ImageButton>(2131558444));
            locationListButtons.Add(FindViewById<ImageButton>(2131558445));

           

            for (int i = 0; i < numberOfLocations; i++)
            {
                locationListButtons[i].Click += (o, e) =>
                {
                   Toast.MakeText(this, "Pressed test", ToastLength.Short).Show(); //When clicked, shows a toast message on screen
                };
            }
        }
    }
}

