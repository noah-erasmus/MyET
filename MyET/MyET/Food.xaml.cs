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
            alien.giveFood();
            UpdateUI();
        }

        private void StartTimer()
        {
            timer = new Timer();

            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += UpdateTimeData;
            timer.Start();
        }

        private void ResetTimer()
        {
            timeKeeper.StartTime = DateTime.Now;
            StartTimer();
        }

        public void UpdateTimeData(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeElapsed = e.SignalTime - timeKeeper.StartTime;

            AlienState newAlienState = alien.CurrentAlienState;

            if(timeElapsed.TotalSeconds < 10)
            {
                newAlienState = AlienState.happy;
            }else if(timeElapsed.TotalSeconds < 20)
            {
                newAlienState = AlienState.normal;
            }else if(timeElapsed.TotalSeconds >= 20)
            {
                newAlienState = AlienState.sad;
            }

            if(newAlienState != alien.CurrentAlienState)
            {
                alien.CurrentAlienState = newAlienState;
                UpdateUI();
            }
        }

        void UpdateUI()
        {
            var hungerString = alien.CurrentAlienState;
            if(hungerStateLabel.Text != hungerString.ToString())
            {
                hungerStateLabel.Text = hungerString.ToString();
            }
            int alienXp = alien.Xp;
        }
    }
}