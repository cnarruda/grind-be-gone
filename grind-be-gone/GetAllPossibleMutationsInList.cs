using System;

[HarmonyLib.HarmonyPatch(typeof(XRL.GlobalConfig))]
[HarmonyLib.HarmonyPatch(nameof(XRL.GlobalConfig.GetIntSetting))]
class GetAllPossibleMutationsInList
{
    static void Postfix(string Name, ref int __result)
    {
        if (Name == "RandomBuyMutationCount") {
            __result = 2147483647; //return max 32 bit int because why not :)
        }
    }
}
