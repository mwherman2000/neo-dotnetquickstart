using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using NPC.Runtime;
using System;
using System.Numerics;

namespace NPC.mwherman2000.NeoExpenses1.Contract
{
    public class NPCNEP5RequisitionContract : SmartContract
    {
        public static readonly byte[] OwnerAccountScriptHash = "ATrzHaicmhRj15C3Vv6e6gLfLqhSD2PtTr".ToScriptHash();

        public static object Main(string operation, params object[] args)
        {
            object result = false;

            NeoVersionedAppUser AppVAU = NeoVersionedAppUser.New("NPC.mwherman2000.NeoExpenses1.Contract", 1, 1, 1, "7074acf3f06dd3f456e11053ebf61c5b04b07ebc".AsByteArray()); // DEBUG ONLY
            if (NeoTrace.TESTING) NeoVersionedAppUser.LogExt("AppVAU", AppVAU);

            NPCNEP5Base tokenBase = NPCNEP5Base.New("My Meetup Token", "MMT", 8, 1000000); 
            if (NeoTrace.VERBOSE) NPCNEP5Base.Log("tokenBase", tokenBase);

            result = ProcessOperation(AppVAU, tokenBase, operation, args);

            if (NeoTrace.VERBOSE) NeoTrace.Trace("result", result);

            return result;
        }

        public static object ProcessOperation(NeoVersionedAppUser AppVAU, NPCNEP5Base tokenBase, string operation, object[] args)
        {
            object result = false;

            if (NeoTrace.VERBOSE) NeoTrace.Trace("operation", operation);

            if (operation == "deploy") result = deploy(tokenBase);
            else if (operation == "ping") result = ping();

            else if (operation == "name") result = name(tokenBase);
            else if (operation == "symbol") result = symbol(tokenBase);
            else if (operation == "decimals") result = decimals(tokenBase);
            else if (operation == "totalSupply") result = totalSupply(tokenBase);
            else if (operation == "balanceOf")
            {
                byte[] account = (byte[])args[0];
                if (NeoTrace.TESTING && account[0] == 0x0) // DEBUGGING
                {
                    account = OwnerAccountScriptHash;
                    if (NeoTrace.VERBOSE) NeoTrace.Trace("DEBUGGING:from", account);
                }
                result = balanceOf(account);
            }
            else if (operation == "transfer")
            {
                if (args.Length == 3)
                {
                    // https://github.com/neo-project/examples-csharp/blob/master/ICO_Template/ICO_Template.cs#L59
                    byte[] from = (byte[])args[0];
                    byte[] to = (byte[])args[1];
                    BigInteger amount = (BigInteger)args[2];
                    if (NeoTrace.TESTING && from[0] == 0x0) // DEBUGGING
                    {
                        from = OwnerAccountScriptHash;
                        if (NeoTrace.VERBOSE) NeoTrace.Trace("DEBUGGING:from", from);
                    }
                    result = transfer(from, to, amount);
                }
            }
            else if (operation == "allowance")
            {
                byte[] from = (byte[])args[0];
                byte[] to = (byte[])args[1];
                if (NeoTrace.TESTING && from[0] == 0x0) // DEBUGGING
                {
                    from = OwnerAccountScriptHash;
                    if (NeoTrace.VERBOSE) NeoTrace.Trace("DEBUGGING:from", from);
                }
                result = allowance(from, to); // optional
            }
            else if (operation == "transferFrom")
            {
                byte[] originator = OwnerAccountScriptHash;
                byte[] from = (byte[])args[0];
                byte[] to = (byte[])args[1];
                BigInteger amount = (BigInteger)args[2];
                if (NeoTrace.TESTING && originator[0] == 0x0) // DEBUGGING
                {
                    originator = OwnerAccountScriptHash;
                    if (NeoTrace.VERBOSE) NeoTrace.Trace("DEBUGGING:originator", originator);
                }
                result = transferFrom(originator, from, to, amount); // optional
            }
            else if (operation == "approve")
            {
                byte[] originator = OwnerAccountScriptHash;
                byte[] to = (byte[])args[0];
                BigInteger amount = (BigInteger)args[1];
                if (NeoTrace.TESTING && originator[0] == 0x0) // DEBUGGING
                {
                    originator = OwnerAccountScriptHash;
                    if (NeoTrace.VERBOSE) NeoTrace.Trace("DEBUGGING:originator", originator);
                }
                result = approve(originator, to, amount); // optional
            }
            else if (operation == "createUser")
            {
                result = UserCredentials.CreateUser(AppVAU, args);
            }
            else if (operation == "getUser")
            {
                result = UserCredentials.GetUser(AppVAU, args);
            }
            //else if (operation == "getUsers")
            //{
            //    result = UserCredentials.GetUsers(AppVAU, args);
            //}
            else if (operation == "CreateContributor")
            {
                result = NPCContributor.CreateContributor(AppVAU, args);
            }
            else if (operation == "getContributor")
            {
                result = NPCContributor.GetContributor(AppVAU, args);
            }
            //else if (operation == "getContributors")
            //{
            //    result = NPCContributor.GetContributors(AppVAU, args);
            //}
            else if (operation == "createRequisition")
            {
                result = NPCNEP5Requisition.CreateRequisition(AppVAU, args);
            }
            else if (operation == "submitRequisition")
            {
                result = NPCNEP5Requisition.SubmitRequisition(AppVAU, args);
            }
            else if (operation == "getContributorRequisitions")
            {
                result = NPCNEP5Requisition.GetContributorRequisitions(AppVAU, args);
            }
            else if (operation == "updateRequisition")
            {
                result = NPCNEP5Requisition.UpdateRequisition(AppVAU, args);
            }
            else if (operation == "payRequisition")
            {
                result = NPCNEP5Requisition.PayRequisition(AppVAU, args);
            }
            else
            {
                if (NeoTrace.INFO) NeoTrace.Trace("Unknown operation", operation);
                string message = "unknown operation '" + operation + "'";
                if (NeoTrace.ERROR) NeoTrace.Trace("**ERROR** operation", message);
                result = false;
            }

