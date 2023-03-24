using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;
using Kitchen;
using KitchenLib.Colorblind;

namespace KitchenIslandFoodLib.Customs
{
    public class SpamPlated : CustomItemGroup<SpamItemGroupView>
    {
        public override string UniqueNameID => "SpamPlated";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("SpamPlated");
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
                    IslandFoods.Plate
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.CookedRice
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.SpamCookedPortions,
                    IslandFoods.SpamCookedPortions
                }
            }
        };
        public override void OnRegister(ItemGroup itemgroup)
        {
            var materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Plane", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Plane.001", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Plate", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Rice - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "RiceMound", materials);
            MaterialUtils.ApplyMaterial(Prefab, "RiceBlocks", materials);

            materials = new Material[1];
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
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plate"),
                    Item = IslandFoods.Plate
                },
                new()
                {
                    Item = IslandFoods.CookedRice,
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "RiceMound"),
                        GameObjectUtils.GetChildObject(prefab,"RiceBlocks"),
                    },
                    DrawAll= true
                },
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
                    Item = IslandFoods.Plate,
                    Text = ""
                },
                new()
                {
                    Item = IslandFoods.CookedRice,
                    Text = "R"
                },
                new()
                {
                   Item = IslandFoods.SpamCookedPortions,
                   Text = "Sp"
                }
            };
        }
    }
}