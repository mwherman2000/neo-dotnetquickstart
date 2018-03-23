using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NPCNEP5Token1.Contract.NPCNEP5Base - Level 1 Managed
///
/// Processed:       2018-03-23 10:22:54 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NPCNEP5Token1.Contract
{
    public partial class NPCNEP5Base : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NPCNEP5Base()
        {
        }

        // Accessors

        public static void SetName(NPCNEP5Base e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._name = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetName(NPCNEP5Base e) { return e._name; }
        public static void SetSymbol(NPCNEP5Base e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._symbol = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetSymbol(NPCNEP5Base e) { return e._symbol; }
        public static void SetDecimals(NPCNEP5Base e, Int32 value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._decimals = value; e._state = NeoEntityModel.EntityState.SET; }
        public static Int32 GetDecimals(NPCNEP5Base e) { return e._decimals; }
        public static void SetTotalSupply(NPCNEP5Base e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._totalSupply = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetTotalSupply(NPCNEP5Base e) { return e._totalSupply; }
        public static void Set(NPCNEP5Base e, string Name, string Symbol, Int32 Decimals, BigInteger TotalSupply) // Template: NPCLevel1Set_cs.txt
                                { e._name = Name; e._symbol = Symbol; e._decimals = Decimals; e._totalSupply = TotalSupply;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NPCNEP5Base _Initialize(NPCNEP5Base e)
        {
            e._name = ""; e._symbol = ""; e._decimals = 0; e._totalSupply = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NPCNEP5Base", e);
            return e;
        }
        public static NPCNEP5Base New()
        {
            NPCNEP5Base e = new NPCNEP5Base();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NPCNEP5Base", e);
            return e;
        }
        public static NPCNEP5Base New(string Name, string Symbol, Int32 Decimals, BigInteger TotalSupply)
        {
            NPCNEP5Base e = new NPCNEP5Base();
            e._name = Name; e._symbol = Symbol; e._decimals = Decimals; e._totalSupply = TotalSupply; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NPCNEP5Base", e);
            return e;
        }
        public static NPCNEP5Base Null()
        {
            NPCNEP5Base e = new NPCNEP5Base();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NPCNEP5Base", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NPCNEP5Base e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NPCNEP5Base e)
        {
            TraceRuntime(label, e._name, e._symbol, e._decimals, e._totalSupply);
        }
        public static void LogExt(string label, NPCNEP5Base e)
        {
            TraceRuntime(label, e._name, e._symbol, e._decimals, e._totalSupply, e._state);
        }
    }
}