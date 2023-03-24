using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System.Reflection;
using UnityEngine;
using System.Linq;
using KitchenData;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenLib.Customs;
using Kitchen;
using IngredientLib;
using KitchenIslandFoodLib.Customs;
using KitchenIslandFoodLib.Side;

// Namespace should have "Kitchen" in the beginning
namespace KitchenIsland_Food
{
    public class IslandFoods : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "JustDatGuy.Plateup.IslandFood";
        public const string MOD_NAME = "Island Food";
        public const string MOD_VERSION = "0.1.3";
        public const string MOD_AUTHOR = "JustDatGuy671";
        public const string MOD_GAMEVERSION = ">=1.1.4";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        // Boolean constant whose value depends on whether you built with DEBUG or RELEASE mode, useful for testing
#if DEBUG
        public const bool DEBUG_MODE = true;
#else
        public const bool DEBUG_MODE = false;
#endif

        public static AssetBundle Bundle;

        //Processes 
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Knead => GetExistingGDO<Process>(ProcessReferences.Knead);
        // Vanilla Items
        internal static Item Burnt => GetExistingGDO<Item>(ItemReferences.BurnedFood);
        internal static Item Plate => GetExistingGDO<Item>(ItemReferences.Plate);
        internal static Item DirtyPlate => GetExistingGDO<Item>(ItemReferences.PlateDirty);
        internal static Item Rice => GetExistingGDO<Item>(ItemReferences.Rice);
        internal static Item CookedRice => GetExistingGDO<Item>(ItemReferences.RiceContainerCooked);
        internal static Item Wok => GetExistingGDO<Item>(ItemReferences.Wok);
        internal static Item Seaweed => GetExistingGDO<Item>(ItemReferences.Seaweed);
        internal static Item CookedSeaweed => GetExistingGDO<Item>(ItemReferences.SeaweedCooked);
        internal static Item SoupDepleted => GetExistingGDO<Item>(ItemReferences.SoupDepleted);
        internal static Item Onion => GetExistingGDO<Item>(ItemReferences.Onion);
        internal static Item Pot => GetExistingGDO<Item>(ItemReferences.Pot);
        internal static Item BurgerPatty => GetExistingGDO<Item>(ItemReferences.BurgerPattyCooked);
        internal static Item Flour => GetExistingGDO<Item>(ItemReferences.Flour);
        internal static Item BrothCookedOnion => GetExistingGDO<Item>(ItemReferences.BrothCookedOnion);
        internal static Item CookedEgg => GetExistingGDO<Item>(ItemReferences.EggCooked);
        internal static Item Egg => GetExistingGDO<Item>(ItemReferences.Egg);
        internal static Item BurgerPattiesRaw => GetExistingGDO<Item>(ItemReferences.BurgerPattyRaw);
        //Ingredient Lib
        public static Item Milk => Find<Item>(References.GetIngredient("milk"));
        public static Item SplitMilk => Find<Item>(IngredientLib.References.GetSplitIngredient("milk"));

        // Vanilla Item Ketchup as an Extra
        internal static Item Ketchup => GetExistingGDO<Item>(ItemReferences.CondimentKetchup);
        internal static Dish KetchupAsASideCard => GetModdedGDO<Dish, KetchupAsACard>();

        //Modded Item Spam Main Dish
        internal static Item SpamRaw => GetModdedGDO<Item, SpamRaw>();
        internal static Item SpamRawPortions => GetModdedGDO<Item, SpamRawPortions>();
        internal static Item SpamCookedPortions => GetModdedGDO<Item, SpamCookedPortions>();
        internal static ItemGroup SpamPlated => GetModdedGDO<ItemGroup, SpamPlated>();
        internal static Appliance SpamProvider => GetModdedGDO<Appliance, SpamProvider>();
        internal static Item SpamCan => GetModdedGDO<Item, SpamCan>();
        internal static Dish SpamDish => GetModdedGDO<Dish, SpamDish>();

        //Modded Item Spam As a Side
        internal static Dish SpamAsASide => GetModdedGDO<Dish, SpamAsASideCard>();
        internal static ItemGroup ExtraSpamPlated => GetModdedGDO<ItemGroup, ExtraSpamPlated>();

        //Modded Spam Musubi Dish
        internal static ItemGroup SpamMusubiUnfolded => GetModdedGDO<ItemGroup, SpamMusubiUnfolded>();
        internal static Dish SpamMusubiDish => GetModdedGDO<Dish, SpamMusubiDish>();
        internal static Item SpamMusubi => GetModdedGDO<Item, SpamMusubi>();
        internal static ItemGroup SpamMusubiPlated => GetModdedGDO<ItemGroup, SpamMusubiPlated>();
        //Modded Item LocoMoco Dish
        internal static ItemGroup UncookedGravyPot => GetModdedGDO<ItemGroup, GravyPotUncooked>();
        internal static Item CookedGravyPot => GetModdedGDO<Item, GravyPotCooked>();
        internal static Item GravyPortion => GetModdedGDO<Item, GravyPortion>();
        internal static ItemGroup LocoMocoPlated => GetModdedGDO<ItemGroup, LocoMocoPlated>();
        internal static Dish LocoMocoDish => GetModdedGDO<Dish, LocoMocoDish>();
        internal static Dish LocoMocoPatty => GetModdedGDO<Dish, LocoMocoPatty>();
        internal static Dish LocoMocoEgg => GetModdedGDO<Dish, LocoMocoEgg>();


        public IslandFoods() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        private void AddGameData()
        {
            LogInfo("Attempting to register game data...");
            //Modded Ingredients - Spam&Rice
            AddGameDataObject<SpamCan>();
            AddGameDataObject<SpamRaw>();
            AddGameDataObject<SpamRawPortions>();
            AddGameDataObject<SpamCookedPortions>();
            AddGameDataObject<SpamPlated>();  
            //Modded Ingredients - LocoMoco
            AddGameDataObject<GravyPotUncooked>();
            AddGameDataObject<GravyPotCooked>();
            AddGameDataObject<GravyPortion>();
            AddGameDataObject<LocoMocoPlated>();
            AddGameDataObject<LocoMocoPatty>();
            AddGameDataObject<LocoMocoEgg>();
            //Modded Dishes
            AddGameDataObject<SpamDish>();
            AddGameDataObject<LocoMocoDish>();
            AddGameDataObject<SpamMusubiDish>();
            //Modded Appliances
            AddGameDataObject<SpamProvider>();
            //ModdedSides - Spam
            AddGameDataObject<ExtraSpamPlated>();
            AddGameDataObject<SpamAsASideCard>();
            //ModdedSides - SpamMusubi
            AddGameDataObject<SpamMusubiUnfolded>();
            AddGameDataObject<SpamMusubi>();
            AddGameDataObject<SpamMusubiPlated>();
            //Modded Sides - Scrambled Eggs
            //AddGameDataObject<ScrambledEggsAsACard>();
            //ModdedExtras
            AddGameDataObject<KetchupAsACard>();


            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            // TODO: Uncomment the following if you have an asset bundle.
            // TODO: Also, make sure to set EnableAssetBundleDeploy to 'true' in your ModName.csproj

            LogInfo("Attempting to load asset bundle...");
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            LogInfo("Done loading asset bundle.");

            // Register custom GDOs
            AddGameData();

            // Perform actions when game data is built
            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
            };
        }

        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }
        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }
        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }
        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }

        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
