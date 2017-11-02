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

namespace Bop
{
    [Activity(Label = "ListViewActivity")]
    public class ListViewActivity : Activity
    {
       
        private ListView listView;
        private ListViewCustomAdapter adapter;
        private int rowNumber;
        public static List<Locations> locations;
        public Locations location = new Locations();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListView);

            locations = location.getLocationsList();
            Console.WriteLine("Database ====== " + locations.Count);

            //Populate list view using custom adapter and database locations
            listView = FindViewById<ListView>(Resource.Id.listView1);
            adapter = new ListViewCustomAdapter(this, Resource.Layout.ListLayout, locations);
            listView.Adapter = adapter;

            //Add click event to list items
            listView.ItemClick += ListViewItemClick;
            

            //Add click event to map button, opening the map activity
            ImageButton mapButton = FindViewById<ImageButton>(Resource.Id.floatMapButton);
            mapButton.Click += (s, e) =>
            {
                Intent map = new Intent(this, typeof(MapActivity));
                StartActivity(map);
            };
        }

        public void ListViewItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            rowNumber = e.Position;
            Intent loc = new Intent(this, typeof(LocationViewActivity));
            loc.PutExtra("rowNumber", rowNumber);
            StartActivity(loc);
        }
    }
}