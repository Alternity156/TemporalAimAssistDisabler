using Harmony;
using System.Collections.Generic;

namespace AudicaModding
{
    class Hooks
    {
        [HarmonyPatch(typeof(Gun), "FindBestIntersection")]
        private static class GunFindBestIntersectionPatch
        {
            private static void Prefix(Gun __instance, Target target, float aimRadius, ref bool temporalAssist)
            {
                if (AudicaMod.taaOff)
                {
                    temporalAssist = false;
                }
            }
        }
    }
}
