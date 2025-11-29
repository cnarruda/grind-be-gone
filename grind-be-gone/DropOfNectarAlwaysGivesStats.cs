[HarmonyLib.HarmonyPatch(typeof(XRL.World.Effects.CookingDomainAttributes_UnitPermanentAllStats_25Percent))]
[HarmonyLib.HarmonyPatch(nameof(XRL.World.Effects.CookingDomainAttributes_UnitPermanentAllStats_25Percent.Init))]
class DropOfNectarAlwaysGivesStats
{
    static void Postfix(XRL.World.Effects.CookingDomainAttributes_UnitPermanentAllStats_25Percent __instance)
    {
       __instance.Succeed = true;
    }
}
