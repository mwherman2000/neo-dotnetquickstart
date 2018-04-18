using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.UserDirectory1.Contract.UserLedgerEntry - Level 1 Managed
///
/// Processed:       2018-04-17 10:34:32 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.38328
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.UserDirectory1.Contract
{
    public partial class UserLedgerEntry : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private UserLedgerEntry()
        {
        }

        // Accessors

        public static void SetUserScriptHash(UserLedgerEntry e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._userScriptHash = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetUserScriptHash(UserLedgerEntry e) { return e._userScriptHash; }
        public static void SetPassphraseScriptHash(UserLedgerEntry e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._passphraseScriptHash = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetPassphraseScriptHash(UserLedgerEntry e) { return e._passphraseScriptHash; }
        public static void Set(UserLedgerEntry e, byte[] UserScriptHash, byte[] PassphraseScriptHash) // Template: NPCLevel1Set_cs.txt
                                { {e._userScriptHash = UserScriptHash; e._passphraseScriptHash = PassphraseScriptHash;  e._state = NeoEntityModel.EntityState.SET;} }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static UserLedgerEntry _Initialize(UserLedgerEntry e)
        {
            e._userScriptHash = NeoEntityModel.NullByteArray; e._passphraseScriptHash = NeoEntityModel.NullByteArray; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).UserLedgerEntry", e);
            return e;
        }
        public static UserLedgerEntry New()
        {
            UserLedgerEntry e = new UserLedgerEntry();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().UserLedgerEntry", e);
            return e;
        }
        public static UserLedgerEntry New(byte[] UserScriptHash, byte[] PassphraseScriptHash)
        {
            UserLedgerEntry e = new UserLedgerEntry();
            e._userScriptHash = UserScriptHash; e._passphraseScriptHash = PassphraseScriptHash; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).UserLedgerEntry", e);
            return e;
        }
        public static UserLedgerEntry Null()
        {
            UserLedgerEntry e = new UserLedgerEntry();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().UserLedgerEntry", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(UserLedgerEntry e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, UserLedgerEntry e)
        {
            TraceRuntime(label, e._userScriptHash, e._passphraseScriptHash);
        }
        public static void LogExt(string label, UserLedgerEntry e)
        {
            TraceRuntime(label, e._userScriptHash, e._passphraseScriptHash, e._state);
        }
    }
}