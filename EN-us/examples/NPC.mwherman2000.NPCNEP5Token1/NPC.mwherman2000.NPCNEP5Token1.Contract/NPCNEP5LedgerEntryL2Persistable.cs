using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NPCNEP5Token1.Contract.NPCNEP5LedgerEntry - Level 2 Persistable
///
/// Processed:       2018-03-23 10:22:54 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NPCNEP5Token1.Contract
{
    public partial class NPCNEP5LedgerEntry : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "NPCNEP5LedgerEntry";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sLastTxTimestamp = "LastTxTimestamp"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bLastTxTimestamp = Helper.AsByteArray(_sLastTxTimestamp);
        private const string _sDebitCreditAmount = "DebitCreditAmount"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bDebitCreditAmount = Helper.AsByteArray(_sDebitCreditAmount);
        private const string _sBalance = "Balance"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bBalance = Helper.AsByteArray(_sBalance);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(NPCNEP5LedgerEntry e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static NPCNEP5LedgerEntry Missing()
        {
            NPCNEP5LedgerEntry e = new NPCNEP5LedgerEntry();
            e._lastTxTimestamp = 0; e._debitCreditAmount = 0; e._balance = 0; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().NPCNEP5LedgerEntry", e);
            return e;
        }

        public static bool Put(NPCNEP5LedgerEntry e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bLastTxTimestamp), e._lastTxTimestamp); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bDebitCreditAmount), e._debitCreditAmount); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bBalance), e._balance); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).NPCNEP5LedgerEntry", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(NPCNEP5LedgerEntry e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCNEP5LedgerEntry", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sLastTxTimestamp, e._lastTxTimestamp); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sDebitCreditAmount, e._debitCreditAmount); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sBalance, e._balance); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCNEP5LedgerEntry", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static NPCNEP5LedgerEntry Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            NPCNEP5LedgerEntry e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5LedgerEntry.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCNEP5LedgerEntry();

                BigInteger LastTxTimestamp = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bLastTxTimestamp)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                BigInteger DebitCreditAmount = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bDebitCreditAmount)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                BigInteger Balance = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bBalance)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                e._lastTxTimestamp = LastTxTimestamp; e._debitCreditAmount = DebitCreditAmount; e._balance = Balance;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).NPCNEP5LedgerEntry", e);
            return e;
        }

        public static NPCNEP5LedgerEntry Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            NPCNEP5LedgerEntry e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).NPCNEP5LedgerEntry.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5LedgerEntry.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCNEP5LedgerEntry();

                BigInteger LastTxTimestamp = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sLastTxTimestamp).AsBigInteger(); //NPCLevel2IGet_cs.txt
                BigInteger DebitCreditAmount = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sDebitCreditAmount).AsBigInteger(); //NPCLevel2IGet_cs.txt
                BigInteger Balance = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sBalance).AsBigInteger(); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._lastTxTimestamp, e._debitCreditAmount, e._balance", e._lastTxTimestamp, e._debitCreditAmount, e._balance); // Template: NPCLevel2Part2_cs.txt
                e._lastTxTimestamp = LastTxTimestamp; e._debitCreditAmount = DebitCreditAmount; e._balance = Balance; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).NPCNEP5LedgerEntry", e);
            return e;
        }
    }
}