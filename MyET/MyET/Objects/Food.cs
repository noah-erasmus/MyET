using System;
using System.Collections.Generic;
using System.Text;

namespace MyET.Objects
{
    public class Food
    {

        const string foodStateKey = "foodState";
        const string alienXpKey = "alienXp";

        public FoodState CurrentFoodState
        {
            get
            {
                if (App.Current.Properties.ContainsKey(foodStateKey))
                {
                    return FoodStates.GetFoodState((string)App.Current.Properties[foodStateKey]);
                }
                else
                {
                    return FoodState.content;
                }
            }

            set
            {
                
            }
        }

        public Food()
        {

        }

        public void giveFood()
        {
            Xp = Xp + 500;
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
    }
}
