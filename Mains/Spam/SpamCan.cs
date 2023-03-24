using KitchenData;
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
    public class SpamCan : CustomItem
    {
        public override string UniqueNameID
        {
            get
            {
                return "Spam Can";
            }
        }
        public override GameObject Prefab
        {
            get
            {
                return IslandFoods.Bundle.LoadAsset<GameObject>("SpamCan");
            }
        }
        public override Appliance DedicatedProvider
        {
            get
            {
                return (Appliance)GDOUtils.GetCustomGameDataObject<SpamProvider>().GameDataObject;
            }
        }
        public override List<ItemGroup.ItemProcess> Processes => new List<ItemGroup.ItemProcess>()
        {
            new ItemGroup.ItemProcess
            {
                Duration = 2,
                Process = IslandFoods.Chop,
                Result = IslandFoods.SpamRaw
            }
        };

        public override void OnRegister(Item item)
        {
            var materials = new Material[3];

            materials[0] = MaterialUtils.GetExistingMaterial("Paint - Gold");
            materials[1] = MaterialUtils.GetExistingMaterial("Book Cover - Blue");
            materials[2] = MaterialUtils.GetExistingMaterial("Plastic - Shiny Gold");

            MaterialUtils.ApplyMaterial(Prefab, "Spam Can", materials);
        }
    }
}