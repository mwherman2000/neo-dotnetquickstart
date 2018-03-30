using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.NeoExpenses1.Model
{
    public partial class REL_Contrib_Req : NPCLevel0Basic,
                                            NPCLevel1Managed,
                                            NPCLevel2Persistable,
                                            NPCLevel3Deletable,
                                            NPCLevel4Collectible,
                                            NPCLevel4CollectibleExt
    {
        private BigInteger reqIndex;
    }
}
