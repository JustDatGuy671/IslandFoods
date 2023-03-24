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
    public class SpamRawItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObject = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObject.SetValue(this, new List<GameObject>()
            {
                //prefab.GetChild("SpamSlice1"),
                prefab.GetChild("SpamSlice2"),
                prefab.GetChild("SpamSlice3"),
                prefab.GetChild("SpamSlice4"),
                prefab.GetChild("SpamSlice5"),
                prefab.GetChild("SpamSlice6"),
                prefab.GetChild("SpamSlice7"),
                prefab.GetChild("SpamSlice8")
            });
        }
    }

    public class SpamRaw : CustomItem
    {
        public override string UniqueNameID
        {
            get
            {
                return "SpamRaw";
            }
        }

        public override GameObject Prefab
        {
            get
            {
                return IslandFoods.Bundle.LoadAsset<GameObject>("SpamRaw");
            }
        }

        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 0.75f;
        public override int SplitCount => 7;
        public override Item SplitSubItem => IslandFoods.SpamRawPortions;
        public override List<Item> SplitDepletedItems => new() { IslandFoods.SpamRawPortions };
        public override bool PreventExplicitSplit => false;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override void OnRegister(Item item)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Meat Piece Raw")
            };
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice2", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice3", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice4", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice5", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice6", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice7", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamSlice8", materials);

            if (!Prefab.HasComponent<SpamRawItemView>())
            {
                var view = Prefab.AddComponent<SpamRawItemView>();
                view.Setup(Prefab);
            }
        }
    }
}