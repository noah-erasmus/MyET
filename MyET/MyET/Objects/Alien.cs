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

        const string HungerStateKey = "hungerState";
        const string HungerKey = "hunger";

        const string SocialStateKey = "socialState";
        const string SocialKey = "social";

        const string AbductionStateKey = "abductionState";
        const string AbductionKey = "abduction";

        const string ColourStateKey = "colourState";
        const string ColourKey = "colour";

        public HungerState CurrentHungerState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(HungerStateKey))
                {
                    return HungerStates.GetHungerState((string)App.Current.Properties[HungerStateKey]);
                }
                else
                {
                    return HungerState.content;
                }
            }

            set
            {
                App.Current.Properties[HungerKey] = HungerStates.GetHungerString(value);
            }
        }

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

        public string AlienColour
        {
            get
            {
                if (App.Current.Properties.ContainsKey(ColourStateKey))
                {
                    return (string)App.Current.Properties[ColourStateKey];
                }
                else
                {
                    return "green";
                }

            }
            set
            {
                App.Current.Properties[ColourStateKey] = value;
            }
        }

        public Alien()
        {

        }

        public int Hunger
        {
            get
            {
                if (App.Current.Properties.ContainsKey(HungerKey))
                {
                    return (int)App.Current.Properties[HungerKey];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                App.Current.Properties[HungerKey] = value;
            }
        }

        public int Social
        {
            get
            {
                if (App.Current.Properties.ContainsKey(SocialKey))
                {
                    return (int)App.Current.Properties[SocialKey];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                App.Current.Properties[SocialKey] = value;
            }
        }

        public int Abduction
        {
            get
            {
                if (App.Current.Properties.ContainsKey(AbductionKey))
                {
                    return (int)App.Current.Properties[AbductionKey];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                App.Current.Properties[AbductionKey] = value;
            }
        }

        public void Birth()
        {
            Hunger = 50;
            Social = 50;
            Abduction = 50;
        }

        public void Feed()
        {
            if (Hunger < 91)
            {
                Hunger += 10;
            }
            else
            {
                Hunger = 100;
            }
        }

        public void Chat()
        {
            if (Social < 91)
            {
                Social += 10;
            }
            else
            {
                Social = 100;
            }
        }

        public void Abduct()
        {
            if (Abduction < 91)
            {
                Abduction += 10;
            }
            else
            {
                Abduction = 100;
            }
        }

        public void Starve()
        {
            if(Hunger > 0)
            {
                Hunger -= 2;
            }
            else
            {
                Hunger = 0;
            }
        }

        public void Isolate()
        {
            if (Social > 0)
            {
                Social -= 2;
            }
            else
            {
                Social = 0;
            }
        }

        public void Escape()
        {
            if (Abduction > 0)
            {
                Abduction -= 2;
            }
            else
            {
                Abduction = 0;
            }
        }
    }
}
