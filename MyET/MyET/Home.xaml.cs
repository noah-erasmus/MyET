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
            NewAlien();
            UpdateUI();
            StartTimer();
        }

        //TimeKeeper
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

        private void NewAlien()
        {
            alien.Birth();
        }

        //async void FoodMeterTapped(System.Object sender, System.EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new Food());
        //}

        //async void AbductionsMeterTapped(System.Object sender, System.EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new Abductions());
        //}

        //async void SocialMeterTapped(System.Object sender, System.EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new Social());
        //}

        async void BackBtnTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void HelpBtnTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Help());
        }

        //Attention Controls
        private void feedButton_Clicked(object sender, EventArgs e)
        {
            FeedAlien(sender, e);
            UpdateUI();
        }

        async void editBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Edit());
        }

        private void socialButton_Clicked(object sender, EventArgs e)
        {
            ChatAlien(sender, e);
            UpdateUI();
        }

        private void abductButton_Clicked(object sender, EventArgs e)
        {
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

        //Status Gauges
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

        private void feedGesture(object sender, EventArgs e)
        {
            FeedAlien(sender, e);
            UpdateUI();
        }

        private void socialGesture(object sender, EventArgs e)
        {
            ChatAlien(sender, e);
            UpdateUI();
        }

        private void abductGesture(object sender, EventArgs e)
        {
            AbductAlien(sender, e);
            UpdateUI();
        }

        async void Die()
        {
            alien.Hunger = 50;
            await Navigation.PushModalAsync(new Death());
        }

        //UpdateUI
        void UpdateUI()
        {
            if(alienNameTitle.Text != alien.AlienName)
            {
                alienNameTitle.Text = alien.AlienName;
            }

            hungerGauge(Convert.ToDouble(alien.Hunger) / 100);
            socialGauge(Convert.ToDouble(alien.Social) / 100);
            abductionGauge(Convert.ToDouble(alien.Abduction) / 100);

            var totalPoints = alien.Hunger + alien.Social + alien.Abduction;

            if(totalPoints < 100)
            {
                var colour = alien.AlienColour;
                var mood = "sad";
                if(alienHead.Source != ImageSource.FromFile("alien_"+mood+"_"+colour+".png"))
                {
                    alienHead.Source = ImageSource.FromFile("alien_" + mood + "_" + colour + ".png");
                }
            }
            else if(totalPoints < 200)
            {
                var colour = alien.AlienColour;
                var mood = "neutral";
                if (alienHead.Source != ImageSource.FromFile("alien_" + mood + "_" + colour + ".png"))
                {
                    alienHead.Source = ImageSource.FromFile("alien_" + mood + "_" + colour + ".png");
                }
            }
            else if (totalPoints < 300)
            {
                var colour = alien.AlienColour;
                var mood = "happy";
                if (alienHead.Source != ImageSource.FromFile("alien_" + mood + "_" + colour + ".png"))
                {
                    alienHead.Source = ImageSource.FromFile("alien_" + mood + "_" + colour + ".png");
                }
            }
            else
            {
                alienHead.Source = ImageSource.FromFile("alien_happy_green.png");
            }

            if (earth.Source != ImageSource.FromFile("earth.png"))
            {
                earth.Source = ImageSource.FromFile("earth.png");
            }

            if(alien.Hunger == 0)
            {
                Die();
            }

        }

        
    }
}