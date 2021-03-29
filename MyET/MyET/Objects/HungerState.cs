using System;
using System.Collections.Generic;
using System.Text;

namespace MyET.Objects
{
    public enum HungerState
    {
        full,
        content,
        hungry,
        starving
    }

    class HungerStates
    {
        public static string GetHungerString(HungerState hungerState)
        {
            switch (hungerState)
            {
                case HungerState.full:
                    return "full";
                case HungerState.content:
                    return "content";
                case HungerState.hungry:
                    return "hungry";
                case HungerState.starving:
                    return "starving";
                default:
                    return "content";
            }
        }

        public static HungerState GetHungerState(string hungerState)
        {
            switch (hungerState)
            {
                case "full":
                    return HungerState.full;
                case "content":
                    return HungerState.content;
                case "hungry":
                    return HungerState.hungry;
                case "starving":
                    return HungerState.starving;
                default:
                    return HungerState.starving;
            }
        }

        public static HungerState GetStateFromHunger(int HungerValue)
        {
            if(HungerValue < 20)
            {
                return HungerState.starving;
            }else if(HungerValue < 40)
            {
                return HungerState.hungry;
            }
            else if (HungerValue < 70)
            {
                return HungerState.content;
            }else if(HungerValue > 70)
            {
                return HungerState.full;
            }
            else
            {
                return HungerState.starving;
            }

        }

        public HungerStates()
        {

        }
    }
}
