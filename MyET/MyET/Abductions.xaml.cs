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
    public partial class Abductions : ContentPage
    {
        private Alien alien = new Alien();

        private TimeKeeper timeKeeper = new TimeKeeper();

        private static Timer timer;

        private bool isTimed = false;
        public Abductions()
        {
            InitializeComponent();
            UpdateUI();
            StartTimer();
        }

        async void BackBtnTapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void UpdateUI()
        {
            var abductionState = AbductionStates.GetAbductionString(AbductionStates.GetStateFromAbduction(alien.Abduction));
            if (abductionStateLabel.Text != abductionState)
            {
                abductionStateLabel.Text = abductionState;
            }

            abductionGauge(Convert.ToDouble(alien.Abduction) / 100);
        }

        async private void abductionGauge(double i)
        {
            await abductionBar.ProgressTo(i, 100, Easing.Linear);
        }

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
    }
}