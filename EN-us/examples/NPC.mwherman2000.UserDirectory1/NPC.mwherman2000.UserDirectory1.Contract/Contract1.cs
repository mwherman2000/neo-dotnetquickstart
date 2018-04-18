using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;
using NPC.Runtime;

namespace NPC.mwherman2000.UserDirectory1.Contract
{
    public class Contract1 : SmartContract
    {
        private const string _AppName = "UserDirectory1";
        private const int _AppVersionMajor = 1;
        private const int _AppVersionMinor = 1;
        private const int _AppVersionBuild = 1034;
        private const string _OwnerAccount = "ATrzHaicmhRj15C3Vv6e6gLfLqhSD2PtTr";
        private static readonly byte[] _OwnerAccountScriptHash = _OwnerAccount.ToScriptHash(); 

        private const string _User1Account = "ATszHaicmhRj15C3Vv6e6gLfLqhSD2PtTr";
        private static readonly byte[] _User1AccountScriptHash = _User1Account.ToScriptHash();
        private const string _User1Passphrase = "The quick brown fox jumps over the lazy dog";
        private static readonly byte[] _User1PassphraseScriptHash = Sha256(_User1Passphrase.AsByteArray());

        private const string _User2Account = "ATtzHaicmhRj15C3Vv6e6gLfLqhSD2PtTr";
        private static readonly byte[] _User2AccountScriptHash = _User2Account.ToScriptHash();
        private const string _User2Passphrase = "The lazy brown fox jumps over the quick dog";
        private static readonly byte[] _User2PassphraseScriptHash = Sha256(_User2Passphrase.AsByteArray());

        private static readonly byte[] DOMAIN_MYCOUNTER2 = "MyCounter2".AsByteArray();
        private static readonly byte[] DOMAIN_MYCOUNTER5 = "MyCounter5".AsByteArray();
        private static readonly byte[] DOMAIN_USERLEDGER = "UserLedger".AsByteArray();

        public static object Main()
        {
            object result = false;

            NeoVersionedAppUser vau = NeoVersionedAppUser.New(_AppName, _AppVersionMajor, _AppVersionMinor, _AppVersionBuild, _OwnerAccountScriptHash);

            NeoCounter counter1 = NeoCounter.New(1234);
            NeoCounter.Put(counter1, "MyCounter1");
            NeoCounter.Log("counter1", counter1);
            counter1 = NeoCounter.Get("MyCounter1");
            NeoCounter.Log("counter1", counter1);

            NeoCounter counter2 = NeoCounter.New(5678);
            NeoCounter.PutElement(counter2, vau, DOMAIN_MYCOUNTER2, 0);
            NeoCounter.Log("counter2", counter2);
            counter2 = NeoCounter.GetElement(vau, DOMAIN_MYCOUNTER2, 0);
            NeoCounter.Log("counter2", counter2);

            BigInteger nextNumber3 = NeoCounter.TakeNextNumber(vau, NeoCounter.NeoCounters.PointCounter);
            NeoTrace.Trace("nextNumber3", nextNumber3);
            nextNumber3 = NeoCounter.TakeNextNumber(vau, NeoCounter.NeoCounters.PointCounter);
            NeoTrace.Trace("nextNumber3", nextNumber3);
            nextNumber3 = NeoCounter.TakeNextNumber(vau, NeoCounter.NeoCounters.PointCounter);
            NeoTrace.Trace("nextNumber3", nextNumber3);

            BigInteger nextNumber5 = NeoCounter.TakeNextNumber(vau, DOMAIN_MYCOUNTER5, NeoCounter.NeoCounters.RequisitionCounter);
            NeoTrace.Trace("nextNumber5", nextNumber5);
            nextNumber5 = NeoCounter.TakeNextNumber(vau, DOMAIN_MYCOUNTER5, NeoCounter.NeoCounters.RequisitionCounter);
            NeoTrace.Trace("nextNumber5", nextNumber5);
            nextNumber5 = NeoCounter.TakeNextNumber(vau, DOMAIN_MYCOUNTER5, NeoCounter.NeoCounters.RequisitionCounter);
            NeoTrace.Trace("nextNumber5", nextNumber5);

            int iteration = 0;
            while (true)
            {
                if (iteration >= 10) break;
                NeoTrace.Trace("iteration", iteration);

                BigInteger nextIndex = NeoCounter.TakeNextNumber(vau, NeoCounter.NeoCounters.UserCounter);
                NeoTrace.Trace("nextIndex", nextIndex);

                UserLedgerEntry e = UserLedgerEntry.New(_User1AccountScriptHash, _User1PassphraseScriptHash);
                UserLedgerEntry.Log("e.put1", e);
                UserLedgerEntry.SetUserScriptHash(e, _User2AccountScriptHash);
                UserLedgerEntry.Log("e.put2", e);
                UserLedgerEntry.SetPassphraseScriptHash(e, _User2PassphraseScriptHash);
                UserLedgerEntry.Log("e.put3", e);

                UserLedgerEntry.PutElement(e, vau, DOMAIN_USERLEDGER, (int)nextIndex);
                iteration++;
            }

            iteration = 0;
            BigInteger nUsers = NeoCounter.GetNextNumber(vau, NeoCounter.NeoCounters.UserCounter);
            UserLedgerEntry[] users = new UserLedgerEntry[(int)nUsers];
            while (true)
            {
                if (iteration >= nUsers) break;
                NeoTrace.Trace("iteration", iteration);

                UserLedgerEntry e = UserLedgerEntry.GetElement(vau, DOMAIN_USERLEDGER, iteration);
                UserLedgerEntry.Log("e.get", e);
                users[iteration] = e;
                UserLedgerEntry.Log("users[iteration]", users[iteration]);
                iteration++;
            }

            result = users;
            return result;
        }
    }
}
