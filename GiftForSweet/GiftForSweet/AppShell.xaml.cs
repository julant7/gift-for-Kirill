﻿using GiftForSweet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace GiftForSweet
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Device.SetFlags(new string[] { "AppTheme_Experimental" });

            InitializeComponent();

            Routing.RegisterRoute(nameof(NoteAddingPage), typeof(NoteAddingPage));
        }

        private async void authBtn_Clicked(object sender, EventArgs e)
        {
            bool isFingerPrintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);

            if (isFingerPrintAvailable)
            {
                await DisplayAlert("Alert", "Biometric Auth. not available or configure on this device.", "Okay");
                return;
            }

            AuthenticationRequestConfiguration configuration = new AuthenticationRequestConfiguration("Authentication", "Authenticate access for login");

            var result = await CrossFingerprint.Current.AuthenticateAsync(configuration);
            if (result.Authenticated)
            {
                // Authenticate Successfully 
                await DisplayAlert("Success", "Login Successfully", "Okay");
            }
            else
            {
                // Something went wrong 
                await DisplayAlert("Alert", "Login failed. Please try again", "Okay");
            }
        }


    }
}


