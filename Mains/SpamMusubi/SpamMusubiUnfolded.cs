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
    class SpamMusubiUnfolded : CustomItemGroup<SpamMusubiItemGroupView>
    {
        public override string UniqueNameID => "Spam Musubi Unfolded";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("SpamMusubiUnfolded");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    IslandFoods.SpamCookedPortions,
                    IslandFoods.CookedSeaweed,
                    IslandFoods.CookedRice,
                }
            }

        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 0.8f,
                Process = IslandFoods.Knead,
                Result = IslandFoods.SpamMusubi
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
            MaterialUtils.ApplyMaterial(Prefab, "Seaweed (1)", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Rice - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "RiceMound", materials);
            MaterialUtils.ApplyMaterial(Prefab, "RiceBlocks", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Metal Very Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);

            Prefab.GetComponent<SpamMusubiItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }

    public class SpamMusubiItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "SpamCookedPortion"),
                    Item = IslandFoods.SpamCookedPortions
                },
                new()
                {
                    Item = IslandFoods.CookedRice,
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "RiceMound"), 
                        GameObjectUtils.GetChildObject(prefab, "RiceBlocks"),
                        GameObjectUtils.GetChildObject(prefab, "Bowl"),
                    },
                    DrawAll =true
                },


                new()
                {
                    Item = IslandFoods.CookedSeaweed,
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Seaweed"),
                        GameObjectUtils.GetChildObject(prefab, "Seaweed (1)"),
                    }
                },
            };
            ComponentLabels = new()
            {
                new()
                {
                    Item = IslandFoods.SpamCookedPortions,
                    Text = "Sp"
                },
                new()
                {
                    Item = IslandFoods.CookedRice,
                    Text = "R"
                },
                new()
                {
                   Item = IslandFoods.CookedSeaweed,
                   Text = "S"
                }
            };
        }
    }
}