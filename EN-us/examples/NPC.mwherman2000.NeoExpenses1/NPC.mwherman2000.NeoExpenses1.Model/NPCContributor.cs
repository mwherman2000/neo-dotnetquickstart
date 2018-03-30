using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.NeoExpenses1.Model
{
    public partial class NPCContributor : NPCLevel0Basic,
                                         NPCLevel1Managed,
                                         NPCLevel2Persistable,
                                         NPCLevel3Deletable,
                                         NPCLevel4Collectible,
                                         NPCLevel4CollectibleExt
    {
        private string Name;
        private string Title;
        private byte[] ApproverScriptHash;
        private byte[] ReqPublicKey;
    }
}
