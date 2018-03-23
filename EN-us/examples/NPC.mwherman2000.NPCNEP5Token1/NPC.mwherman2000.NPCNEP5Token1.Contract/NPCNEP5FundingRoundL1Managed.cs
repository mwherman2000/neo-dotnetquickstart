using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NPCNEP5Token1.Contract.NPCNEP5FundingRound - Level 1 Managed
///
/// Processed:       2018-03-23 10:22:54 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NPCNEP5Token1.Contract
{
    public partial class NPCNEP5FundingRound : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NPCNEP5FundingRound()
        {
        }

        // Accessors

        public static void SetTotalSupply(NPCNEP5FundingRound e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._totalSupply = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetTotalSupply(NPCNEP5FundingRound e) { return e._totalSupply; }
        public static void SetStartTimestamp(NPCNEP5FundingRound e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._startTimestamp = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetStartTimestamp(NPCNEP5FundingRound e) { return e._startTimestamp; }
        public static void SetEndTimestamp(NPCNEP5FundingRound e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._endTimestamp = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetEndTimestamp(NPCNEP5FundingRound e) { return e._endTimestamp; }
        public static void Set(NPCNEP5FundingRound e, BigInteger TotalSupply, BigInteger StartTimestamp, BigInteger EndTimestamp) // Template: NPCLevel1Set_cs.txt
                                { e._totalSupply = TotalSupply; e._startTimestamp = StartTimestamp; e._endTimestamp = EndTimestamp;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NPCNEP5FundingRound _Initialize(NPCNEP5FundingRound e)
        {
            e._totalSupply = 0; e._startTimestamp = 0; e._endTimestamp = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NPCNEP5FundingRound", e);
            return e;
        }
        public static NPCNEP5FundingRound New()
        {
            NPCNEP5FundingRound e = new NPCNEP5FundingRound();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NPCNEP5FundingRound", e);
            return e;
        }
        public static NPCNEP5FundingRound New(BigInteger TotalSupply, BigInteger StartTimestamp, BigInteger EndTimestamp)
        {
            NPCNEP5FundingRound e = new NPCNEP5FundingRound();
            e._totalSupply = TotalSupply; e._startTimestamp = StartTimestamp; e._endTimestamp = EndTimestamp; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NPCNEP5FundingRound", e);
            return e;
        }
        public static NPCNEP5FundingRound Null()
        {
            NPCNEP5FundingRound e = new NPCNEP5FundingRound();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NPCNEP5FundingRound", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NPCNEP5FundingRound e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NPCNEP5FundingRound e)
        {
            TraceRuntime(label, e._totalSupply, e._startTimestamp, e._endTimestamp);
        }
        public static void LogExt(string label, NPCNEP5FundingRound e)
        {
            TraceRuntime(label, e._totalSupply, e._startTimestamp, e._endTimestamp, e._state);
        }
    }
}