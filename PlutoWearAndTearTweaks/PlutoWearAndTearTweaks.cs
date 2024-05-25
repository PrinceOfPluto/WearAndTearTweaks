using GalaSoft.MvvmLight.Messaging;
using HarmonyLib;
using Railloader;
using Serilog;

namespace PlutoWearAndTearTweaks
{
    public partial class PlutoWearAndTearTweaks : SingletonPluginBase<PlutoWearAndTearTweaks>
    {
        Serilog.ILogger logger = Log.ForContext<PlutoWearAndTearTweaks>();

        public override void OnEnable()
        {
            logger.Information("OnEnable() was called!");
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
