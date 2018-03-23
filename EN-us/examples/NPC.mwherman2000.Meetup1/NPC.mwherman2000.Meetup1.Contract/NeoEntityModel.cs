using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/*
    MIT License

    Copyright (c) 2018 Michael Herman (Toronto)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

/// <summary>
/// NPC.Runtime.NeoEntityModel
///
/// Processed:       2018-03-21 9:03:57 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.40151
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.Runtime 
{
    public static class NeoEntityModel /* Level 4 Collectible */
    {
        public enum EntityState
        {
            NULL, INIT, SET, PUTTED, GETTED, MISSING, TOMBSTONED, NOTAUTHORIZED /* Future Work*/
        }

        public static BigInteger AsBigInteger(this EntityState state)
        {
            int istate = (int)state;
            BigInteger bis = istate;
            return bis;
        }
        public static EntityState BytesToEntityState(byte[] bsta)
        {
            int ista = (int)bsta.AsBigInteger();
            NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
            return sta;
        }

        public static byte[] GetInvokingAddressScriptHash()
        {
            //return new byte[] { 0x01, 0x02, 0x03, 0x04 }; // neo-debugger debugging

            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            TransactionOutput[] refs = tx.GetReferences();
            foreach (TransactionOutput r in refs)
            {
                return r.ScriptHash;
            }
            return new byte[] { 0x0 };
        }

        public static readonly byte[] NullScriptHash = "".ToScriptHash();
        public static readonly byte[] NullByteArray = { 0x0 };
    }
}
