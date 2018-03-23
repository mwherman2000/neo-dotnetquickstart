using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NPCNEP5Token1.Contract.NPCNEP5FundingRound - Level 2 Persistable
///
/// Processed:       2018-03-23 10:22:54 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NPCNEP5Token1.Contract
{
    public partial class NPCNEP5FundingRound : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "NPCNEP5FundingRound";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sTotalSupply = "TotalSupply"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bTotalSupply = Helper.AsByteArray(_sTotalSupply);
        private const string _sStartTimestamp = "StartTimestamp"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bStartTimestamp = Helper.AsByteArray(_sStartTimestamp);
        private const string _sEndTimestamp = "EndTimestamp"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bEndTimestamp = Helper.AsByteArray(_sEndTimestamp);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(NPCNEP5FundingRound e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static NPCNEP5FundingRound Missing()
        {
            NPCNEP5FundingRound e = new NPCNEP5FundingRound();
            e._totalSupply = 0; e._startTimestamp = 0; e._endTimestamp = 0; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().NPCNEP5FundingRound", e);
            return e;
        }

        public static bool Put(NPCNEP5FundingRound e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bTotalSupply), e._totalSupply); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bStartTimestamp), e._startTimestamp); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bEndTimestamp), e._endTimestamp); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).NPCNEP5FundingRound", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(NPCNEP5FundingRound e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCNEP5FundingRound", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sTotalSupply, e._totalSupply); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sStartTimestamp, e._startTimestamp); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sEndTimestamp, e._endTimestamp); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCNEP5FundingRound", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static NPCNEP5FundingRound Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            NPCNEP5FundingRound e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5FundingRound.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCNEP5FundingRound();

                BigInteger TotalSupply = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bTotalSupply)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                BigInteger StartTimestamp = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bStartTimestamp)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                BigInteger EndTimestamp = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bEndTimestamp)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                e._totalSupply = TotalSupply; e._startTimestamp = StartTimestamp; e._endTimestamp = EndTimestamp;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).NPCNEP5FundingRound", e);
            return e;
        }

        public static NPCNEP5FundingRound Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            NPCNEP5FundingRound e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).NPCNEP5FundingRound.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5FundingRound.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCNEP5FundingRound();

                BigInteger TotalSupply = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sTotalSupply).AsBigInteger(); //NPCLevel2IGet_cs.txt
                BigInteger StartTimestamp = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sStartTimestamp).AsBigInteger(); //NPCLevel2IGet_cs.txt
                BigInteger EndTimestamp = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sEndTimestamp).AsBigInteger(); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._totalSupply, e._startTimestamp, e._endTimestamp", e._totalSupply, e._startTimestamp, e._endTimestamp); // Template: NPCLevel2Part2_cs.txt
                e._totalSupply = TotalSupply; e._startTimestamp = StartTimestamp; e._endTimestamp = EndTimestamp; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).NPCNEP5FundingRound", e);
            return e;
        }
    }
}