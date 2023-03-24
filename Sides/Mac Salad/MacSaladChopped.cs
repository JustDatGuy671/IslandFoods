/*using KitchenData;
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
    public class MacSaladChoppedItemView : ObjectsSplittableView
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

    public class MacSaladChopped : CustomItem
    {
        public override string UniqueNameID => "Mac Salad Chopped";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("Mac Salad Chopped");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 0.75f;
        public override int SplitCount => 4;
        public override Item SplitSubItem => IslandFoods.MacSaladPortion;
        public override List<Item> SplitDepletedItems => new() { IslandFoods.SoupDepleted };
        public override bool PreventExplicitSplit => false;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Cylinder", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cylinder.003", materials);



            if (!Prefab.HasComponent<GravyPotCookedItemView>())
            {
                var view = Prefab.AddComponent<GravyPotCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}*/