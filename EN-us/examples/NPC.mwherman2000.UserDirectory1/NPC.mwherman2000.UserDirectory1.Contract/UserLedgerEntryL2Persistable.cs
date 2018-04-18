using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.UserDirectory1.Contract.UserLedgerEntry - Level 2 Persistable
///
/// Processed:       2018-04-17 10:34:32 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.38328
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.UserDirectory1.Contract
{
    public partial class UserLedgerEntry : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "UserLedgerEntry";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sUserScriptHash = "UserScriptHash"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bUserScriptHash = Helper.AsByteArray(_sUserScriptHash);
        private const string _sPassphraseScriptHash = "PassphraseScriptHash"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bPassphraseScriptHash = Helper.AsByteArray(_sPassphraseScriptHash);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(UserLedgerEntry e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static UserLedgerEntry Missing()
        {
            UserLedgerEntry e = new UserLedgerEntry();
            e._userScriptHash = NeoEntityModel.NullByteArray; e._passphraseScriptHash = NeoEntityModel.NullByteArray; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().UserLedgerEntry", e);
            return e;
        }

        public static bool Put(UserLedgerEntry e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            // no readonly fields byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            // no readonly fields if (NeoTrace.RUNTIME) TraceRuntime("Put(bkey).bsta", bsta.Length, bsta);
            // no readonly fields bool isMissing = false; if (bsta.Length == 0) isMissing = true;

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bUserScriptHash), e._userScriptHash); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bPassphraseScriptHash), e._passphraseScriptHash); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).UserLedgerEntry", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(UserLedgerEntry e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).UserLedgerEntry", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            // no readonly fields byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            // no readonly fields if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bsta", bsta.Length, bsta);
            // no readonly fields bool isMissing = false; if (bsta.Length == 0) isMissing = true;

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sUserScriptHash, e._userScriptHash); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sPassphraseScriptHash, e._passphraseScriptHash); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).UserLedgerEntry", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static UserLedgerEntry Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            UserLedgerEntry e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = UserLedgerEntry.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new UserLedgerEntry();

                byte[] UserScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bUserScriptHash)); //NPCLevel2GGet_cs.txt
                byte[] PassphraseScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bPassphraseScriptHash)); //NPCLevel2GGet_cs.txt
                e._userScriptHash = UserScriptHash; e._passphraseScriptHash = PassphraseScriptHash;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).UserLedgerEntry", e);
            return e;
        }

        public static UserLedgerEntry Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            UserLedgerEntry e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).UserLedgerEntry.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = UserLedgerEntry.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new UserLedgerEntry();

                byte[] UserScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sUserScriptHash); //NPCLevel2IGet_cs.txt
                byte[] PassphraseScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sPassphraseScriptHash); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._userScriptHash, e._passphraseScriptHash", e._userScriptHash, e._passphraseScriptHash); // Template: NPCLevel2Part2_cs.txt
                e._userScriptHash = UserScriptHash; e._passphraseScriptHash = PassphraseScriptHash; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).UserLedgerEntry", e);
            return e;
        }
    }
}