using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.NeoExpenses1.Model
{
    public partial class NPCEnvironment : NPCLevel0Basic, NPCLevel1Managed
    {
        public byte[] CallerAccountScriptHash;
        public byte[] ExecutingScriptHash;
        public BigInteger BlockTimestamp;
    }
}
