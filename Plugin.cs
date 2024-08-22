using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;

namespace BossSkins
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "InfernoDragon0.cotl.BossSkins";
        public const string PluginName = "BossSkins";
        public const string PluginVer = "1.0.1";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        internal static ConfigEntry<string> extraUnlocks;

        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);

            //SETUP: Config
            extraUnlocks = Config.Bind("BossSkins", "ExtraSkins", "", "Add the codenames for skins you want to select for normal followers as well, separated by commas. Do not use quotation marks. If the skin does not exist, it adds a default deer skin to the selection. EXAMPLE - ExtraSkins = Cat,Dog,Pig");

        }

        private void OnEnable()
        {
            Harmony.PatchAll();
            Logger.LogInfo($"Loaded {PluginName}!");
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            Logger.LogInfo($"Unloaded {PluginName}!");
        }
    }
}