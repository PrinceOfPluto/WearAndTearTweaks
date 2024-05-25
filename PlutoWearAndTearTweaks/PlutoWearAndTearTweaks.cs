using GalaSoft.MvvmLight.Messaging;
using HarmonyLib;
using Railloader;
using Serilog;

namespace PlutoWearAndTearTweaks
{
    public partial class PlutoWearAndTearTweaks : SingletonPluginBase<PlutoWearAndTearTweaks>
    {
        public override void OnEnable()
        {
            var harmony = new Harmony("PrinceOfPluto.PlutoWearAndTearTweaks");
            harmony.PatchCategory("PlutoWearAndTearTweaks");
        }

        public override void OnDisable()
        {
            var harmony = new Harmony("PrinceOfPluto.PlutoWearAndTearTweaks");
            harmony.UnpatchAll("PrinceOfPluto.PlutoWearAndTearTweaks");
            Messenger.Default.Unregister(this);
        }
    }
}
