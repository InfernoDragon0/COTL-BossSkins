using HarmonyLib;
using Lamb.UI;
using System.Collections.Generic;

namespace BossSkins.Patches
{
    [HarmonyPatch]
    internal class SkinSelectorPatch
    {
        [HarmonyPatch(typeof(UIAppearanceMenuController_Form), nameof(UIAppearanceMenuController_Form.OnShowStarted))]
        [HarmonyPostfix]
        public static void UIAppearanceMenuController_Form_OnShowStarted(UIAppearanceMenuController_Form __instance)
        {
            //Get all the boss skins
            //convert the above to a list
            var skinList = new List<int>()
            {
                WorshipperData._Instance.GetSkinIndexFromName("Boss Death Cat"),
                WorshipperData._Instance.GetSkinIndexFromName("Boss Aym"),
                WorshipperData._Instance.GetSkinIndexFromName("Boss Baal"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 1"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 2"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 3"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 4"),
                WorshipperData._Instance.GetSkinIndexFromName("Sozo"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 1 Healed"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 2 Healed"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 3 Healed"),
                WorshipperData._Instance.GetSkinIndexFromName("CultLeader 4 Healed"),

            };

            string[] splitted = Plugin.extraUnlocks.Value.Split(',');

            foreach (string s in splitted)
            {
                if (string.IsNullOrEmpty(s))
                {
                    Plugin.Log.LogInfo("Empty string found in extraUnlocks, skipping.");
                    continue;
                }

                Plugin.Log.LogInfo("Adding extra skin: " + s + " to the list.");
                skinList.Add(WorshipperData._Instance.GetSkinIndexFromName(s));
            }

            var list = new List<WorshipperData.SkinAndData>()
            {
            };

            foreach ( var skinid in skinList )
            {
                Plugin.Log.LogInfo("BOSS SKIN Enable ID " + skinid);
                list.Add(WorshipperData._Instance.Characters[skinid]);

            }

            __instance._specialEventsHeader.SetActive(true);
            __instance._formItems.AddRange(
                __instance.Populate(list, __instance._specialEventsContent, null)
            );

            /*return true;*/
        }



        
    }
}
