using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyET
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        async void FoodMeterTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Food());
        }

        async void AbductionsMeterTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Abductions());
        }

        async void SocialMeterTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Social());
        }

        async void BackBtnTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}