using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCNEP5Requisition - Level 1 Managed
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCNEP5Requisition : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private NPCNEP5Requisition()
        {
        }

        // Accessors

        public static void SetFromScriptHash(NPCNEP5Requisition e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._fromScriptHash = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetFromScriptHash(NPCNEP5Requisition e) { return e._fromScriptHash; }
        public static void SetToScriptHash(NPCNEP5Requisition e, byte[] value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._toScriptHash = value; e._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetToScriptHash(NPCNEP5Requisition e) { return e._toScriptHash; }
        public static void SetEncryptedBlobURI(NPCNEP5Requisition e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._encryptedBlobURI = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetEncryptedBlobURI(NPCNEP5Requisition e) { return e._encryptedBlobURI; }
        public static void SetWorkflowState(NPCNEP5Requisition e, Int32 value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._workflowState = value; e._state = NeoEntityModel.EntityState.SET; }
        public static Int32 GetWorkflowState(NPCNEP5Requisition e) { return e._workflowState; }
        public static void Set(NPCNEP5Requisition e, byte[] FromScriptHash, byte[] ToScriptHash, string EncryptedBlobURI, Int32 WorkflowState) // Template: NPCLevel1Set_cs.txt
                                { e._fromScriptHash = FromScriptHash; e._toScriptHash = ToScriptHash; e._encryptedBlobURI = EncryptedBlobURI; e._workflowState = WorkflowState;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static NPCNEP5Requisition _Initialize(NPCNEP5Requisition e)
        {
            e._fromScriptHash = NeoEntityModel.NullByteArray; e._toScriptHash = NeoEntityModel.NullByteArray; e._encryptedBlobURI = ""; e._workflowState = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).NPCNEP5Requisition", e);
            return e;
        }
        public static NPCNEP5Requisition New()
        {
            NPCNEP5Requisition e = new NPCNEP5Requisition();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().NPCNEP5Requisition", e);
            return e;
        }
        public static NPCNEP5Requisition New(byte[] FromScriptHash, byte[] ToScriptHash, string EncryptedBlobURI, Int32 WorkflowState)
        {
            NPCNEP5Requisition e = new NPCNEP5Requisition();
            e._fromScriptHash = FromScriptHash; e._toScriptHash = ToScriptHash; e._encryptedBlobURI = EncryptedBlobURI; e._workflowState = WorkflowState; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).NPCNEP5Requisition", e);
            return e;
        }
        public static NPCNEP5Requisition Null()
        {
            NPCNEP5Requisition e = new NPCNEP5Requisition();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().NPCNEP5Requisition", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(NPCNEP5Requisition e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, NPCNEP5Requisition e)
        {
            TraceRuntime(label, e._fromScriptHash, e._toScriptHash, e._encryptedBlobURI, e._workflowState);
        }
        public static void LogExt(string label, NPCNEP5Requisition e)
        {
            TraceRuntime(label, e._fromScriptHash, e._toScriptHash, e._encryptedBlobURI, e._workflowState, e._state);
        }
    }
}