using Neo.SmartContract.Framework;
using NPC.Runtime;
using System;
using System.Numerics;

/// <summary>
/// NPC.mwherman2000.NeoExpenses1.Contract.NPCContributor Custom Methods
///
/// Processed:       2018-03-29 8:11:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:     https://github.com/mwherman2000/neo-npcc/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public partial class NPCContributor 
    {
        static readonly byte[] DOMAINUCD = "UCD".AsByteArray(); // User Credentials Directory (UCD)

        public static NPCContributor CreateContributor(NeoVersionedAppUser AppVAU, object[] args)
        {
            NPCContributor results = NPCContributor.Null();

            byte[] encodedContributorname = (byte[])args[0];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddContributor.encodedContributorname", encodedContributorname);
            byte[] encodedPassword = (byte[])args[1];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddContributor.encodedPassword", encodedPassword);

            NPCContributor uc = FindContributor(AppVAU, encodedContributorname);

            if (NPCContributor.IsMissing(uc)) // add the unique new user
            {
                if (NeoTrace.INFO) NPCContributor.LogExt("AddContributor.missing", uc);
                uc = NPCContributor.New(encodedContributorname, encodedPassword);
                NPCContributor.PutElement(uc, AppVAU, DOMAINUCD, encodedContributorname);
                if (NeoTrace.INFO) NPCContributor.LogExt("AddContributor.added", uc);
            }
            else
            {
                if (NeoTrace.INFO) NPCContributor.LogExt("AddContributor.exists", uc);
            }

            results = uc;
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("AddContributor.results", results);

            return results;
        }

        private static NPCContributor FindContributor(NeoVersionedAppUser AppVAU, byte[] encodedContributorname)
        {
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("FindContributor.encodedContributorname", encodedContributorname);

            NPCContributor result = NPCContributor.GetElement(AppVAU, DOMAINUCD, encodedContributorname);

            if (NeoTrace.ARGSRESULTS) NPCContributor.LogExt("FindContributor.result", result);

            return result;
        }

        public static NPCContributor GetContributor(NeoVersionedAppUser AppVAU, object[] args)
        {
            NPCContributor results = NPCContributor.Null();

            byte[] encodedContributorname = (byte[])args[0];
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("GetContributor.encodedContributorname", encodedContributorname);

            NPCContributor uc = FindContributor(AppVAU, encodedContributorname);
            if (NeoTrace.INFO) NPCContributor.LogExt("GetContributor.uc", uc);

            results = uc;
            if (NeoTrace.ARGSRESULTS) NeoTrace.Trace("GetContributor.results", results);

            return results;
        }

        //private static NPCContributor[] GetContributors(NeoVersionedAppUser AppVAU, object[] args)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
