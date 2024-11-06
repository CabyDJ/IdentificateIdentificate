using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using IdentificateIdentificate.Managers;
using IdentificateIdentificate.Patches;
using System;
using System.Reflection;
using UnityEngine;

namespace IdentificateIdentificate
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class IdentificateIdentificateBase : BaseUnityPlugin
    {
        //cd ../NetcodePatcher
        //NetcodePatcher.dll $(TargetDir) deps/
        private const string modGUID = "CabyDJ.IdentificateIdentificate";
        private const string modName = "Identificate Identificate";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static IdentificateIdentificateBase instance;

        internal static ManualLogSource mls;

        internal static AudioClip[] SoundFX;
        internal static AssetBundle Bundle;

        public GameObject netManagerPrefab;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            mls.LogInfo("(º)< Identificate! Pre Awake");

            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("(º)< Identificate! Awake");

            //harmony.PatchAll(typeof(IdentificateIdentificateBase));
            //harmony.PatchAll(typeof(PlayerControllerBPatch));

            string NetworkFolderLocation = instance.Info.Location;
            NetworkFolderLocation = NetworkFolderLocation.TrimEnd("IdentificateIdentificateBase.dll".ToCharArray());
            AssetBundle NetworkBundle = AssetBundle.LoadFromFile(NetworkFolderLocation + "identificatenetworkmanager");

            if (NetworkBundle != null)
            {
                mls.LogInfo("(º)< Network bundle loaded");
                netManagerPrefab = NetworkBundle.LoadAsset<GameObject>("Assets/Netcode/NetworkManagerIdentificate.prefab");
            }
            else
            {
                mls.LogInfo("(º`)< Error loading NetworkBundle");
            }

            netManagerPrefab.AddComponent<NetworkManagerIdentificate>();

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

            harmony.PatchAll();

        }
    }
}