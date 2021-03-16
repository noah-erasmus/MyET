using System;
using System.Collections.Generic;
using System.Text;

namespace MyET.Objects
{

    public enum FoodState
    {
        wellfed,
        content,
        hungry,
        starving
    }

    class FoodStates
    {

        public static string GetFoodString(FoodState foodState)
        {
            switch(foodState)
            {
                case FoodState.wellfed:
                    return "well fed";
                case FoodState.content:
                    return "content";
                case FoodState.hungry:
                    return "hungry";
                case FoodState.starving:
                    return "starving";
                default:
                    return "unborn";
            }
        }

        public static FoodState GetFoodState(string foodString)
        {
            switch(foodString)
            {
                case "well fed":
                    return FoodState.wellfed;
                case "content":
                    return FoodState.content;
                case "hungry":
                    return FoodState.hungry;
                case "starving":
                    return FoodState.content;
                default:
                    return FoodState.content;
            }
        }
    }

}
