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
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName;}
            set { mFirstName = value; }
        }
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value;  }
        }
        public string Password
        {
            get { return mPassword;}
            set { mPassword = value; }
        }
        public OnSignUpEventArgs(string firstName, string email, string password)
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }
    class DialogSignUp : DialogFragment
    {
        private EditText mTxtFirstName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnSignUp;

        public event EventHandler<OnSignUpEventArgs> onSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            //View view = new View(null); //Add this code to return a view and to get the code to compile.

           // var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

           // mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
          //  mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
           // mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
          //  mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mBtnSignUp.Click += mBtnSignUp_Click;

           return view;
        }

        void mBtnSignUp_Click(object sender, EventArgs e)
        {
            //user has clicked the sign up button
            onSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFirstName.Text, mTxtEmail.Text, mTxtPassword.Text));
            this.Dismiss();
        }
        public override void OnActivityCreated(Bundle savedInstancesState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//removes title bar
            base.OnActivityCreated(savedInstancesState);
        //    Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;//animation set
        }
    }
}