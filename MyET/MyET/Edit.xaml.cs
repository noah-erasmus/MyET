using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyET.Objects;

namespace MyET
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edit : ContentPage
    {
        private Alien alien = new Alien();

        public Edit()
        {
            InitializeComponent();
        }

        async void setColourGreen()
        {
            if(alien.AlienColour != "green")
            {
                alien.AlienColour = "green";
                await Navigation.PopModalAsync();
            }
        }

        async void setColourRed()
        {
            if (alien.AlienColour != "red")
            {
                alien.AlienColour = "red";
                await Navigation.PopModalAsync();
            }
        }

        async void setColourBlue()
        {
            if (alien.AlienColour != "blue")
            {
                alien.AlienColour = "blue";
                await Navigation.PopModalAsync();
            }
        }
    }
}