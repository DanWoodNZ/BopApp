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
    [Activity(Label = "Bop")]
    public class MapActivity : Activity, IOnMapReadyCallback
    {
        static private GoogleMap GMap;
        static private UserLocationData userLocation = new UserLocationData();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
          
            Console.WriteLine("User location from MAIN = " + userLocation.GetUserPosition());
            SetContentView(Resource.Layout.MapView);

            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            GMap = googleMap;
            GMap.SetMapStyle(MapStyleOptions.LoadRawResourceStyle(this, Resource.Raw.style_json));
            GMap.UiSettings.ZoomControlsEnabled = true;

            List<MarkerOptions> markers = new List<MarkerOptions>();
            MarkerOptions userMarker = new MarkerOptions().SetPosition(userLocation.GetUserPosition()).SetTitle("INSERT USERNAME").SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.mapMan));
            GMap.AddMarker(userMarker);

            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom( new LatLng(-36.852392, 174.764473), 15);
            GMap.MoveCamera(camera);

            GMap.MyLocationChange += (s, e) =>
            {
                LatLng currentLatLng = userLocation.GetUserPosition();
                Console.WriteLine("New user location = " + currentLatLng);
            };
            markers = GenerateMarkers();
            PlaceMarkers(markers);

            ImageButton backButton = FindViewById<ImageButton>(Resource.Id.mapBackButton);
            backButton.SetImageResource(Resource.Drawable.IconBackArrow);
            backButton.Click += (s, e) =>
            {
                GMap = null;
                Finish();
            };
        }

        public List<MarkerOptions> GenerateMarkers()
        {
            List<MarkerOptions> markers = new List<MarkerOptions>();
            LatLng coordinates;

            for (int i = 0; i < ListViewActivity.locations.Count; i++)
            {
                coordinates = new LatLng(ListViewActivity.locations[i].LocationX, ListViewActivity.locations[i].LocationY);
                markers.Add(new MarkerOptions().SetPosition(coordinates).SetTitle(ListViewActivity.locations[i].LocationName).SetIcon(BitmapDescriptorFactory.DefaultMarker(14)));
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
    }
}

