using HarmonyLib;
using Model.Definition;
using Railloader;
using Serilog;
using System;

namespace PlutoWearAndTearTweaks
{
    [HarmonyPatch(typeof(Model.Car), "WearForMovement", new Type[] { typeof(float) })]
    [HarmonyPatchCategory("PlutoWearAndTearTweaks")]
    public class WearForMovementPatch
    {
        static void Postfix(float kilometers, Model.Car __instance, ref float __result)
        {
            float fivePercentPerHundredMilesToKilometers = 3.106863E-04f;
            if (__instance.Archetype == CarArchetype.LocomotiveSteam || __instance.Archetype == CarArchetype.LocomotiveDiesel)
            {
                __result = fivePercentPerHundredMilesToKilometers * kilometers;
            }
        }
    }
}
