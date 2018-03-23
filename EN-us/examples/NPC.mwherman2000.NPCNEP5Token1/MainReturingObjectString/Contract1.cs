using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace MainReturingObjectString
{
    public class Contract1 : SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            object result = false;

            result = ping();

            return result;
        }

        public static string ping()
        {
            string result = "pong";

            return result;
        }
    }
}
