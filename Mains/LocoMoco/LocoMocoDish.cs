using IngredientLib;
using KitchenData;
using KitchenIsland_Food;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Reflection;
using Unity.Entities;
using UnityEngine;

namespace KitchenIslandFoodLib.Customs
{
    class LocoMocoDish : CustomDish
    {
        public override string UniqueNameID => "LocoMoco";
        public override DishType Type => DishType.Base;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsAvailableAsLobbyOption => true;
        public override GameObject DisplayPrefab => IslandFoods.Bundle.LoadAsset<GameObject>("LocoMocoPlated");
        public override GameObject IconPrefab => IslandFoods.Bundle.LoadAsset<GameObject>("LocoMocoPlated");


        public override List<string> StartingNameSet => new()
        {
            "L&L Hawaiian BBQ",
            "C&H Hawaiian Grill",
            "Aloha Talofa"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = IslandFoods.LocoMocoPlated,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            IslandFoods.Milk,
            IslandFoods.Onion,
            IslandFoods.Flour,
            IslandFoods.Rice,
            IslandFoods.Wok,
            IslandFoods.Pot,
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            IslandFoods.Cook,
            IslandFoods.Chop,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine large pot, water, and onion to make broth. Then combine flour and milk to the broth to make the gravy. Cook rice inside wok. Once done, combine rice with a plate, then gravy! " }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("LocoMoco", "Adds LocoMoco as a Main", "Who doesn't want a locomoco?") )
        };
        public override void OnRegister(Dish dish)
        {
            var materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Plane", materials);
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Plane.001", materials);
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Plate", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Rice - Cooked");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "RiceMound", materials);
            MaterialUtils.ApplyMaterial(DisplayPrefab, "RiceBlocks", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Soup - Meat");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "Gravy", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Turkey - Cooked");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "BurgerPatty", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Egg - White");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "EggWhites", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Egg - Yolk");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "EggYolk", materials);
        }

    }
}
