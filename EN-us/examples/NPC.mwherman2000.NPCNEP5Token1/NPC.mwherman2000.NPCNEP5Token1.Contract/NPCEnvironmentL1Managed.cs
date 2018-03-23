using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NPCNEP5Token1.Contract.NPCEnvironment - Level 1 Managed
///
/// Processed:       2018-03-23 10:22:54 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NPCNEP5Token1.Contract
{
    public partial class NPCEnvironment : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NPCEnvironment()
        {
        }

        // Accessors

        public static void SetCallerAccountScriptHash(NPCEnvironment e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._callerAccountScriptHash = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetCallerAccountScriptHash(NPCEnvironment e) { return e._callerAccountScriptHash; }
        public static void SetExecutingScriptHash(NPCEnvironment e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._executingScriptHash = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetExecutingScriptHash(NPCEnvironment e) { return e._executingScriptHash; }
        public static void SetBlockTimestamp(NPCEnvironment e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._blockTimestamp = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetBlockTimestamp(NPCEnvironment e) { return e._blockTimestamp; }
        public static void Set(NPCEnvironment e, byte[] CallerAccountScriptHash, byte[] ExecutingScriptHash, BigInteger BlockTimestamp) // Template: NPCLevel1Set_cs.txt
                                { e._callerAccountScriptHash = CallerAccountScriptHash; e._executingScriptHash = ExecutingScriptHash; e._blockTimestamp = BlockTimestamp;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NPCEnvironment _Initialize(NPCEnvironment e)
        {
            e._callerAccountScriptHash = NeoEntityModel.NullByteArray; e._executingScriptHash = NeoEntityModel.NullByteArray; e._blockTimestamp = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NPCEnvironment", e);
            return e;
        }
        public static NPCEnvironment New()
        {
            NPCEnvironment e = new NPCEnvironment();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NPCEnvironment", e);
            return e;
        }
        public static NPCEnvironment New(byte[] CallerAccountScriptHash, byte[] ExecutingScriptHash, BigInteger BlockTimestamp)
        {
            NPCEnvironment e = new NPCEnvironment();
            e._callerAccountScriptHash = CallerAccountScriptHash; e._executingScriptHash = ExecutingScriptHash; e._blockTimestamp = BlockTimestamp; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NPCEnvironment", e);
            return e;
        }
        public static NPCEnvironment Null()
        {
            NPCEnvironment e = new NPCEnvironment();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NPCEnvironment", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NPCEnvironment e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NPCEnvironment e)
        {
            TraceRuntime(label, e._callerAccountScriptHash, e._executingScriptHash, e._blockTimestamp);
        }
        public static void LogExt(string label, NPCEnvironment e)
        {
            TraceRuntime(label, e._callerAccountScriptHash, e._executingScriptHash, e._blockTimestamp, e._state);
        }
    }
}