[HarmonyLib.HarmonyPatch(typeof(XRL.UI.TradeUI), nameof(XRL.UI.TradeUI.ShowTradeScreen))]
class GiveTamSomeItems
{
	static bool Prefix(XRL.World.GameObject Trader,
					   float _costMultiple = 1f,
					   XRL.UI.TradeUI.TradeScreenMode screenMode = XRL.UI.TradeUI.TradeScreenMode.Trade)
	{
		if (Trader.DisplayName == "Tam, dromad merchant")
		{
			XRL.World.Parts.Inventory inventory = Trader.Inventory;
			System.Collections.Generic.List<XRL.World.GameObject> objs = new System.Collections.Generic.List<XRL.World.GameObject>();
			if (!inventory.HasObject("Metamorphic Polygel"))
			{
				objs.Add(XRL.World.GameObject.Create("Metamorphic Polygel"));
			}
			if (!inventory.HasObject("NectarTonic"))
			{
				objs.Add(XRL.World.GameObject.Create("NectarTonic"));
			}
			if (!inventory.HasObject("Drop of Nectar"))
			{
				objs.Add(XRL.World.GameObject.Create("Drop of Nectar"));
			}
			if (!inventory.HasObject("BrainBrinePhial"))
			{
				objs.Add(XRL.World.GameObject.Create("BrainBrinePhial"));
			}
			if (objs.Count > 0)
			{
				Trader.ReceiveObject(objs);
			}
		}
		return true;
	}
}
