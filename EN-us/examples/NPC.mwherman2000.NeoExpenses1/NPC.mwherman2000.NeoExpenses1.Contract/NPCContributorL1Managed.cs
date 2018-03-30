using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCContributor - Level 1 Managed
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCContributor : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NPCContributor()
        {
        }

        // Accessors

        public static void SetName(NPCContributor e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._name = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetName(NPCContributor e) { return e._name; }
        public static void SetTitle(NPCContributor e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._title = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetTitle(NPCContributor e) { return e._title; }
        public static void SetApproverScriptHash(NPCContributor e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._approverScriptHash = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetApproverScriptHash(NPCContributor e) { return e._approverScriptHash; }
        public static void SetReqPublicKey(NPCContributor e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._reqPublicKey = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetReqPublicKey(NPCContributor e) { return e._reqPublicKey; }
        public static void Set(NPCContributor e, string Name, string Title, byte[] ApproverScriptHash, byte[] ReqPublicKey) // Template: NPCLevel1Set_cs.txt
                                { e._name = Name; e._title = Title; e._approverScriptHash = ApproverScriptHash; e._reqPublicKey = ReqPublicKey;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NPCContributor _Initialize(NPCContributor e)
        {
            e._name = ""; e._title = ""; e._approverScriptHash = NeoEntityModel.NullByteArray; e._reqPublicKey = NeoEntityModel.NullByteArray; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NPCContributor", e);
            return e;
        }
        public static NPCContributor New()
        {
            NPCContributor e = new NPCContributor();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NPCContributor", e);
            return e;
        }
        public static NPCContributor New(string Name, string Title, byte[] ApproverScriptHash, byte[] ReqPublicKey)
        {
            NPCContributor e = new NPCContributor();
            e._name = Name; e._title = Title; e._approverScriptHash = ApproverScriptHash; e._reqPublicKey = ReqPublicKey; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NPCContributor", e);
            return e;
        }
        public static NPCContributor Null()
        {
            NPCContributor e = new NPCContributor();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NPCContributor", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NPCContributor e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NPCContributor e)
        {
            TraceRuntime(label, e._name, e._title, e._approverScriptHash, e._reqPublicKey);
        }
        public static void LogExt(string label, NPCContributor e)
        {
            TraceRuntime(label, e._name, e._title, e._approverScriptHash, e._reqPublicKey, e._state);
        }
    }
}