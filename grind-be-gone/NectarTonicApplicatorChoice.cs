using static XRL.Extensions;

[HarmonyLib.HarmonyPatch(typeof(XRL.World.Parts.Nectar_Tonic_Applicator))]
[HarmonyLib.HarmonyPatch(nameof(XRL.World.Parts.Nectar_Tonic_Applicator.FireEvent))]
class NectarTonicApplicatorChoice
{
    static bool Prefix(XRL.World.Event E, XRL.World.Parts.Nectar_Tonic_Applicator __instance/*, bool __resultRef*/)
    {
        if (E.ID == "ApplyTonic")
        {
            int intParameter = E.GetIntParameter("Dosage");
            XRL.World.GameObject gameObjectParameter = E.GetGameObjectParameter("Subject");
            string text = "";
            if (intParameter <= 0 || (__instance.ParentObject != null && __instance.ParentObject.IsTemporary && !gameObjectParameter.IsTemporary))
            {
                text += "The experience is fleeting.";
            }
            else
            {
                System.Collections.Generic.List<string> list1 = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<char> list2 = new System.Collections.Generic.List<char>();
                list2.Add('a');
                list1.Add("Strength");
                list2.Add('b');
                list1.Add("Intelligence");
                list2.Add('c');
                list1.Add("Ego");
                list2.Add('d');
                list1.Add("Agility");
                list2.Add('e');
                list1.Add("Willpower");
                list2.Add('f');
                list1.Add("Toughness");
                if (!gameObjectParameter.IsTrueKin())
                {
                    list2.Add('g');
                    list1.Add("MP");
                }
                int pick = XRL.UI.Popup.PickOption("Choose the outcome of Eaters' nectar injector (or cancel to randomize)", null, "", "Sounds/UI/ui_notification", list1.ToArray(), list2.ToArray(), null, null, null, null, null, 0, 60, 0, -1, AllowEscape: true);
                string choice;
                if (pick < 0)
                {
                    choice = null;
                }
                else
                {
                    choice = list1[pick];
                }
                gameObjectParameter.PermuteRandomMutationBuys();
                if (gameObjectParameter.IsTrueKin())
                {
                    if (gameObjectParameter.HasStat("AP"))
                    {
                        if (choice == null)
                        {
                            choice = "AP";
                        }
                        gameObjectParameter.GetStat(choice).BaseValue += intParameter;
                        text = text + "{{C|You gain " + intParameter.Things("attribute point") + "!}}";
                    }
                }
                else if (!"MP".Equals(choice) && 50.in100())
                {
                    int num = XRL.Rules.Stat.Random(1, 6);
                    string text2 = "Strength";
                    if (num == 1)
                    {
                        text2 = "Strength";
                    }
                    if (num == 2)
                    {
                        text2 = "Intelligence";
                    }
                    if (num == 3)
                    {
                        text2 = "Ego";
                    }
                    if (num == 4)
                    {
                        text2 = "Agility";
                    }
                    if (num == 5)
                    {
                        text2 = "Willpower";
                    }
                    if (num == 6)
                    {
                        text2 = "Toughness";
                    }
                    if (choice != null)
                    {
                        text2 = choice;
                    }
                    if (gameObjectParameter.HasStat(text2))
                    {
                        gameObjectParameter.GetStat(text2).BaseValue += intParameter;
                        text = text + "{{C|You gain " + intParameter.Things("point") + " of " + text2 + "!}}";
                    }
                }
                else if (gameObjectParameter.HasStat("MP"))
                {
                    gameObjectParameter.GainMP(intParameter);
                    text = text + "{{C|You gain " + intParameter.Things("mutation point") + "!}}";
                }
                if (gameObjectParameter.IsPlayer())
                {
                    string text3 = "You taste life as it was distilled by the Eaters, Qud's primordial masons.";
                    if (!text.IsNullOrEmpty())
                    {
                        text3 = text3 + "\n\n" + text;
                    }
                    XRL.UI.Popup.Show(text3);
                    gameObjectParameter.GetPart<XRL.World.Parts.Leveler>().SifrahInsights();
                }
            }
        }
        //__resultRef = true;
        return false;
    }
}
