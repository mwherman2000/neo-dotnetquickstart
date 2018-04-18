using Neo.SmartContract.Framework;
using NPC.Runtime;
using System;
using System.Numerics;

/// <summary>
/// NPC.mwherman2000.UserDirectory1.Contract.NeoCounter Custom Methods
///
/// Processed:       2018-04-17 9:18:14 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.38328
/// NPC Project:     https://github.com/mwherman2000/neo-npcc/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.UserDirectory1.Contract
{
    public partial class NeoCounter
    {
        private static readonly byte[] DOMAINAC = "_AppCounters_".AsByteArray();

        public enum NeoCounters
        {
            UserCounter,
            PointCounter,
            UserPointsCounter,
            RequisitionCounter
        }

        public static BigInteger TakeNextNumber(NeoVersionedAppUser vau, NeoCounters counter)
        {
            NeoCounter nc = NeoCounter.GetElement(vau, DOMAINAC, (int)counter); // Get persisted counter value
            if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber", nc);

            if (NeoCounter.IsMissing(nc))
            {
                nc = NeoCounter.New(); // Create a new counter value
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber.putnew", nc);
                NeoCounter.PutElement(nc, vau, DOMAINAC, (int)counter); // Persist the new counter
            }
            else // Get and increment counter value by 1
            {
                BigInteger newNumber = NeoCounter.GetCurrentNumber(nc);
                if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("newNumber", newNumber);
                newNumber = newNumber + 1;
                if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("newNumber", newNumber);
                NeoCounter.SetCurrentNumber(nc, newNumber);
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber.putincr", nc);
                NeoCounter.PutElement(nc, vau, DOMAINAC, (int)counter); // Persist the new counter
            }

            return NeoCounter.GetCurrentNumber(nc);
        }

        public static BigInteger GetNextNumber(NeoVersionedAppUser vau, NeoCounters counter)
        {
            BigInteger result = -1;

            NeoCounter nc = NeoCounter.GetElement(vau, DOMAINAC, (int)counter); // Get persisted counter value
            if (!NeoCounter.IsMissing(nc))
            {
                result = NeoCounter.GetCurrentNumber(nc);
            }

            return result; // Return the current value for this counter
        }

        // Use case example: domain = user script hash, counter = NeoCounters.UserPointsCounter
        // TakeNextNumber semantics: return the current number and then advance the counter ...like at the grocery store
        public static BigInteger TakeNextNumber(NeoVersionedAppUser vau, byte[] domain, NeoCounters counter)
        {
            NeoCounter nc = NeoCounter.GetElement(vau, domain, (int)counter); // Get persisted counter value
            if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber", nc);

            if (NeoCounter.IsMissing(nc)) // Create persist the new counter entity
            {
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber.domain and counter is missing", nc);
                nc = NeoCounter.New(); // Create a new counter entity
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber.putnew", nc);
                NeoCounter.PutElement(nc, vau, domain, (int)counter); // Persist the new counter entity with a value of zero
            }

            if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber.exists", nc);
            BigInteger currentNextNumber = NeoCounter.GetCurrentNumber(nc);
            if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("currentNextNumber", currentNextNumber);
            BigInteger newNextNumber  = currentNextNumber + 1;
            if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("nextNumber", newNextNumber);
            NeoCounter.SetCurrentNumber(nc, newNextNumber);
            if (NeoTrace.VERBOSE) NeoCounter.LogExt("TakeNextNumber.putincr", nc);
            NeoCounter.PutElement(nc, vau, domain, (int)counter); // Persist the new counter

            return currentNextNumber;
        }

        public static BigInteger GetCurrentNextNumber(NeoVersionedAppUser vau, byte[] domain, NeoCounters counter)
        {
            BigInteger result = -1;

            NeoCounter nc = NeoCounter.GetElement(vau, domain, (int)counter); // Get persisted counter value
            if (!NeoCounter.IsMissing(nc))
            {
                result = NeoCounter.GetCurrentNumber(nc);
            }

            return result; // Return the current value for this counter
        }

        public static BigInteger GiveBackLastNumber(NeoVersionedAppUser vau, NeoCounters counter)
        {
            NeoCounter nc = NeoCounter.GetElement(vau, DOMAINAC, (int)counter); // Get persisted counter value
            if (NeoTrace.VERBOSE) NeoCounter.LogExt("GiveBackLastNumber", nc);

            if (NeoCounter.IsMissing(nc))
            {
                nc = NeoCounter.New(); // Create a new counter value
            }
            else // Get and decrement counter value by 1
            {
                BigInteger currentNumber = NeoCounter.GetCurrentNumber(nc);
                if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("currentNumber", currentNumber);
                currentNumber = currentNumber - 1;
                if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("currentNumber", currentNumber);
                NeoCounter.SetCurrentNumber(nc, currentNumber);
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("GiveBackLastNumber", nc);
                NeoCounter.PutElement(nc, vau, DOMAINAC, (int)counter); // Persist the incremented current value of the counter
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("GiveBackLastNumber", nc);
            }

            return NeoCounter.GetCurrentNumber(nc);
        }

        // Use case example: domain = user script hash, counter = NeoCounters.UserPointsCounter
        public static BigInteger GiveBackLastNumber(NeoVersionedAppUser vau, byte[] domain, NeoCounters counter)
        {
            NeoCounter nc = NeoCounter.GetElement(vau, domain, (int)counter); // Get persisted counter value
            if (NeoTrace.VERBOSE) NeoCounter.LogExt("GiveBackLastNumber", nc);

            if (NeoCounter.IsMissing(nc))
            {
                nc = NeoCounter.New(); // Create a new counter value
            }
            else // Get and decrement counter value by 1
            {
                BigInteger currentNumber = NeoCounter.GetCurrentNumber(nc);
                if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("currentNumber", currentNumber);
                currentNumber = currentNumber - 1;
                if (NeoTrace.VERBOSE) NeoTraceRuntime.TraceRuntime("currentNumber", currentNumber);
                NeoCounter.SetCurrentNumber(nc, currentNumber);
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("GiveBackLastNumber", nc);
                NeoCounter.PutElement(nc, vau, domain, (int)counter); // Persist the incremented current value of the counter
                if (NeoTrace.VERBOSE) NeoCounter.LogExt("GiveBackLastNumber", nc);
            }

            return NeoCounter.GetCurrentNumber(nc);
        }
    }
}
