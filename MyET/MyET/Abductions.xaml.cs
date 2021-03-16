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
    public partial class Abductions : ContentPage
    {
        public Abductions()
        {
            InitializeComponent();
        }

        async void BackBtnTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}