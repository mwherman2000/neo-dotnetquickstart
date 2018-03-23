using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NPCNEP5Token1.Contract.NPCNEP5LedgerEntry - Level 2 Persistable
///
/// Processed:       2018-03-22 4:45:28 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.29190
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NPCNEP5Token1.Contract
{
    public partial class NPCEnvironment 
    {
        public static void Initialize(NPCEnvironment e)
        {
            e._callerAccountScriptHash = NeoEntityModel.NullByteArray;
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            TransactionOutput[] outputs = tx.GetOutputs();
            if (outputs.Length >= 1)
            {
                e._callerAccountScriptHash = outputs[0].ScriptHash;
            }

            e._executingScriptHash = ExecutionEngine.ExecutingScriptHash;

            Header header = Blockchain.GetHeader(Blockchain.GetHeight());
            e._blockTimestamp = header.Timestamp;
        }
    }
}