using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCNEP5LedgerEntry - Level 1 Managed
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCNEP5LedgerEntry : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NPCNEP5LedgerEntry()
        {
        }

        // Accessors

        public static void SetLastTxTimestamp(NPCNEP5LedgerEntry e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._lastTxTimestamp = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetLastTxTimestamp(NPCNEP5LedgerEntry e) { return e._lastTxTimestamp; }
        public static void SetDebitCreditAmount(NPCNEP5LedgerEntry e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._debitCreditAmount = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetDebitCreditAmount(NPCNEP5LedgerEntry e) { return e._debitCreditAmount; }
        public static void SetBalance(NPCNEP5LedgerEntry e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._balance = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetBalance(NPCNEP5LedgerEntry e) { return e._balance; }
        public static void Set(NPCNEP5LedgerEntry e, BigInteger LastTxTimestamp, BigInteger DebitCreditAmount, BigInteger Balance) // Template: NPCLevel1Set_cs.txt
                                { e._lastTxTimestamp = LastTxTimestamp; e._debitCreditAmount = DebitCreditAmount; e._balance = Balance;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NPCNEP5LedgerEntry _Initialize(NPCNEP5LedgerEntry e)
        {
            e._lastTxTimestamp = 0; e._debitCreditAmount = 0; e._balance = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NPCNEP5LedgerEntry", e);
            return e;
        }
        public static NPCNEP5LedgerEntry New()
        {
            NPCNEP5LedgerEntry e = new NPCNEP5LedgerEntry();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NPCNEP5LedgerEntry", e);
            return e;
        }
        public static NPCNEP5LedgerEntry New(BigInteger LastTxTimestamp, BigInteger DebitCreditAmount, BigInteger Balance)
        {
            NPCNEP5LedgerEntry e = new NPCNEP5LedgerEntry();
            e._lastTxTimestamp = LastTxTimestamp; e._debitCreditAmount = DebitCreditAmount; e._balance = Balance; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NPCNEP5LedgerEntry", e);
            return e;
        }
        public static NPCNEP5LedgerEntry Null()
        {
            NPCNEP5LedgerEntry e = new NPCNEP5LedgerEntry();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NPCNEP5LedgerEntry", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NPCNEP5LedgerEntry e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NPCNEP5LedgerEntry e)
        {
            TraceRuntime(label, e._lastTxTimestamp, e._debitCreditAmount, e._balance);
        }
        public static void LogExt(string label, NPCNEP5LedgerEntry e)
        {
            TraceRuntime(label, e._lastTxTimestamp, e._debitCreditAmount, e._balance, e._state);
        }
    }
}