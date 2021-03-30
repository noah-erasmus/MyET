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
    public partial class Home : ContentPage
    {
        private Alien alien = new Alien();

        private bool isTimed = false;

        public Home()
        {
            InitializeComponent();
            UpdateUI();
            StartTimer();
        }

        //async void FoodMeterTapped(System.Object sender, System.EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new Food());
        //}

        private void StartTimer()
        {
            isTimed = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Random generator = new Random();

                int randomNum = generator.Next(0, 10);

                if (randomNum < 2)
                {
                    alien.Starve();
                }
                else if (randomNum < 6)
                {
                    alien.Isolate();
                }
                else if (randomNum < 8)
                {
                    alien.Escape();
                }
                else
                {
                    alien.Starve();
                    alien.Isolate();
                }

                UpdateUI();

                if (isTimed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
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

        private void feedButton_Clicked(object sender, EventArgs e)
        {
            //alien.Feed();
            FeedAlien(sender, e);
            UpdateUI();
        }

        private void socialButton_Clicked(object sender, EventArgs e)
        {
            //alien.Chat();
            ChatAlien(sender, e);
            UpdateUI();
        }

        private void abductButton_Clicked(object sender, EventArgs e)
        {
            //alien.Chat();
            AbductAlien(sender, e);
            UpdateUI();
        }

        private void FeedAlien(System.Object sender, System.EventArgs e)
        {
            alien.Feed();
            UpdateUI();
        }

        private void ChatAlien(System.Object sender, System.EventArgs e)
        {
            alien.Chat();
            UpdateUI();
        }

        private void AbductAlien(System.Object sender, System.EventArgs e)
        {
            alien.Abduct();
            UpdateUI();
        }

        void UpdateUI()
        {
            if(alienNameTitle.Text != alien.AlienName)
            {
                alienNameTitle.Text = alien.AlienName;
            }

            hungerGauge(Convert.ToDouble(alien.Hunger) / 100);
            socialGauge(Convert.ToDouble(alien.Social) / 100);
            abductionGauge(Convert.ToDouble(alien.Abduction) / 100);
        }

        async private void hungerGauge(double i)
        {
            await hungerBar.ProgressTo(i, 100, Easing.Linear);
        }

        async private void socialGauge(double i)
        {
            await socialBar.ProgressTo(i, 100, Easing.Linear);
        }

        async private void abductionGauge(double i)
        {
            await abductionBar.ProgressTo(i, 100, Easing.Linear);
        }
    }
}