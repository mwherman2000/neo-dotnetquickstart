using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.REL_Contrib_Req - Level 4 Collectible (Extended)
///
/// Processed:      2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:    https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:       Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class REL_Contrib_Req : NeoTraceRuntime /* Level 4 Collectible */
    {
        /// <summary>
        /// Collectible methods (NPC Level 4)
        /// </summary>
        /// <param name="e">e</param>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>bool</returns>
        public static bool PutElement(REL_Contrib_Req e, NeoVersionedAppUser vau, byte[] domain, byte[] bindex)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA), e._state.AsBigInteger());
 
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bReqIndex), e._reqIndex); // Template: NPCLevel4APutElement_cs.txt

            if (NeoTrace.RUNTIME) LogExt("PutElement(vau,i).REL_Contrib_Req", e); // Template: NPCLevel4BGetElement_cs.txt
            return true;
        }

        /// <summary>
        /// Get an element of an array of entities from Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>REL_Contrib_Req</returns>
        public static REL_Contrib_Req GetElement(NeoVersionedAppUser vau, byte[] domain, byte[] bindex)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            REL_Contrib_Req e;
            //byte[] bkey;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).REL_Contrib_Req.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = REL_Contrib_Req.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                if (sta == NeoEntityModel.EntityState.TOMBSTONED)
                {
                    e = REL_Contrib_Req.Tombstone();
                }
                else // not MISSING && not TOMBSTONED
                {
                    e = new REL_Contrib_Req();
                    BigInteger ReqIndex = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bReqIndex)).AsBigInteger(); // Template: NPCLevel4CGetElement_cs.txt

                    e._reqIndex = ReqIndex;  // NPCLevel4DBuryElement_cs.txt
                    e._state = sta;
                    e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
                }
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).REL_Contrib_Req.e", e);
            return e;
        }

        /// <summary>
        /// Bury an element of an array of entities in Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>REL_Contrib_Req</returns>
        public static REL_Contrib_Req BuryElement(NeoVersionedAppUser vau, byte[] domain, byte[] bindex)
        {
            if (NeoVersionedAppUser.IsNull(vau)) // TODO - create NeoEntityModel.EntityState.BADKEY?
            {
                return REL_Contrib_Req.Null();
            }

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            REL_Contrib_Req e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(vau,index).REL_Contrib_Req.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = REL_Contrib_Req.Missing();
            }
            else // not MISSING - bury it
            {
                e = REL_Contrib_Req.Tombstone(); // TODO - should Bury() preserve the exist field values or re-initialize them? Preserve is cheaper but not as private
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bSTA), e._state.AsBigInteger());

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, bindex, _bReqIndex), e._reqIndex); // NPCLevel4EBuryElement_cs.txt

            } // Template: NPCLevel4Part2_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(vau,i).REL_Contrib_Req", e);
            return e;
        }
    }
}