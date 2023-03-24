using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;
using Kitchen;

// Namespace should have "Kitchen" in the beginning
namespace KitchenIslandFoodLib.Customs
{
    public class GravyPotCookedItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObject = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObject.SetValue(this, new List<GameObject>()
            {
                prefab.GetChild("GravyPortion1"),
                prefab.GetChild("GravyPortion2"),
                prefab.GetChild("GravyPortion3"),
                prefab.GetChild("GravyPortion4"),
            });
        }
    }

    public class GravyPotCooked : CustomItem
    {
        public override string UniqueNameID => "Gravy Pot Cooked";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("GravyPotCooked");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 0.75f;
        public override int SplitCount => 6;
        public override Item SplitSubItem => IslandFoods.GravyPortion;
        public override List<Item> SplitDepletedItems => new() { IslandFoods.SoupDepleted };
        public override Item DisposesTo => IslandFoods.Pot;
        public override bool PreventExplicitSplit => false;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override void OnRegister(Item item)
        {
            var materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "GravyPortion1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GravyPortion2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GravyPortion3", materials);
            MaterialUtils.ApplyMaterial(Prefab, "GravyPortion4", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Cylinder", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cylinder.003", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Onion");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);


            if (!Prefab.HasComponent<GravyPotCookedItemView>())
            {
                var view = Prefab.AddComponent<GravyPotCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}