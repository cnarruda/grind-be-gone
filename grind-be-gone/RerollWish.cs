[XRL.Wish.HasWishCommand]
public class RerollWish
{
    //[XRL.Wish.WishCommand(Command = "checkAbsorb")]
    //public static void PsycheAbsorbCheckHandler()
    //{
    //    XRL.UI.Popup.Show("Absorb Psyche chance is currently " + XRL.World.Parts.AbsorbablePsyche.ABSORB_CHANCE + "%");
    //}

    [XRL.Wish.WishCommand(Command = "reroll")]
    public static void rerollMutationBuys()
    {
        XRL.World.GameObject player = XRL.The.Player;
        player.PermuteRandomMutationBuys();
        XRL.UI.Popup.Show("Rerolled results for: Mutations / Drop of Nectar / Eaters' Nectar / Brain Brine");
    }
}