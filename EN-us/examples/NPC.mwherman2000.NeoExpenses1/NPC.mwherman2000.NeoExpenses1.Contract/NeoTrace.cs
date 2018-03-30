using System;
using System.Collections.Generic;
using System.Linq;
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
/// NPC.Runtime.NeoTrace
///
/// Processed:       2018-03-07 7:15:18 PM by npcc - NEO Class Framework (NPC) 2.0 Compiler v1.0.0.0
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.Runtime
{
    public static class NeoTrace /* Level *all* */
    {
        public const bool TRACEON = true;
        public const bool SPLASH = true;
        public const bool ARGSRESULTS = true;
        public const bool RUNTIME = false;
        public const bool ERROR = true;
        public const bool WARNING = true;
        public const bool INFO = true;
        public const bool VERBOSE = false;
        public const bool TESTING = false;

        public static void LogExt()
        {
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("TRACEON", TRACEON);
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("SPLASH", SPLASH);
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("ARGSRESULTS", ARGSRESULTS);
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("RUNTIME", RUNTIME);
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("ERROR", ERROR);
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("WARNING", WARNING);
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("INFO", INFO);
            Neo.SmartContract.Framework.Services.Neo.Runtime.Notify("VERBOSE", VERBOSE);
        }

        public static void Trace(params object[] args)
        {
            if (NeoTrace.TRACEON) Neo.SmartContract.Framework.Services.Neo.Runtime.Notify(args);
        }
    }

    public class NeoTraceRuntime /* Level *all* */
    {
        public static void TraceRuntime(params object[] args)
        {
            if (NeoTrace.TRACEON) Neo.SmartContract.Framework.Services.Neo.Runtime.Notify(args);
        }
    }
}
