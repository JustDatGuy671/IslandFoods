using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenIsland_Food;
using System.Collections.Generic;

namespace KitchenIslandFoodLib.Customs
{
    class LocoMocoPatty : CustomDish
    {
        public override string UniqueNameID => "LocoMocoPattyCard";
        public override DishType Type => DishType.Main;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            IslandFoods.LocoMocoDish
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = IslandFoods.BurgerPatty,
                MenuItem = IslandFoods.LocoMocoPlated
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            IslandFoods.BurgerPattiesRaw
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            IslandFoods.Cook,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add a burger patty to the LocoMoco plate." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Patty - LocoMoco", "Customers can request burger patty while eating LocoMoco!", "I knew the LocoMoco was missing something:D") )
        };
    }
}