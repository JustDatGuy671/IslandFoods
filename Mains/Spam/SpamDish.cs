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
    class SpamDish : CustomDish
    {
        public override string UniqueNameID => "Spam Dish";
        public override DishType Type => DishType.Base;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.None;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsAvailableAsLobbyOption => true;
        public override GameObject DisplayPrefab => IslandFoods.Bundle.LoadAsset<GameObject>("SpamPlated");
        public override GameObject IconPrefab => IslandFoods.Bundle.LoadAsset<GameObject>("SpamPlated");


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
                Item = IslandFoods.SpamPlated,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            IslandFoods.SpamCan,
            IslandFoods.Rice,
            IslandFoods.Plate,
            IslandFoods.Wok
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            IslandFoods.Cook,
            IslandFoods.Chop,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cut can open, portion the spam into slices. Cook slices. Then cook rice inside the wok. Combine the rice with a plate, then the slices of spam." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Spam", "Adds Spam and Rice as a Main", "Spam and Rice?! A Classic!") )
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
            materials[0] = MaterialUtils.GetExistingMaterial("Turkey - Cooked");
            MaterialUtils.ApplyMaterial(DisplayPrefab, "SpamCookedPortion", materials);
            MaterialUtils.ApplyMaterial(DisplayPrefab, "SpamCookedPortion.001", materials);
        }

    }
}