using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyET.Objects;
using System.Timers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyET
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Food : ContentPage
    {

        private Alien alien = new Alien();

        private TimeKeeper timeKeeper = new TimeKeeper();

        private static Timer timer;

        private bool isTimed = false;


        public Food()
        {
            InitializeComponent();
            UpdateUI();
            StartTimer();
        }

        async void BackBtnTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void feedButton_Clicked(object sender, EventArgs e)
        {
            alien.Feed();
            FeedAlien(sender, e);
            UpdateUI();
        }

        private void StartTimer()
        {
            isTimed = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Random generator = new Random();

                int randomNum = generator.Next(0, 10);

                if(randomNum < 2)
                {
                    alien.Starve();
                }
                else if(randomNum < 6)
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

        //private void StartTimer()
        //{
        //    timer = new Timer();

        //    timer.Interval = 1000;
        //    timer.Enabled = true;
        //    timer.Elapsed += UpdateTimeData;
        //    timer.Start();
        //}

        //private void ResetTimer()
        //{
        //    timeKeeper.StartTime = DateTime.Now;
        //    StartTimer();
        //}

        //public void UpdateTimeData(object sender, ElapsedEventArgs e)
        //{
        //    TimeSpan timeElapsed = e.SignalTime - timeKeeper.StartTime;

        //    AlienState newAlienState = alien.CurrentAlienState;

        //    if(timeElapsed.TotalSeconds < 10)
        //    {
        //        newAlienState = AlienState.happy;
        //    }else if(timeElapsed.TotalSeconds < 20)
        //    {
        //        newAlienState = AlienState.normal;
        //    }else if(timeElapsed.TotalSeconds >= 20)
        //    {
        //        newAlienState = AlienState.sad;
        //    }

        //    if(newAlienState != alien.CurrentAlienState)
        //    {
        //        alien.CurrentAlienState = newAlienState;
        //        UpdateUI();
        //    }
        //}

        private void FeedAlien(System.Object sender, System.EventArgs e)
        {
            alien.Feed();
            UpdateUI();
        }

        void UpdateUI()
        {
            var hungerState = HungerStates.GetHungerString(HungerStates.GetStateFromHunger(alien.Hunger));
            if (hungerStateLabel.Text != hungerState)
            {
                hungerStateLabel.Text = hungerState;
            }

            hungerGauge(Convert.ToDouble(alien.Hunger) / 100);
        }

        async private void hungerGauge(double i)
        {
            await hungerBar.ProgressTo(i, 100, Easing.Linear);
        }

    }
}