[HarmonyLib.HarmonyPatch(typeof(XRL.World.BeforeDeathRemovalEvent))]
[HarmonyLib.HarmonyPatch(nameof(XRL.World.BeforeDeathRemovalEvent.Send))]
//[HarmonyLib.HarmonyPatch(new System.Type[] { typeof(XRL.World.BeforeDeathRemovalEvent) })]
class HundredPercentPsycheAbsorbChance
{
	static bool Prefix()
	{
		if (XRL.World.Parts.AbsorbablePsyche.ABSORB_CHANCE == 100)
		{
			return true;
		}
		System.Reflection.Assembly.GetAssembly(typeof(XRL.World.Parts.AbsorbablePsyche))
		.GetType("XRL.World.Parts.AbsorbablePsyche")
		.GetField("ABSORB_CHANCE", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
		.SetValue(null, 100);
		return true;
	}
}
