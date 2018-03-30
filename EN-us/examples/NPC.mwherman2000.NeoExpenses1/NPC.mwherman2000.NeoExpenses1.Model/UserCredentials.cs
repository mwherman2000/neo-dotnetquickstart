namespace NPC.mwherman2000.NeoExpenses1.Model
{
    public partial class UserCredentials :   NPCLevel0Basic,
                                     NPCLevel1Managed,
                                     NPCLevel2Persistable,
                                     NPCLevel3Deletable,
                                     NPCLevel4Collectible,
                                     NPCLevel4CollectibleExt
    {
        public byte[] encodedUsername;
        public byte[] encodedPassword;
    }
}
