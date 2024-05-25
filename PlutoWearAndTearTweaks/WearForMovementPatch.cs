using HarmonyLib;
using Model.Definition;
using Railloader;
using Serilog;

namespace PlutoWearAndTearTweaks
{
    [HarmonyPatch(typeof(Model.Car), "WearForMovement", new Type[] { typeof(float) })]
    [HarmonyPatchCategory("PlutoWearAndTearTweaks")]
    public static class WearForMovementPatch
    {
        static void Prefix()
        {
            Log.ForContext(typeof(PlutoWearAndTearTweaks)).Information("WearForMovement Awake()");
        }
        static void Postfix(float kilometers, Model.Car __instance, ref float __result)
        {
            float fivePercentPerHundredMilesToKilometers = 3.106863E-04f;
            if (__instance.Archetype == CarArchetype.LocomotiveSteam || __instance.Archetype == CarArchetype.LocomotiveDiesel)
            {
                __result = 0.25f;
                Log.Information($"Wear For Movement method with {kilometers}");
                Log.Information($"Car health is {__instance.Condition}");
            }
            __result = 0.25f;
            Log.Information("end of patch");
        }
    }
}
