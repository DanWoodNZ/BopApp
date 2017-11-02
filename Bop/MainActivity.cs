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
using Android.Content;
using Android.Views.InputMethods;

namespace Bop
{
    [Activity(Label = "Bop", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private GoogleMap GMap;
        public static List<Locations> locations;
        public Locations location;
        private DatabaseConnection connection = new DatabaseConnection();
        private UserLocationData userLocation = new UserLocationData();
        private ListView lv;
        private ListViewCustomAdapter adapter;
        private int rowNumber;



        static protected string signInEmail, signInPassword, signUpEmail, signUpPassword, signInConfirmPassword;
        private ImageButton signInButton, facebookButton, signUpButton;
        private Button forgotPWButton;
        private EditText emailField, password;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Set our view from the "main" layout resource
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);


            SetContentView(Resource.Layout.SignInView);
            emailField = FindViewById<EditText>(Resource.Id.emailField);
            password = FindViewById<EditText>(Resource.Id.passwordField);
            forgotPWButton = FindViewById<Button>(Resource.Id.forgotPasswordButton);
            signInButton = FindViewById<ImageButton>(Resource.Id.signInButton);
            facebookButton = FindViewById<ImageButton>(Resource.Id.facebookButton);
            signUpButton = FindViewById<ImageButton>(Resource.Id.signUpButton);
            //MapActivity mapActivity = new MapActivity().OnCreate(bundle);
            //InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            signUpButton.Click += (object sender, EventArgs args) =>
            {
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignUp dialogSignUp = new DialogSignUp();
                dialogSignUp.Show(transaction, "dialog fragment");
                dialogSignUp.OnSignUpComplete += SignUpDialog_mOnSignUpComplete;

            };
            signInButton.Click += (object sender, EventArgs args) =>
            {
                //Get entered field values
                signInEmail = emailField.Text;
                signInPassword = password.Text;

                if (true)
                {
                    //Dismiss Keybaord
                    InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(signInButton.WindowToken, 0);

                    var list = new Intent(this, typeof(ListViewActivity));

                    StartActivity(list);
                }
                else
                {
                    //Dismiss Keybaord
                    InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                    //imm.HideSoftInputFromWindow(signInButton.WindowToken, 0);

                    Toast.MakeText(ApplicationContext, "Invalid login", ToastLength.Long).Show();
                }


            };

        }


        void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {




            //
        }
    }
}

