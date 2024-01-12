using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificateIdentificate.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]

    internal class PlayerControllerBPatch
    {

        [HarmonyPatch("Emote2_performed")]
        [HarmonyPostfix]
        static void Emote2_performed_Patch(ref bool ___isPlayerDead)
        {
            ___isPlayerDead = true;
        }
    }
}
