/*using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;
using Kitchen;
using KitchenLib.Colorblind;
using Unity.Entities;

namespace KitchenIslandFoodLib.Side
{
    class MacSaladUnchopped : CustomItemGroup<MacSaladPotItemGroupView>
    {
        public override string UniqueNameID => "Mac Salad Unchopped";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("MacSaladUnchopped");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override ItemValue ItemValue => ItemValue.None;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.Macaroni,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.Mayo,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.ChoppedBoiledEgg,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.ChoppedCarrots,
                }
            },
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 4f,
                Process = IslandFoods.Cook,
                Result = IslandFoods.MacSalad
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
        

            Prefab.GetComponent<MacSaladPotItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }

    public class MacSaladPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {

            };
        }
    }
}*/
