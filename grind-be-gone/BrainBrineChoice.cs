[HarmonyLib.HarmonyPatch(typeof(XRL.World.Effects.BrainBrineCurse))]
[HarmonyLib.HarmonyPatch(nameof(XRL.World.Effects.BrainBrineCurse.GainChoice))]
class BrainBrineChoice
{
    private static bool done = false;
    static bool Prefix(XRL.World.Effects.BrainBrineCurse __instance, string Choice)
    {
        if (done)
        {
            return done;
        }
        done = true;
        System.Collections.Generic.List<string> list1 = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<char> list2 = new System.Collections.Generic.List<char>();
        list2.Add('a');
        list1.Add("skills");
        list2.Add('b');
        list1.Add("sp");
        list2.Add('c');
        list1.Add("ego");
        list2.Add('d');
        list1.Add("int");
        list2.Add('e');
        list1.Add("wis");
        list2.Add('f');
        list1.Add("secrets");
        list2.Add('g');
        list1.Add("+mutation");
        list2.Add('h');
        list1.Add("-mutation");
        int num = XRL.UI.Popup.PickOption("Choose the outcome of Brain Brine (or let fate take it's course...)", null, "", "Sounds/UI/ui_notification", list1.ToArray(), list2.ToArray(), null, null, null, null, null, 0, 60, 0, -1, AllowEscape: true);
        if (num < 0)
        {
            //fate accepted
        }
        else
        {
            Choice = list1[num];
        }
        XRL.World.Effects.BrainBrineCurse myEntity = __instance as XRL.World.Effects.BrainBrineCurse;
        myEntity.GainChoice(Choice);
        done = false;
        return done;
    }
}
