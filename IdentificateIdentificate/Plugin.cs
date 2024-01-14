using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using IdentificateIdentificate.Patches;
using System;
using UnityEngine;

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

        internal static ManualLogSource mls;

        internal static AudioClip[] SoundFX;
        internal static AssetBundle Bundle;

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

            SoundFX = new AudioClip[1];
            string FolderLocation = instance.Info.Location;
            FolderLocation = FolderLocation.TrimEnd("IdentificateIdentificateBase.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(FolderLocation + "identificate");

            if (Bundle != null)
            {
                mls.LogInfo("(º)< asset bundle loaded");
                SoundFX = Bundle.LoadAllAssets<AudioClip>();
            }
            else
            {
                mls.LogInfo("(º`)< Error loading asset bundle");
            }
        }
    }
}