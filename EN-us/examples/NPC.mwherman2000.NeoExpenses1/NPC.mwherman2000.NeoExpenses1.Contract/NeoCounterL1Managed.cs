using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NeoCounter - Level 1 Managed
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NeoCounter : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NeoCounter()
        {
        }

        // Accessors

        public static void SetCurrentNumber(NeoCounter e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._currentNumber = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetCurrentNumber(NeoCounter e) { return e._currentNumber; }
        public static void Set(NeoCounter e, BigInteger CurrentNumber) // Template: NPCLevel1Set_cs.txt
                                { e._currentNumber = CurrentNumber;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NeoCounter _Initialize(NeoCounter e)
        {
            e._currentNumber = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NeoCounter", e);
            return e;
        }
        public static NeoCounter New()
        {
            NeoCounter e = new NeoCounter();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NeoCounter", e);
            return e;
        }
        public static NeoCounter New(BigInteger CurrentNumber)
        {
            NeoCounter e = new NeoCounter();
            e._currentNumber = CurrentNumber; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NeoCounter", e);
            return e;
        }
        public static NeoCounter Null()
        {
            NeoCounter e = new NeoCounter();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NeoCounter", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NeoCounter e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NeoCounter e)
        {
            TraceRuntime(label, e._currentNumber);
        }
        public static void LogExt(string label, NeoCounter e)
        {
            TraceRuntime(label, e._currentNumber, e._state);
        }
    }
}