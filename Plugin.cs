using BepInEx;
using HarmonyLib;
using System.Reflection;
using System;
using UnityEngine.Rendering;
using BoplFixedMath;
using BepInEx.Configuration;

namespace AchievementManager
{
    [BepInPlugin("com.maxgamertyper1.achievementmanager", "AchievementManager", "1.0.0")]
    public class AchievementManager : BaseUnityPlugin
    {
        internal static ConfigFile config;
        internal static ConfigEntry<bool> AchievementDecision;
        private void Log(string message)
        {
            Logger.LogInfo(message);
        }

        private void Awake()
        {
            config = ((BaseUnityPlugin)this).Config;
            AchievementDecision = config.Bind<bool>("Decision", "Achievement Decision", true, "Whether to give or remove all achievements (true is give, false is remove)");
            Log($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            var harmony = new Harmony("com.maxgamertyper1.{name}");
            Patch(harmony, typeof(MainMenu), "Awake", AchievementDecision.Value ? "GiveAchievements" : "RemoveAchievements", true, false);
        }

        private void OnDestroy()
        {
            Log($"Bye Bye From {PluginInfo.PLUGIN_GUID}");
        }

        private void Patch(Harmony harmony, Type OriginalClass , string OriginalMethod, string PatchMethod, bool prefix, bool transpiler)
        {
            MethodInfo MethodToPatch = AccessTools.Method(OriginalClass, OriginalMethod); // the method to patch
            MethodInfo Patch = AccessTools.Method(typeof(AchievementManager), PatchMethod);
            
            if (prefix)
            {
                harmony.Patch(MethodToPatch, new HarmonyMethod(Patch));
            }
            else
            {
                if (transpiler)
                {
                    harmony.Patch(MethodToPatch, null, null, new HarmonyMethod(Patch));
                } else
                {
                    harmony.Patch(MethodToPatch, null, new HarmonyMethod(Patch));
                }
            }
            Log($"Patched {OriginalMethod} in {OriginalClass.ToString()}");
        }

        public static void RemoveAchievements()
        {
            foreach (AchievementHandler.AchievementEnum item in Enum.GetValues(typeof(AchievementHandler.AchievementEnum)))
            {
                System.Diagnostics.Debug.Print(item + " removed");
                AchievementHandler.achievements[(int)item].Clear();
            }
        }

        public static void GiveAchievements()
        {
            foreach (AchievementHandler.AchievementEnum item in Enum.GetValues(typeof(AchievementHandler.AchievementEnum)))
            {
                System.Diagnostics.Debug.Print(item + " given");
                AchievementHandler.achievements[(int)item].Trigger(true);
            }
        }
    }
}
