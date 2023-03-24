using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenIsland_Food;
using System.Collections.Generic;

namespace KitchenIslandFoodLib.Side
{
    class KetchupAsACard : CustomDish
    {
        public override string UniqueNameID => "Spam Ketchup Card";
        public override DishType Type => DishType.Extra;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            IslandFoods.SpamDish
        };
        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = IslandFoods.Ketchup,
                MenuItem = IslandFoods.SpamPlated
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
           IslandFoods.Ketchup,
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Customers can request ketchup while eating a spam dish!" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Spam with Ketchup", "Customers can request ketchup while eating a spam dish!", "Needs Ketchup") )
        };
    }
}
