using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;
using Unity.Netcode;

namespace IdentificateIdentificate.Patches
{
    [HarmonyPatch(typeof(GameNetworkManager))]
    internal class GameNetworkManagerPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]

        static void AddToPrefabs(GameNetworkManager __instance)
        {
            __instance.GetComponent<NetworkManager>().AddNetworkPrefab(IdentificateIdentificateBase.instance.netManagerPrefab);
        }
    }
}
