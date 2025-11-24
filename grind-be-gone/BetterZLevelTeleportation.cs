using System;
using XRL.Rules;

[HarmonyLib.HarmonyPatch(typeof(XRL.World.Parts.SpaceTimeVortex))]
[HarmonyLib.HarmonyPatch(nameof(XRL.World.Parts.SpaceTimeVortex.GetRandomDestinationZoneID))]
class BetterZLevelTeleportation
{
    static bool Prefix(ref string World)
    {
        if (World == "JoppaWorld")
        {
            World = "JoppaWorld2";
        }
        return true;
    }
    
    static void Postfix(string World, bool Validate, ref string __result)
    {
        string WorldParam = World;
        if (WorldParam == "JoppaWorld2")
        {
            WorldParam = "JoppaWorld";
        }
        if (WorldParam == "JoppaWorld")
        {
            int surfaceZLevel = 10;
            int statRandomLow = 10;
            int statRandomHigh = 40;
            string text;
            while (true)
            {
                int parasangX = XRL.Rules.Stat.Random(0, 79);
                int parasangY = XRL.Rules.Stat.Random(0, 24);
                int zoneX = XRL.Rules.Stat.Random(0, 2);
                int zoneY = XRL.Rules.Stat.Random(0, 2);
                int zoneZ = (50.in100() ? XRL.Rules.Stat.Random(statRandomLow, statRandomHigh) : surfaceZLevel);
                text = XRL.World.ZoneID.Assemble(WorldParam, parasangX, parasangY, zoneX, zoneY, zoneZ);
                if (!Validate)
                {
                    break;
                }
                XRL.World.Zone zone = XRL.The.ZoneManager.GetZone(text);
                if (zone.GetEmptyCellCount() < 100)
                {
                    continue;
                }
                XRL.World.Cell cell = null;
                int num = 0;
                while (++num < 5)
                {
                    XRL.World.Cell randomCell = zone.GetRandomCell(3 - num / 25);
                    if (randomCell.IsReachable() && !randomCell.IsSolid())
                    {
                        cell = randomCell;
                        break;
                    }
                }
                if (cell != null)
                {
                    break;
                }
            }
            __result = text;
        }
    }
}