            if (NeoTrace.VERBOSE) NeoTrace.Trace("result", result);

            return result;
        }

        public static event Action<byte[], byte[], BigInteger> Transfer;

        public static BigInteger totalSupply(NPCNEP5Base tokenBase)
        {
            BigInteger totalSupply = NPCNEP5Base.GetTotalSupply(tokenBase);

            if (NeoTrace.VERBOSE) NeoTrace.Trace("totalSupply():entered$INT", totalSupply);

            return totalSupply;
        }

        public static string name(NPCNEP5Base tokenBase)
        {
            string name = NPCNEP5Base.GetName(tokenBase);

            if (NeoTrace.VERBOSE) NeoTrace.Trace("name():entered" , name);

            return name;
        }

        public static string symbol(NPCNEP5Base tokenBase)
        {
            string symbol = NPCNEP5Base.GetSymbol(tokenBase);

            if (NeoTrace.VERBOSE) NeoTrace.Trace("symbol():entered", symbol);

            return symbol;
        }

        public static byte decimals(NPCNEP5Base tokenBase)
        {
            byte decimals = (byte)NPCNEP5Base.GetDecimals(tokenBase);

            if (NeoTrace.VERBOSE) NeoTrace.Trace("decimals():entered", decimals);

            return decimals;
        }

        public static BigInteger balanceOf(byte[] account)
        {
            BigInteger balance = (BigInteger)0;

            if (NeoTrace.VERBOSE) NeoTrace.Trace("balanceOf():entered");

            NPCNEP5LedgerEntry accountLedgerEntry = NPCNEP5LedgerEntry.Get(account);
            if (NeoTrace.VERBOSE) NPCNEP5LedgerEntry.Log("balanceOf().ledgerEntry", accountLedgerEntry);
            if (!NPCNEP5LedgerEntry.IsMissing(accountLedgerEntry))
            {
                if (NeoTrace.VERBOSE) NeoTrace.Trace("accountLedgerEntry is not Missing");
                balance = NPCNEP5LedgerEntry.GetBalance(accountLedgerEntry);
            }

            return balance;
        }

