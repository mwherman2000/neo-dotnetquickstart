using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.UserCredentials - Level 4 Collectible
///
/// Processed:      2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:    https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:       Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class UserCredentials : NeoTraceRuntime /* Level 4 Collectible */
    {
        /// <summary>
        /// Collectible methods (NPC Level 4)
        /// </summary>
        /// <param name="e">e</param>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>bool</returns>
        public static bool PutElement(UserCredentials e, NeoVersionedAppUser vau, byte[] domain, int index)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA), e._state.AsBigInteger());
 
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bEncodedUsername), e._encodedUsername); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bEncodedPassword), e._encodedPassword); // Template: NPCLevel4APutElement_cs.txt

            if (NeoTrace.RUNTIME) LogExt("PutElement(vau,i).UserCredentials", e); // Template: NPCLevel4BGetElement_cs.txt
            return true;
        }

        /// <summary>
        /// Get an element of an array of entities from Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>UserCredentials</returns>
        public static UserCredentials GetElement(NeoVersionedAppUser vau, byte[] domain, int index)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            UserCredentials e;
            //byte[] bkey;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).UserCredentials.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = UserCredentials.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                if (sta == NeoEntityModel.EntityState.TOMBSTONED)
                {
                    e = UserCredentials.Tombstone();
                }
                else // not MISSING && not TOMBSTONED
                {
                    e = new UserCredentials();
                    byte[] EncodedUsername = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bEncodedUsername)); // Template: NPCLevel4CGetElement_cs.txt

                    byte[] EncodedPassword = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bEncodedPassword)); // Template: NPCLevel4CGetElement_cs.txt

                    e._encodedUsername = EncodedUsername; e._encodedPassword = EncodedPassword;  // NPCLevel4DBuryElement_cs.txt
                    e._state = sta;
                    e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
                }
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).UserCredentials.e", e);
            return e;
        }

        /// <summary>
        /// Bury an element of an array of entities in Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>UserCredentials</returns>
        public static UserCredentials BuryElement(NeoVersionedAppUser vau, byte[] domain, int index)
        {
            if (NeoVersionedAppUser.IsNull(vau)) // TODO - create NeoEntityModel.EntityState.BADKEY?
            {
                return UserCredentials.Null();
            }

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            UserCredentials e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(vau,index).UserCredentials.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = UserCredentials.Missing();
            }
            else // not MISSING - bury it
            {
                e = UserCredentials.Tombstone(); // TODO - should Bury() preserve the exist field values or re-initialize them? Preserve is cheaper but not as private
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA), e._state.AsBigInteger());

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bEncodedUsername), e._encodedUsername); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bEncodedPassword), e._encodedPassword); // NPCLevel4EBuryElement_cs.txt

            } // Template: NPCLevel4Part2_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(vau,i).UserCredentials", e);
            return e;
        }
    }
}