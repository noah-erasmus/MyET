using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyET.Objects;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyET
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NameAlien : ContentPage
    {
        private Alien alien = new Alien();
        public NameAlien()
        {
            InitializeComponent();
        }

        async void NameAlienTapped(System.Object sender, System.EventArgs e)
        {
            alien.AlienName = AlienNameInput.Text;
            await Navigation.PushModalAsync(new Home());
        }
    }
}