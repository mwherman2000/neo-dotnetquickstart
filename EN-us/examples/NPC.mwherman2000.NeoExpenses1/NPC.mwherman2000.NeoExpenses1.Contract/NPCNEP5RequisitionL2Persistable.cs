using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCNEP5Requisition - Level 2 Persistable
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCNEP5Requisition : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "NPCNEP5Requisition";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sFromScriptHash = "FromScriptHash"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bFromScriptHash = Helper.AsByteArray(_sFromScriptHash);
        private const string _sToScriptHash = "ToScriptHash"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bToScriptHash = Helper.AsByteArray(_sToScriptHash);
        private const string _sEncryptedBlobURI = "EncryptedBlobURI"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bEncryptedBlobURI = Helper.AsByteArray(_sEncryptedBlobURI);
        private const string _sWorkflowState = "WorkflowState"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bWorkflowState = Helper.AsByteArray(_sWorkflowState);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(NPCNEP5Requisition e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static NPCNEP5Requisition Missing()
        {
            NPCNEP5Requisition e = new NPCNEP5Requisition();
            e._fromScriptHash = NeoEntityModel.NullByteArray; e._toScriptHash = NeoEntityModel.NullByteArray; e._encryptedBlobURI = ""; e._workflowState = 0; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().NPCNEP5Requisition", e);
            return e;
        }

        public static bool Put(NPCNEP5Requisition e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bFromScriptHash), e._fromScriptHash); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bToScriptHash), e._toScriptHash); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bEncryptedBlobURI), e._encryptedBlobURI); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bWorkflowState), e._workflowState); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).NPCNEP5Requisition", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(NPCNEP5Requisition e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCNEP5Requisition", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sFromScriptHash, e._fromScriptHash); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sToScriptHash, e._toScriptHash); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sEncryptedBlobURI, e._encryptedBlobURI); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sWorkflowState, e._workflowState); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).NPCNEP5Requisition", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static NPCNEP5Requisition Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            NPCNEP5Requisition e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5Requisition.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCNEP5Requisition();

                byte[] FromScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bFromScriptHash)); //NPCLevel2GGet_cs.txt
                byte[] ToScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bToScriptHash)); //NPCLevel2GGet_cs.txt
                string EncryptedBlobURI = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bEncryptedBlobURI)).AsString(); //NPCLevel2GGet_cs.txt
                Int32 WorkflowState = (Int32)Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bWorkflowState)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                e._fromScriptHash = FromScriptHash; e._toScriptHash = ToScriptHash; e._encryptedBlobURI = EncryptedBlobURI; e._workflowState = WorkflowState;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).NPCNEP5Requisition", e);
            return e;
        }

        public static NPCNEP5Requisition Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            NPCNEP5Requisition e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).NPCNEP5Requisition.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5Requisition.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new NPCNEP5Requisition();

                byte[] FromScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sFromScriptHash); //NPCLevel2IGet_cs.txt
                byte[] ToScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sToScriptHash); //NPCLevel2IGet_cs.txt
                string EncryptedBlobURI = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sEncryptedBlobURI).AsString(); //NPCLevel2IGet_cs.txt
                Int32 WorkflowState = (Int32)Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sWorkflowState).AsBigInteger(); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._fromScriptHash, e._toScriptHash, e._encryptedBlobURI, e._workflowState", e._fromScriptHash, e._toScriptHash, e._encryptedBlobURI, e._workflowState); // Template: NPCLevel2Part2_cs.txt
                e._fromScriptHash = FromScriptHash; e._toScriptHash = ToScriptHash; e._encryptedBlobURI = EncryptedBlobURI; e._workflowState = WorkflowState; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).NPCNEP5Requisition", e);
            return e;
        }
    }
}