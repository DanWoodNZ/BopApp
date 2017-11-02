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
using Java.Lang;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Bop
{
    class DatabaseConnection 
    {
        List<Locations> locations = new List<Locations>();
        List<Users> users = new List<Users>();

        public List<Locations> RetrieveLocationData()
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

                catch (System.Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }

                Console.WriteLine($"Are we on the UI thread? {Looper.MainLooper.Thread == Looper.MyLooper()?.Thread}");

                Console.WriteLine("Done fetching/calculating data");

            

            }).Wait();

            Console.WriteLine("retrieveLocationData");
            return locations;
        }

        public List<Users> RetrieveUserData()
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
                IMobileServiceTable<Users> table = BopAppClient.GetTable<Users>();

                Console.WriteLine("MOBILE SERVICE TABLE CONNECTED");

                try
                {
                    users = await table.ToListAsync();

                    Console.WriteLine("LOCATL TABLE CONNECTED. Size of array is == " + users.Count);
                }

                catch (System.Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }

                Console.WriteLine($"Are we on the UI thread? {Looper.MainLooper.Thread == Looper.MyLooper()?.Thread}");

                Console.WriteLine("Done fetching/calculating data");
            }).Wait();

            Console.WriteLine("retrievedUserData");
            return users;
        }
    }
    
}