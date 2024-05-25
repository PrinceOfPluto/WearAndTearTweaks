using HarmonyLib;
using Model.Definition;
using Railloader;
using Serilog;
using UnityEngine;

namespace PlutoWearAndTearTweaks
{
    [HarmonyPatch(typeof(Model.Car), "RepairCap", MethodType.Getter)]
    [HarmonyPatchCategory("PlutoWearAndTearTweaks")]
    public class RepairCapPatch
    {
        static void Postfix(Model.Car __instance, ref float __result)
        {
            if (__instance.Archetype == CarArchetype.LocomotiveSteam || __instance.Archetype == CarArchetype.LocomotiveDiesel)
            {
                float kilometers = __instance.OdometerService - __instance.LastOverhaulOdometer;
                __result = Mathf.Clamp01(1f - Mathf.Min(0.5f, (float)Mathf.FloorToInt((float)((double)kilometers * 0.62137120962142944 / 1000.0)) * 0.1f));
            }
        }
    }
}
