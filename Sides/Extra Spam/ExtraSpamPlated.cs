using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;
using Kitchen;
using KitchenIslandFoodLib.Customs;
using KitchenLib.Colorblind;

namespace KitchenIslandFoodLib.Side
{
    class ExtraSpamPlated : CustomItemGroup<SpamItemGroupView>
    {
        public override string UniqueNameID => "Extra Spam Plated";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("ExtraSpamPlated");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideMedium;
        public override bool IsMergeableSide => true;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    IslandFoods.SpamCookedPortions,
                    IslandFoods.SpamCookedPortions,
                }
            },
        };

        public override void OnRegister(ItemGroup itemgroup)
        {
            var materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Turkey - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "SpamCookedPortion", materials);
            MaterialUtils.ApplyMaterial(Prefab, "SpamCookedPortion.001", materials);

            Prefab.GetComponent<SpamItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }

    public class SpamItemGroupView : ItemGroupView
    { 
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
            new()
            {
                Item = IslandFoods.SpamCookedPortions,
                Objects = new List<GameObject>()
                {
                    GameObjectUtils.GetChildObject(prefab, "SpamCookedPortion"),
                    GameObjectUtils.GetChildObject(prefab,"SpamCookedPortion.001"),
                }
            }
            };
            ComponentLabels = new()
            {
                new()
                {
                   Item = IslandFoods.SpamCookedPortions,
                   Text = "Sp"
                }
            };
        }

    }
}