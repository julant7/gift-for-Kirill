using GiftForSweet.Views;
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


    }
}
