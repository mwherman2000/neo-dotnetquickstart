using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.NeoExpenses1.Model
{
    public partial class NPCNEP5Requisition : NPCLevel0Basic,
                                         NPCLevel1Managed,
                                         NPCLevel2Persistable,
                                         NPCLevel3Deletable,
                                         NPCLevel4Collectible,
                                         NPCLevel4CollectibleExt
    {
        private byte[] FromScriptHash;
        private byte[] ToScriptHash;
        private string EncryptedBlobURI;
        private int WorkflowState;
    }
}
