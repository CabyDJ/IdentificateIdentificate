using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using IdentificateIdentificate.Patches;
using System;

namespace IdentificateIdentificate
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class IdentificateIdentificateBase : BaseUnityPlugin
    {
        private const string modGUID = "CabyDJ.IdentificateIdentificate";
        private const string modName = "Identificate Identificate";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static IdentificateIdentificateBase instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("(º)< Identificate! Awake");

            harmony.PatchAll(typeof(IdentificateIdentificateBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}