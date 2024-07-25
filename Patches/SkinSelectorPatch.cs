using COTL_API.CustomTarotCard;
using HarmonyLib;
using Lamb.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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

            };

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
