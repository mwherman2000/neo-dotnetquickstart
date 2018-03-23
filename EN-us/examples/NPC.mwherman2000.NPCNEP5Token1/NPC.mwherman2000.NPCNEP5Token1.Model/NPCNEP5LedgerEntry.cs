using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.NPCNEP5Token1.Model
{
    public partial class NPCNEP5LedgerEntry : NPCLevel0Basic,
                                 NPCLevel1Managed,
                                 NPCLevel2Persistable
    {
        public BigInteger lastTxTimestamp;
        public BigInteger debitCreditAmount;
        public BigInteger balance;
    }
}
