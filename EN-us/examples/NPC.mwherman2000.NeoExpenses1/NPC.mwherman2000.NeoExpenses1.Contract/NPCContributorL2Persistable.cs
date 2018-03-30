using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCContributor - Level 2 Persistable
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCContributor : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "NPCContributor";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sName = "Name"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bName = Helper.AsByteArray(_sName);
        private const string _sTitle = "Title"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bTitle = Helper.AsByteArray(_sTitle);
        private const string _sApproverScriptHash = "ApproverScriptHash"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bApproverScriptHash = Helper.AsByteArray(_sApproverScriptHash);
        private const string _sReqPublicKey = "ReqPublicKey"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bReqPublicKey = Helper.AsByteArray(_sReqPublicKey);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(NPCContributor e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static NPCContributor Missing()
        {
            NPCContributor e = new NPCContributor();
            e._name = ""; e._title = ""; e._approverScriptHash = NeoEntityModel.NullByteArray; e._reqPublicKey = NeoEntityModel.NullByteArray; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().NPCContributor", e);
            return e;
        }

        public static bool Put(NPCContributor e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bName), e._name); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bTitle), e._title); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bApproverScriptHash), e._approverScriptHash); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bReqPublicKey), e._reqPublicKey); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).NPCContributor", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(NPCContributor e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCContributor", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sName, e._name); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sTitle, e._title); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sApproverScriptHash, e._approverScriptHash); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sReqPublicKey, e._reqPublicKey); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCContributor", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static NPCContributor Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            NPCContributor e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCContributor.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCContributor();

                string Name = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bName)).AsString(); //NPCLevel2GGet_cs.txt
                string Title = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bTitle)).AsString(); //NPCLevel2GGet_cs.txt
                byte[] ApproverScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bApproverScriptHash)); //NPCLevel2GGet_cs.txt
                byte[] ReqPublicKey = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bReqPublicKey)); //NPCLevel2GGet_cs.txt
                e._name = Name; e._title = Title; e._approverScriptHash = ApproverScriptHash; e._reqPublicKey = ReqPublicKey;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).NPCContributor", e);
            return e;
        }

        public static NPCContributor Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            NPCContributor e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).NPCContributor.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCContributor.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCContributor();

                string Name = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sName).AsString(); //NPCLevel2IGet_cs.txt
                string Title = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sTitle).AsString(); //NPCLevel2IGet_cs.txt
                byte[] ApproverScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sApproverScriptHash); //NPCLevel2IGet_cs.txt
                byte[] ReqPublicKey = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sReqPublicKey); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._name, e._title, e._approverScriptHash, e._reqPublicKey", e._name, e._title, e._approverScriptHash, e._reqPublicKey); // Template: NPCLevel2Part2_cs.txt
                e._name = Name; e._title = Title; e._approverScriptHash = ApproverScriptHash; e._reqPublicKey = ReqPublicKey; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).NPCContributor", e);
            return e;
        }
    }
}