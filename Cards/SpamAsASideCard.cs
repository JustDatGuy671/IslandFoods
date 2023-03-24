using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;

namespace KitchenIslandFoodLib.Side
{
    class SpamAsASideCard : CustomDish
    {
        public override string UniqueNameID => "Spam Side Card";
        public override DishType Type => DishType.Side;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>()
        {
            new Dish.MenuItem()
            {
                Item = IslandFoods.ExtraSpamPlated,
                Phase = MenuPhase.Side,
                Weight = 1
            },
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
           IslandFoods.SpamCan,
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            IslandFoods.Chop,
            IslandFoods.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Chop, and cook Spam. Combine two spam slices together first! Then serve with the plated main." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Extra Spam", "Adds Spam as a side", "This is too expensive man :(") )
        };
    }
}