using KitchenData;
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
    class GravyPotUncooked : CustomItemGroup<GravyPotItemGroupView>
    {
        public override string UniqueNameID => "Gravy Pot Uncooked";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("UncookedGravyPot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override ItemValue ItemValue => ItemValue.None;
        public override Item DisposesTo => IslandFoods.Pot;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.BrothCookedOnion,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.SplitMilk,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    IslandFoods.Flour,
                }
            }

        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 4f,
                Process = IslandFoods.Cook,
                Result = IslandFoods.CookedGravyPot
            }
        };
        public override void OnRegister(ItemGroup itemgroup)
        {
            var materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Soup");
            MaterialUtils.ApplyMaterial(Prefab, "Broth", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Flour");
            MaterialUtils.ApplyMaterial(Prefab, "Flour", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plastic - White");
            MaterialUtils.ApplyMaterial(Prefab, "Milk", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Cylinder", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Cylinder.003", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Onion");
            MaterialUtils.ApplyMaterial(Prefab, "Onion", materials);

            Prefab.GetComponent<GravyPotItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }

    public class GravyPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Flour"),
                    Item = IslandFoods.Flour
                },
                new()
                {
                    Item = IslandFoods.BrothCookedOnion,
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Broth"),
                        GameObjectUtils.GetChildObject(prefab, "Cylinder"),
                        GameObjectUtils.GetChildObject(prefab, "Cylinder.003"),
                        GameObjectUtils.GetChildObject(prefab, "Onion")
                    },
                    DrawAll =true
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Milk"),
                    Item = IslandFoods.SplitMilk
                },
            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = IslandFoods.BrothCookedOnion,
                    Text = "Bth"
                },
                new()
                {
                    Item = IslandFoods.Flour,
                    Text = "F"
                },
                new()
                {
                   Item = IslandFoods.SplitMilk,
                   Text = "M"
                },
            };
        }
    }
}
