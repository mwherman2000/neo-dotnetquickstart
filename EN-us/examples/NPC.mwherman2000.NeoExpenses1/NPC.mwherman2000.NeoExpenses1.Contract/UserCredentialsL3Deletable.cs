using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.UserCredentials - Level 3 Deletable
///
/// Processed:      2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:    https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:       Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class UserCredentials : NeoTraceRuntime /* Level 3 Deletable */
    {
        // Deletable methods
        public static bool IsBuried(UserCredentials e)
        {
            return (e._state == NeoEntityModel.EntityState.TOMBSTONED);
        }

        public static UserCredentials Tombstone()
        {
            UserCredentials e = new UserCredentials();
            e._encodedUsername = NeoEntityModel.NullByteArray; e._encodedPassword = NeoEntityModel.NullByteArray; 
            e._state = NeoEntityModel.EntityState.TOMBSTONED;
            if (NeoTrace.RUNTIME) LogExt("Tombstone().UserCredentials", e);
            return e;
        }

        public static UserCredentials Bury(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            UserCredentials e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = UserCredentials.Missing();
            }
            else // not MISSING - bury it
            {
                e = UserCredentials.Tombstone(); // but don't overwrite existing field values - just tombstone it
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bEncodedUsername), e._encodedUsername); // Template: NPCLevel3ABury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bEncodedPassword), e._encodedPassword); // Template: NPCLevel3ABury_cs.txt
            } // Template: NPCLevel3BBury_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(bkey).UserCredentials", e); 
            return e; // return Entity e to signal if key is Missing or bad key
        }

        public static UserCredentials Bury(string key)
        {
            if (key.Length == 0) return Null(); 

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            UserCredentials e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(skey).UserCredentials.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = UserCredentials.Missing();
            }
            else // not MISSING - bury it
            {
                e = UserCredentials.Tombstone(); // but don't overwrite existing field values - just tombstone it
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, e._state.AsBigInteger());

                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sEncodedUsername, e._encodedUsername); // Template: NPCLevel3CBury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sEncodedPassword, e._encodedPassword); // Template: NPCLevel3CBury_cs.txt
            } // Template: NPCLevel3Part2_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(skey).UserCredentials", e);
            return e; // return Entity e to signal if key is Missing or bad key
        }
    }
}