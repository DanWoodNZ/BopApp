
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
    [Activity(Label = "ListViewCustomAdapter")]
    public class ListViewCustomAdapter : ArrayAdapter<Locations>
    {
        private List<Locations> locations;
        private Context context;
        private int resource;
        private LayoutInflater inflater;


        public ListViewCustomAdapter(Context context, int resource, List<Locations> locations) : base(context, resource, locations)
        {
            this.context = context;
            this.locations = locations;
            this.resource = resource;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (inflater == null)
            {
                inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            }

            if (convertView == null)
            {
                convertView = inflater.Inflate(resource, parent, false);
            }

            //Bind the data 
            ImageHolder holder = new ImageHolder(convertView);

            holder.image.SetImageResource(locations[position].ListImageUrl);

            return convertView;
        }
    }
}
