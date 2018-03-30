using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCNEP5Requisition - Level 4 Collectible (Extended)
///
/// Processed:      2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:    https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:       Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCNEP5Requisition : NeoTraceRuntime /* Level 4 Collectible */
    {
        /// <summary>
        /// Collectible methods (NPC Level 4)
        /// </summary>
        /// <param name="e">e</param>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>bool</returns>
        public static bool PutElement(NPCNEP5Requisition e, NeoVersionedAppUser vau, byte[] domain, byte[] bindex)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA), e._state.AsBigInteger());
 
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bFromScriptHash), e._fromScriptHash); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bToScriptHash), e._toScriptHash); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bEncryptedBlobURI), e._encryptedBlobURI); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bWorkflowState), e._workflowState); // Template: NPCLevel4APutElement_cs.txt

            if (NeoTrace.RUNTIME) LogExt("PutElement(vau,i).NPCNEP5Requisition", e); // Template: NPCLevel4BGetElement_cs.txt
            return true;
        }

        /// <summary>
        /// Get an element of an array of entities from Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>NPCNEP5Requisition</returns>
        public static NPCNEP5Requisition GetElement(NeoVersionedAppUser vau, byte[] domain, byte[] bindex)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            NPCNEP5Requisition e;
            //byte[] bkey;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).NPCNEP5Requisition.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5Requisition.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                if (sta == NeoEntityModel.EntityState.TOMBSTONED)
                {
                    e = NPCNEP5Requisition.Tombstone();
                }
                else // not MISSING && not TOMBSTONED
                {
                    e = new NPCNEP5Requisition();
                    byte[] FromScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bFromScriptHash)); // Template: NPCLevel4CGetElement_cs.txt

                    byte[] ToScriptHash = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bToScriptHash)); // Template: NPCLevel4CGetElement_cs.txt

                    string EncryptedBlobURI = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bEncryptedBlobURI)).AsString(); // Template: NPCLevel4CGetElement_cs.txt

                    Int32 WorkflowState = (Int32)Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bWorkflowState)).AsBigInteger(); // Template: NPCLevel4CGetElement_cs.txt

                    e._fromScriptHash = FromScriptHash; e._toScriptHash = ToScriptHash; e._encryptedBlobURI = EncryptedBlobURI; e._workflowState = WorkflowState;  // NPCLevel4DBuryElement_cs.txt
                    e._state = sta;
                    e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
                }
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).NPCNEP5Requisition.e", e);
            return e;
        }

        /// <summary>
        /// Bury an element of an array of entities in Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>NPCNEP5Requisition</returns>
        public static NPCNEP5Requisition BuryElement(NeoVersionedAppUser vau, byte[] domain, byte[] bindex)
        {
            if (NeoVersionedAppUser.IsNull(vau)) // TODO - create NeoEntityModel.EntityState.BADKEY?
            {
                return NPCNEP5Requisition.Null();
            }

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            NPCNEP5Requisition e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(vau,index).NPCNEP5Requisition.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = NPCNEP5Requisition.Missing();
            }
            else // not MISSING - bury it
            {
                e = NPCNEP5Requisition.Tombstone(); // TODO - should Bury() preserve the exist field values or re-initialize them? Preserve is cheaper but not as private
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA), e._state.AsBigInteger());

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bFromScriptHash), e._fromScriptHash); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bToScriptHash), e._toScriptHash); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bEncryptedBlobURI), e._encryptedBlobURI); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bWorkflowState), e._workflowState); // NPCLevel4EBuryElement_cs.txt

            } // Template: NPCLevel4Part2_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(vau,i).NPCNEP5Requisition", e);
            return e;
        }
    }
}