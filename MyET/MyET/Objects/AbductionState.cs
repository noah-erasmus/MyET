using System;
using System.Collections.Generic;
using System.Text;

namespace MyET.Objects
{
    public enum AbductionState
    {
        satisfied,
        acceptable,
        unsatisfied
    }

    class AbductionStates
    {
        public static string GetAbductionString(AbductionState abductionState)
        {
            switch (abductionState)
            {
                case AbductionState.satisfied:
                    return "satisfied";
                case AbductionState.acceptable:
                    return "acceptable";
                case AbductionState.unsatisfied:
                    return "unsatisfied";
                default:
                    return "unsatisfied";
            }
        }

        public static AbductionState GetAbductionState(string abductionState)
        {
            switch (abductionState)
            {
                case "satisfied":
                    return AbductionState.satisfied;
                case "acceptable":
                    return AbductionState.acceptable;
                case "unsatisfied":
                    return AbductionState.unsatisfied;
                default:
                    return AbductionState.unsatisfied;
            }
        }

        public static AbductionState GetStateFromAbduction(int AbductionValue)
        {
            if (AbductionValue < 33)
            {
                return AbductionState.unsatisfied;
            }
            else if (AbductionValue < 66)
            {
                return AbductionState.acceptable;
            }
            else if (AbductionValue > 66)
            {
                return AbductionState.satisfied;
            }
            else
            {
                return AbductionState.unsatisfied;
            }

        }

        public AbductionStates()
        {

        }
    }
}
