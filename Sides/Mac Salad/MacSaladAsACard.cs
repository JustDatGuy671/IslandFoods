/*using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;

namespace KitchenIslandFoodLib.Side
{
    class MacSaladAsASideCard : CustomDish
    {
        public override string UniqueNameID => "Mac Salad Card";
        public override DishType Type => DishType.Side;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>()
        {
            new Dish.MenuItem()
            {
                Item = IslandFoods.MacSalad,
                Phase = MenuPhase.Side,
                Weight = 1
            },
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
           IslandFoods.Macaroni,
           IslandFoods.Carrots,
           IslandFoods.Oil,
           IslandFoods.Egg,
           
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            IslandFoods.Chop,
            IslandFoods.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cook Macaroni, chop carrots, and boil an egg. Combine all ingredients! Then serve with the plated main." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Mac Salad", "Adds Mac Salad as a side", "Not my favorite, but it'll do.") )
        };
    }
}*/ 