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
    public class SpamMusubi : CustomItem
    {
        public override string UniqueNameID => "Spam Musubi";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("SpamMusubi");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;

        public override void OnRegister(Item item)
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
        }
    }
}