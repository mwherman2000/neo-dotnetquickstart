using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.REL_Contrib_Req - Level 1 Managed
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class REL_Contrib_Req : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private REL_Contrib_Req()
        {
        }

        // Accessors

        public static void SetReqIndex(REL_Contrib_Req e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._reqIndex = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetReqIndex(REL_Contrib_Req e) { return e._reqIndex; }
        public static void Set(REL_Contrib_Req e, BigInteger ReqIndex) // Template: NPCLevel1Set_cs.txt
                                { e._reqIndex = ReqIndex;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static REL_Contrib_Req _Initialize(REL_Contrib_Req e)
        {
            e._reqIndex = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).REL_Contrib_Req", e);
            return e;
        }
        public static REL_Contrib_Req New()
        {
            REL_Contrib_Req e = new REL_Contrib_Req();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().REL_Contrib_Req", e);
            return e;
        }
        public static REL_Contrib_Req New(BigInteger ReqIndex)
        {
            REL_Contrib_Req e = new REL_Contrib_Req();
            e._reqIndex = ReqIndex; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).REL_Contrib_Req", e);
            return e;
        }
        public static REL_Contrib_Req Null()
        {
            REL_Contrib_Req e = new REL_Contrib_Req();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().REL_Contrib_Req", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(REL_Contrib_Req e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, REL_Contrib_Req e)
        {
            TraceRuntime(label, e._reqIndex);
        }
        public static void LogExt(string label, REL_Contrib_Req e)
        {
            TraceRuntime(label, e._reqIndex, e._state);
        }
    }
}