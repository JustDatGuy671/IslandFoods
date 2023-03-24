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
    public class LocoMocoPlated : CustomItemGroup<LocoMocoItemGroupView>
    {
        public override string UniqueNameID => "LocoMoco Plated";
        public override GameObject Prefab => IslandFoods.Bundle.LoadAsset<GameObject>("LocoMocoPlated");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.Large;
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
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    IslandFoods.CookedRice,
                    IslandFoods.GravyPortion,
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    IslandFoods.BurgerPatty,
                    IslandFoods.CookedEgg
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
            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "Gravy", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Turkey - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "BurgerPatty", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Egg - White");
            MaterialUtils.ApplyMaterial(Prefab, "EggWhites", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Egg - Yolk");
            MaterialUtils.ApplyMaterial(Prefab, "EggYolk", materials);

            Prefab.GetComponent<LocoMocoItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }

    public class LocoMocoItemGroupView : ItemGroupView
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
                    DrawAll = true
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Gravy"),
                    Item = IslandFoods.GravyPortion
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "BurgerPatty"),
                    Item = IslandFoods.BurgerPatty
                },
                new()
                {
                    Item = IslandFoods.CookedEgg,
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "EggYolk"),
                        GameObjectUtils.GetChildObject(prefab,"EggWhites"),
                    },
                    DrawAll = true
                },
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
                   Item = IslandFoods.GravyPortion,
                   Text = "Gvy"
                },
                new()
                {
                   Item = IslandFoods.BurgerPatty,
                   Text = "P"
                },
                new()
                {
                   Item = IslandFoods.CookedEgg,
                   Text = "E"
                }
            };
        }
    }
}
