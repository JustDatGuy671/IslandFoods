using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;
using Kitchen;
using IngredientLib.Util;
// Namespace should have "Kitchen" in the beginning
namespace KitchenIslandFoodLib.Customs
{
    public class SpamMusubiPlated : CustomItemGroup
    {
        public override string UniqueNameID => "SpamMusubiPlated";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("SpamMusubiPlated");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item DisposesTo => IslandFoods.Plate;
        public override Item DirtiesTo => IslandFoods.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    IslandFoods.Plate,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    IslandFoods.SpamMusubi,
                }
            }
        };
        
        public override void OnRegister(ItemGroup itemgroup)
        {
            var materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Turkey - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "SpamCookedPortion", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - Very Dark Green");
            MaterialUtils.ApplyMaterial(Prefab, "Seaweed", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Rice - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Rice", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);
        }
    }
}