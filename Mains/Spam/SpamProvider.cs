using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System.Reflection;
using UnityEngine;
using System.Linq;
using KitchenData;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenIsland_Food;
using KitchenLib.Customs;
using System.Collections.Generic;
// Namespace should have "Kitchen" in the beginning
namespace KitchenIslandFoodLib.Customs
{
    public class SpamProvider : CustomAppliance
    {
        public override string UniqueNameID
        {
            get
            {
                return "SpamProvider";
            }
        }
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateApplianceInfo("Spam Crates", "Provides Spam Cans", new(), new()))
        };
        public override GameObject Prefab
        {
            get
            {
                return IslandFoods.Bundle.LoadAsset<GameObject>("SpamProvider");
            }
        }

        public override List<IApplianceProperty> Properties
        {
            get
            {
                return new List<IApplianceProperty>
                {
                    KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<SpamCan>().GameDataObject.ID)
                };
            }
        }
        public override void OnRegister(Appliance appliance)
        {
            var materials = new Material[3];

            materials[0] = MaterialUtils.GetExistingMaterial("Paint - Gold");
            materials[1] = MaterialUtils.GetExistingMaterial("Book Cover - Blue");
            materials[2] = MaterialUtils.GetExistingMaterial("Plastic - Shiny Gold");
            MaterialUtils.ApplyMaterial(Prefab, "Spam Can", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Spam Can.001", materials);

            materials = new Material[1];
            materials[0] = MaterialUtils.GetExistingMaterial("Wood - Default");
            MaterialUtils.ApplyMaterial(Prefab, "Crate", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Crate.001", materials);
        }
    }
}