using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.NPCNEP5Token1.Model
{
    public class NPCNEP5FundingRound : NPCLevel0Basic,
                                 NPCLevel1Managed,
                                 NPCLevel2Persistable
    {
        public BigInteger totalSupply;
        public BigInteger startTimestamp;
        public BigInteger endTimestamp;
    }
}
