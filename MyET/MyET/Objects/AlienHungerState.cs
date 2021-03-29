using System;
using System.Collections.Generic;
using System.Text;

namespace MyET.Objects
{
    public enum AlienHungerState
    {
        full,
        content,
        hungry,
        starving
    }

    class AlienHungerStates
    {
        public static string GetAlienHungerState(AlienHungerState HungerState)
        {
            switch (HungerState)
            {
                case AlienHungerState.full:
                    return "full";
                case AlienHungerState.content:
                    return "content";
                case AlienHungerState.hungry:
                    return "hungry";
                case AlienHungerState.starving:
                    return "starving";
                default:
                    return "content";
            }
        }

        public static AlienHungerState GetAlienHungerState(string HungerState)
        {
            switch (HungerState)
            {
                case "full":
                    return AlienHungerState.full;
                case "content":
                    return AlienHungerState.content;
                case "hungry":
                    return AlienHungerState.hungry;
                default:
                    return AlienHungerState.starving;
            }
        }

        public static AlienHungerState GetStateFromHunger(int HungerValue)
        {
            if(HungerValue < 20)
            {
                return AlienHungerState.starving;
            }else if(HungerValue < 40)
            {
                return AlienHungerState.hungry;
            }
            else if (HungerValue < 70)
            {
                return AlienHungerState.content;
            }else
            {
                return AlienHungerState.full;
            }
        }

        public AlienHungerStates()
        {

        }
    }
}
