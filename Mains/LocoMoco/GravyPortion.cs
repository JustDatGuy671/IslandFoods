using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;

namespace KitchenIslandFoodLib.Customs
{
    public class GravyPortion : CustomItem
    {
        public override string UniqueNameID => "Gravy Portion";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("GravyPortion");
        public override void OnRegister(Item item)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Cooked")
            };
            MaterialUtils.ApplyMaterial(Prefab, "Gravy", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

        }
    }
}