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
    class Controllers
    {
        public void LocationViewButton()
        {
             Button button = (Button)findViewById(R.id.button_id);
            button.setOnClickListener(new View.OnClickListener()
            {
             public void onClick(View v)
            {
                // Perform action on click
            }
        }

  
    }
}