using System;
using System.Collections.Generic;
using System.Text;

namespace MyET.Objects
{
    public class Alien
    {
        const string alienStateKey = "alienState";
        const string alienXpKey = "alienXp";
        const string alienNameKey = "alienName";

        public AlienState CurrentAlienState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(alienStateKey))
                {
                    return AlienStates.GetAlienState((string)App.Current.Properties[alienStateKey]);
                }
                else
                {
                    return AlienState.normal;
                }
            }

            set
            {
                App.Current.Properties[alienStateKey] = AlienStates.GetAlienString(value);
            }
        }


        public int Xp
        {
            get
            {
                if(App.Current.Properties.ContainsKey(alienXpKey))
                {
                    Console.WriteLine((int)App.Current.Properties[alienXpKey]);
                    return (int)App.Current.Properties[alienXpKey];
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                App.Current.Properties[alienXpKey] = value;
            }
        }

        public string AlienName
        {
            get
            {
                if (App.Current.Properties.ContainsKey(alienNameKey))
                {
                    return (string)App.Current.Properties[alienNameKey];
                }
                else
                {
                    return "No Name";
                }

            }
            set
            {
                App.Current.Properties[alienNameKey] = value;
            }
        }

        public Alien()
        {

        }

        public void giveFood()
        {
            CurrentAlienState = AlienState.happy;
            Xp = Xp + 500;
        }
    }
}
