using System;
using System.Collections.Generic;
using System.Text;

namespace MyET.Objects
{

    public enum AlienState
    {
        happy,
        normal,
        sad
    }

    class AlienStates
    {
        public static string GetAlienString(AlienState alienState)
        {
            switch(alienState)
            {
                case AlienState.happy:
                    return "happy";
                case AlienState.normal:
                    return "normal";
                case AlienState.sad:
                    return "sad";
                default:
                    return "unborn";
            }
        }

        public static AlienState GetAlienState(string alienState)
        {
            switch(alienState)
            {
                case "happy":
                    return AlienState.happy;
                case "normal":
                    return AlienState.normal;
                case "sad":
                    return AlienState.sad;
                case "starving":
                default:
                    return AlienState.normal;
            }
        }
    }

}
