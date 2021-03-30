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
    public partial class Death : ContentPage
    {
        public Death()
        {
            InitializeComponent();
        }

        async void reviveSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            await Navigation.PushModalAsync(new NameAlien());
        }
    }
}