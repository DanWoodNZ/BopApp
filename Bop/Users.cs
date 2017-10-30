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
using Newtonsoft.Json;

namespace Bop
{
    class Users
    {
        [JsonProperty("id")]
        string Id { get; set; }

        [JsonProperty("FName")]
        string FName { get; set; }

        [JsonProperty("LName")]
        string LName { get; set; }

        [JsonProperty("UserName")]
        string UserName { get; set; }

        [JsonProperty("Email")]
        string Email { get; set; }

        [JsonProperty("Password")]
        string Password { get; set; }

        public List<Users> getUsersList()
            {
            DatabaseConnection connection = new DatabaseConnection();
            List<Users> users = connection.RetrieveUserData();
               

            return users;
}

    }
}