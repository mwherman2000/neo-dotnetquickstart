using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.NPCNEP5Token1.Model
{
    public interface NPCLevel0Basic { }
    public interface NPCLevel1Managed { }
    public interface NPCLevel2Persistable { }
    public interface NPCLevel3Deletable { }
    public interface NPCLevel4Collectible { }
    public interface NPCLevel4CollectibleExt { }

    public interface NPCLevel0CustomMethods { }
    public interface NPCLevel11CustomMethods { }
    public interface NPCLevel2CustomMethods { }
    public interface NPCLevel3CustomMethods { }
    public interface NPCLevel4CustomMethods { }

    public class NPCNEP5Base : NPCLevel0Basic,
                                 NPCLevel1Managed
    {
        public string name;
        public string symbol;
        public Int32 decimals;
        public BigInteger totalSupply;
    }
}