        public static bool transfer(byte[] from, byte[] to, BigInteger amount)
        {
            bool result = false;

            if (NeoTrace.VERBOSE) NeoTrace.Trace("transfer():entered", from, to, amount);

            // https://github.com/neo-project/examples-csharp/blob/master/ICO_Template/ICO_Template.cs#L146

            if (amount > 0)
            {
                if (NeoTrace.VERBOSE) NeoTrace.Trace("transfer():amount > 0");
                //if (Neo.SmartContract.Framework.Services.Neo.Runtime.CheckWitness(from))
                {
                    if (from == to)
                    {
                        if (NeoTrace.VERBOSE) NeoTrace.Trace("transfer():from == to");
                        result = true;
                    }
                    else
                    {
                        if (NeoTrace.VERBOSE) NeoTrace.Trace("transfer():from != to");
                        NPCNEP5LedgerEntry fromLedgerEntry = NPCNEP5LedgerEntry.Get(from);
                        if (NeoTrace.VERBOSE) NPCNEP5LedgerEntry.Log("transfer().fromLedgerEntry", fromLedgerEntry);
                        BigInteger fromBalance = NPCNEP5LedgerEntry.GetBalance(fromLedgerEntry);
                        if (fromBalance >= amount)
                        {
                            if (NeoTrace.VERBOSE) NeoTrace.Trace("transfer():fromBalance >= amount");
                            //NPCEnvironment env = NPCEnvironment.New();
                            //NPCEnvironment.Initialize(env);
                            //BigInteger timestamp = NPCEnvironment.GetBlockTimestamp(env);

                            //uint h = Blockchain.GetHeight();
                            //Header header = Blockchain.GetHeader(h);
                            //BigInteger timestamp = header.Timestamp;
                            //Block block = Blockchain.GetBlock(h); // NEO Debugger: not implemented
                            //BigInteger timestamp = block.Timestamp;

                            BigInteger timestamp = 0;

                            NPCNEP5LedgerEntry.Set(fromLedgerEntry, timestamp, 0-amount, fromBalance - amount);
                            NPCNEP5LedgerEntry.Put(fromLedgerEntry, from);
                            if (NeoTrace.VERBOSE) NPCNEP5LedgerEntry.Log("transfer().fromLedgerEntry", fromLedgerEntry);

                            NPCNEP5LedgerEntry toLedgerEntry = NPCNEP5LedgerEntry.Get(to);
                            if (NeoTrace.VERBOSE) NPCNEP5LedgerEntry.Log("transfer().toLedgerEntry", toLedgerEntry);
                            BigInteger toBalance = NPCNEP5LedgerEntry.GetBalance(toLedgerEntry);

                            NPCNEP5LedgerEntry.Set(toLedgerEntry, timestamp, 0+amount, toBalance + amount);
                            NPCNEP5LedgerEntry.Put(toLedgerEntry, to);
                            if (NeoTrace.VERBOSE) NPCNEP5LedgerEntry.Log("transfer().toLedgerEntry", toLedgerEntry);

                            Transfer(from, to, amount);
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        public static BigInteger allowance(byte[] from, byte[] to) // optional
        {
            BigInteger balance = (BigInteger)0;

            if (NeoTrace.VERBOSE) NeoTrace.Trace("allowance():not implemented");

            return balance;
        }

        public static bool transferFrom(byte[] originator, byte[] from, byte[] to, BigInteger amount) // optional
        {
            bool result = false;

            if (NeoTrace.VERBOSE) NeoTrace.Trace("transferFrom():not implemented");

            return result;
        }

        public static bool approve(byte[] originator, byte[] to, BigInteger amount) // optional
        {
            bool result = false;

            if (NeoTrace.VERBOSE) NeoTrace.Trace("approve():not implemented");

            return result;
        }

        public static bool deploy(NPCNEP5Base tokenbase)
        {
            bool result = false;

            if (NeoTrace.VERBOSE) NeoTrace.Trace("deploy():entered");

            NPCEnvironment env = NPCEnvironment.New();
            NPCEnvironment.Initialize(env);

            NPCNEP5LedgerEntry ownerLedgerEntry = NPCNEP5LedgerEntry.Get(OwnerAccountScriptHash);
            if (NeoTrace.VERBOSE) NPCNEP5LedgerEntry.Log("deploy().ownerLedgerEntry", ownerLedgerEntry);
            if (NPCNEP5LedgerEntry.IsMissing(ownerLedgerEntry))
            {
                if (NeoTrace.VERBOSE) NeoTrace.Trace("ownerLedgerEntry is Missing");
                NPCNEP5LedgerEntry.Set(ownerLedgerEntry, 
                                        NPCEnvironment.GetBlockTimestamp(env), 0, NPCNEP5Base.GetTotalSupply(tokenbase));
                NPCNEP5LedgerEntry.Put(ownerLedgerEntry, OwnerAccountScriptHash);
                if (NeoTrace.VERBOSE) NPCNEP5LedgerEntry.Log("deploy().ownerLedgerEntry", ownerLedgerEntry);
                result = true;
            }

            return result;
        }

        public static string ping()
        {
            string result = "pong";

            if (NeoTrace.VERBOSE) NeoTrace.Trace("ping():entered", result);

            return result;
        }
    }
}
