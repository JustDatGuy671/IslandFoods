using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using KitchenIsland_Food;
using System.Collections.Generic;

namespace KitchenIslandFoodLib.Customs
{   
    public class SpamRawPortions : CustomItem
    {
        public override string UniqueNameID
        {
            get
            {
                return "Spam Raw Portions";
            }
        }
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = IslandFoods.Cook,
                Result = IslandFoods.SpamCookedPortions
            }
        };
        public override GameObject Prefab
        {
            get
            {
                return IslandFoods.Bundle.LoadAsset<GameObject>("SpamRawPortions");
            }
        }
        public override void OnRegister(Item item)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Meat Piece Raw")
            };
            MaterialUtils.ApplyMaterial(Prefab, "SpamRawPortion", materials);
        }
    }
    public class SpamCookedPortions : CustomItem
    {
        public override string UniqueNameID
        {
            get
            {
                return "Spam Cooked Portion";
            }
        }
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 3,
                Process = IslandFoods.Cook,
                IsBad = true,
                Result = IslandFoods.Burnt
            }
        };
        public override GameObject Prefab
        {
            get
            {
                return IslandFoods.Bundle.LoadAsset<GameObject>("SpamPortions");
            }
        }
        public override void OnRegister(Item item)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Turkey - Cooked")
            };
            MaterialUtils.ApplyMaterial(Prefab, "SpamCookedPortion", materials);
        }
    }

    
}
