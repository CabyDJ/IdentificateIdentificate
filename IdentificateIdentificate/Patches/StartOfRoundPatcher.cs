using HarmonyLib;
using Unity.Netcode;
using UnityEngine;
using System;

namespace IdentificateIdentificate.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]

        static void spawnNetManager(StartOfRound __instance)
        {
            if (__instance.IsHost)
            {
                GameObject go = GameObject.Instantiate(IdentificateIdentificateBase.instance.netManagerPrefab);
                go.GetComponent<NetworkObject>().Spawn();
            }
        }
    }
}
