using Neo.SmartContract.Framework;
using NPC.Runtime;
using System;
using System.Numerics;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCNEP5Requisition Custom Methods
///
/// Processed:       2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCNEP5Requisition 
    {
        public enum WorkflowStates
        {
            New,
            WaitingReview,
            Approved,
            Rejected,
            Paid
        }

        static readonly byte[] DOMAINNEP5REQ = "NEP5REQ".AsByteArray(); // NPCNEP5Requisition Directory (NEP5REQ)

        public static NPCNEP5Requisition CreateRequisition(NeoVersionedAppUser AppVAU, object[] args)
        {
            NPCNEP5Requisition results = NPCNEP5Requisition.Null();

            byte[] encodedRequisitionName = (byte[])args[0];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedRequisitionName", encodedRequisitionName);
            byte[] encodedPassword = (byte[])args[1];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedPassword", encodedPassword);

            NPCNEP5Requisition uc = FindRequisition(AppVAU, encodedRequisitionName);

            if (NPCNEP5Requisition.IsMissing(uc)) // add the unique new user
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.missing", uc);
                uc = NPCNEP5Requisition.New(encodedRequisitionName, encodedPassword);
                NPCNEP5Requisition.PutElement(uc, AppVAU, DOMAINNEP5REQ, encodedRequisitionName);
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.added", uc);
            }
            else
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.exists", uc);
            }

            results = uc;
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.results", results);

            return results;
        }

        public static NPCNEP5Requisition SubmitRequisition(NeoVersionedAppUser AppVAU, object[] args)
        {
            NPCNEP5Requisition results = NPCNEP5Requisition.Null();

            byte[] encodedRequisitionName = (byte[])args[0];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedRequisitionName", encodedRequisitionName);
            byte[] encodedPassword = (byte[])args[1];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedPassword", encodedPassword);

            NPCNEP5Requisition uc = FindRequisition(AppVAU, encodedRequisitionName);

            if (NPCNEP5Requisition.IsMissing(uc)) // add the unique new user
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.missing", uc);
                uc = NPCNEP5Requisition.New(encodedRequisitionName, encodedPassword);
                NPCNEP5Requisition.PutElement(uc, AppVAU, DOMAINNEP5REQ, encodedRequisitionName);
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.added", uc);
            }
            else
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.exists", uc);
            }

            results = uc;
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.results", results);

            return results;
        }

        public static NPCNEP5Requisition UpdateRequisition(NeoVersionedAppUser AppVAU, object[] args)
        {
            NPCNEP5Requisition results = NPCNEP5Requisition.Null();

            byte[] encodedRequisitionName = (byte[])args[0];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedRequisitionName", encodedRequisitionName);
            byte[] encodedPassword = (byte[])args[1];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedPassword", encodedPassword);

            NPCNEP5Requisition uc = FindRequisition(AppVAU, encodedRequisitionName);

            if (NPCNEP5Requisition.IsMissing(uc)) // add the unique new user
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.missing", uc);
                uc = NPCNEP5Requisition.New(encodedRequisitionName, encodedPassword);
                NPCNEP5Requisition.PutElement(uc, AppVAU, DOMAINNEP5REQ, encodedRequisitionName);
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.added", uc);
            }
            else
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.exists", uc);
            }

            results = uc;
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.results", results);

            return results;
        }

        public static NPCNEP5Requisition PayRequisition(NeoVersionedAppUser AppVAU, object[] args)
        {
            NPCNEP5Requisition results = NPCNEP5Requisition.Null();

            byte[] encodedRequisitionName = (byte[])args[0];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedRequisitionName", encodedRequisitionName);
            byte[] encodedPassword = (byte[])args[1];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.encodedPassword", encodedPassword);

            NPCNEP5Requisition uc = FindRequisition(AppVAU, encodedRequisitionName);

            if (NPCNEP5Requisition.IsMissing(uc)) // add the unique new user
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.missing", uc);
                uc = NPCNEP5Requisition.New(encodedRequisitionName, encodedPassword);
                NPCNEP5Requisition.PutElement(uc, AppVAU, DOMAINNEP5REQ, encodedRequisitionName);
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.added", uc);
            }
            else
            {
                if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("AddRequisition.exists", uc);
            }

            results = uc;
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddRequisition.results", results);

            return results;
        }

        private static NPCNEP5Requisition FindRequisition(NeoVersionedAppUser AppVAU, byte[] encodedRequisitionName)
        {
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("FindRequisition.encodedRequisitionName", encodedRequisitionName);

            NPCNEP5Requisition result = NPCNEP5Requisition.GetElement(AppVAU, DOMAINNEP5REQ, encodedRequisitionName);

            if (NeoTrace.ARGSRESULTS) NPCNEP5Requisition.LogExt("FindRequisition.result", result);

            return result;
        }

        public static NPCNEP5Requisition[] GetContributorRequisitions(NeoVersionedAppUser AppVAU, object[] args)
        {
            NPCNEP5Requisition[] results = { NPCNEP5Requisition.Null() };

            byte[] encodedRequisitionName = (byte[])args[0];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("GetRequisition.encodedRequisitionName", encodedRequisitionName);

            NPCNEP5Requisition uc = FindRequisition(AppVAU, encodedRequisitionName);
            if (NeoTrace.INFO) NPCNEP5Requisition.LogExt("GetRequisition.uc", uc);

            results[0] = uc;
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("GetRequisition.results", results);

            return results;
        }

        //private static NPCNEP5Requisition[] GetRequisitions(NeoVersionedAppUser AppVAU, object[] args)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
