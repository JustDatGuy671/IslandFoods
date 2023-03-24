using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;

namespace KitchenIslandFoodLib.Side
{
    class SpamMusubiDish : CustomDish
    {
        public override string UniqueNameID => "Spam Musubi Dish";
        public override DishType Type => DishType.Main;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            IslandFoods.SpamDish
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>()
        {
            new Dish.MenuItem()
            {
                Item = IslandFoods.SpamMusubiPlated,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
           IslandFoods.SpamCan,
           IslandFoods.Seaweed,
           IslandFoods.Rice,
           IslandFoods.Wok,
           IslandFoods.Plate
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            IslandFoods.Chop,
            IslandFoods.Cook,
            IslandFoods.Knead
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine cooked rice, cooked spam, and cooked seaweed, and fold! Then combine with a plate!" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Spam Musubi", "Adds Spam Musubi as a Main", "Everyone loves spam musubi :D") )
        };
    }
}