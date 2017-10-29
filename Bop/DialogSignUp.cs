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
    public class OnSignUpEventArgs : EventArgs
    {
        private string txtUserName;
        private string txtEmail;
        private string txtPassword;

        public string UserName
        {
            get { return txtUserName; }
            set { txtUserName = value; }
        }
        public string Email
        {
            get { return txtEmail; }
            set { txtEmail = value;  }
        }
        public string Password
        {
            get { return txtPassword;}
            set { txtPassword = value; }
        }
        public OnSignUpEventArgs(string txtUserName, string email, string password)
        {
            UserName = txtUserName;
            Email = txtEmail;
            Password = txtPassword;
        }
    }
    class DialogSignUp : DialogFragment
    {
        private EditText nameField;
        private EditText emailField;
        private EditText passwordField;
        private EditText reEnterField;
        private ImageButton submitButton;

        public event EventHandler<OnSignUpEventArgs> OnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            //View view = new View(null); //Add this code to return a view and to get the code to compile.

           var view = inflater.Inflate(Resource.Layout.SignUpPopup, container, false);

            nameField = view.FindViewById<EditText>(Resource.Id.nameField);
            emailField = view.FindViewById<EditText>(Resource.Id.emailField);
            passwordField = view.FindViewById<EditText>(Resource.Id.passwordField);
            submitButton = view.FindViewById<ImageButton>(Resource.Id.submitButton);

            submitButton.Click += submitButton_Click;

           return view;
        }

        void submitButton_Click(object sender, EventArgs e)
        {
            //user has clicked the sign up button
            OnSignUpComplete.Invoke(this, new OnSignUpEventArgs(nameField.Text, emailField.Text, passwordField.Text));
            this.Dismiss();
        }
        public override void OnActivityCreated(Bundle savedInstancesState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//removes title bar
            base.OnActivityCreated(savedInstancesState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.popUpAnimations;//animation set
        }
    }
}