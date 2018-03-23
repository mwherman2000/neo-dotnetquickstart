using Neo.SmartContract.Framework;
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
/// NPC.Runtime.NeoStorageKey
///
/// Processed:       2018-03-21 9:03:57 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.40151
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.Runtime
{
    public enum ContractParameterTypeLocal : byte
    {
        Signature = 0,
        Boolean = 1,
        Integer = 2,
        Hash160 = 3,
        Hash256 = 4,
        ByteArray = 5,
        PublicKey = 6,
        String = 7,
        Array = 16,
        InteropInterface = 240,
        Void = 255
    }

    /// <summary>
    /// NeoStorageKey class
    /// Used to manage NeoStorageKeys (NSKs) and the serialization of NSKs into
    /// NeoStorageKey Object Notation (NSKON)
    /// </summary>
    public class NeoStorageKey : NeoTraceRuntime
    {
        private byte[] _app;
        private int _major;
        private int _minor;
        private int _build;
        private byte[] _userScriptHash;
        private byte[] _domain;
        private byte[] _className;
        private int _index;
        private byte[] _fieldName;
        private NeoEntityModel.EntityState _state;

        public static void SetAppName(NeoStorageKey nsk, byte[] value) { nsk._app = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetAppNameAsByteArray(NeoStorageKey nsk) { return nsk._app; }
        public static void SetAppName(NeoStorageKey nsk, string value) { nsk._app = value.AsByteArray(); nsk._state = NeoEntityModel.EntityState.SET; }
        public static string GetAppNameAsString(NeoStorageKey nsk) { return nsk._app.AsString(); }
        public static void SetMajor(NeoStorageKey nsk, int value) { nsk._major = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static int GetMajor(NeoStorageKey nsk) { return nsk._major; }
        public static void SetMinor(NeoStorageKey nsk, int value) { nsk._minor = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static int GetMinor(NeoStorageKey nsk) { return nsk._minor; }
        public static void SetBuild(NeoStorageKey nsk, int value) { nsk._build = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static int GetBuild(NeoStorageKey nsk) { return nsk._build; }
        //public static void SetRevision(NeoStorageKey nsk, int value) { nsk._revision = value; nsk._state = NeoEntityModel.EntityState.SET; }
        //public static int GetRevision(NeoStorageKey nsk) { return nsk._revision; }
        public static void SetUserScriptHash(NeoStorageKey nsk, byte[] value) { nsk._userScriptHash = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetUserScriptHash(NeoStorageKey nsk) { return nsk._userScriptHash; }
        public static void SetDomain(NeoStorageKey nsk, byte[] value) { nsk._domain = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetDomainAsByteArray(NeoStorageKey nsk) { return nsk._domain; }
        public static void SetDomain(NeoStorageKey nsk, string value) { nsk._domain = value.AsByteArray(); nsk._state = NeoEntityModel.EntityState.SET; }
        public static string GetDomainAsString(NeoStorageKey nsk) { return nsk._domain.AsString(); }
        public static void SetClassName(NeoStorageKey nsk, byte[] value) { nsk._className = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetClassNameAsByteArray(NeoStorageKey nsk) { return nsk._className; }
        public static void SetClassName(NeoStorageKey nsk, string value) { nsk._className = value.AsByteArray(); nsk._state = NeoEntityModel.EntityState.SET; }
        public static string GetClassNameAsString(NeoStorageKey nsk) { return nsk._className.AsString(); }
        public static void SetIndex(NeoStorageKey nsk, int value) { nsk._index = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static int GetIndex(NeoStorageKey nsk) { return nsk._index; }
        public static void SetFieldName(NeoStorageKey nsk, byte[] value) { nsk._fieldName = value; nsk._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetFieldName(NeoStorageKey nsk) { return nsk._fieldName; }
        public static void Set(NeoStorageKey nsk, byte[] app, int major, int minor, int build, /*int revision,*/ byte[] userScriptHash, byte[] domain, byte[] className, int index, byte[] fieldName)
        {
            nsk._app = app; nsk._major = major; nsk._minor = minor; nsk._build = build; /*nsk._revision = revision*/;
            nsk._userScriptHash = userScriptHash; nsk._domain = domain; nsk._className = className; nsk._index = index; nsk._fieldName = fieldName;
            nsk._state = NeoEntityModel.EntityState.SET;
        }
        public static void Set(NeoStorageKey nsk, string app, int major, int minor, int build, /*int revision,*/ byte[] userScriptHash, string domain, string className, int index, byte[] fieldName)
        {
            nsk._app = app.AsByteArray(); nsk._major = major; nsk._minor = minor; nsk._build = build; /*nsk._revision = revision*/;
            nsk._userScriptHash = userScriptHash; nsk._domain = domain.AsByteArray(); nsk._className = className.AsByteArray(); nsk._index = index; nsk._fieldName = fieldName;
            nsk._state = NeoEntityModel.EntityState.SET;
        }
        public static void Set(NeoStorageKey nsk, NeoVersionedAppUser vau, byte[] userScriptHash, byte[] domain, byte[] className, int index, byte[] fieldName)
        {
            nsk._major = NeoVersionedAppUser.GetMajor(vau); nsk._minor = NeoVersionedAppUser.GetMinor(vau); nsk._build = NeoVersionedAppUser.GetBuild(vau); /*nsk._revision = NeoVersionedAppUser.GetRevision(vau);*/
            nsk._userScriptHash = NeoVersionedAppUser.GetUserScriptHash(vau);
            nsk._domain = domain; nsk._className = className; nsk._index = index; nsk._fieldName = fieldName;
            nsk._state = NeoEntityModel.EntityState.SET;
        }
        public static void Set(NeoStorageKey nsk, NeoVersionedAppUser vau, byte[] userScriptHash, string domain, string className, int index, byte[] fieldName)
        {
            nsk._major = NeoVersionedAppUser.GetMajor(vau); nsk._minor = NeoVersionedAppUser.GetMinor(vau); nsk._build = NeoVersionedAppUser.GetBuild(vau); /*nsk._revision = NeoVersionedAppUser.GetRevision(vau);*/
            nsk._userScriptHash = NeoVersionedAppUser.GetUserScriptHash(vau);
            nsk._domain = domain.AsByteArray(); nsk._className = className.AsByteArray(); nsk._index = index; nsk._fieldName = fieldName;
            nsk._state = NeoEntityModel.EntityState.SET;
        }

        // Factory methods
        /// <summary>
        /// Prevents a default instance of the <see cref="NeoStorageKey"/> class from being created.
        /// </summary>
        private NeoStorageKey()
        {
        }

        private static NeoStorageKey _Initialize(NeoStorageKey nsk)
        {
            nsk._app = NeoEntityModel.NullByteArray;
            nsk._major = 0;
            nsk._minor = 0;
            nsk._build = 0;
            //nsk._revision = 0;
            nsk._userScriptHash = NeoEntityModel.NullScriptHash;
            nsk._domain = NeoEntityModel.NullByteArray;
            nsk._className = NeoEntityModel.NullByteArray;
            nsk._index = 0;
            nsk._fieldName = NeoEntityModel.NullByteArray;
            nsk._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(nsk).nsk", nsk);
            return nsk;
        }

        public static NeoStorageKey New()
        {
            NeoStorageKey nsk = new NeoStorageKey();
            _Initialize(nsk);
            if (NeoTrace.RUNTIME) LogExt("New().nsk", nsk);
            return nsk;
        }

        public static NeoStorageKey New(byte[] app, int major, int minor, int build, /*int revision,*/ byte[] userScriptHash, byte[] domain, byte[] className, int index, byte[] fieldName)
        {
            NeoStorageKey nsk = new NeoStorageKey();
            nsk._app = app;
            nsk._major = major;
            nsk._minor = minor;
            nsk._build = build;
            //nsk._revision = revision;
            nsk._userScriptHash = userScriptHash;
            nsk._domain = domain;
            nsk._className = className;
            nsk._index = index;
            nsk._fieldName = fieldName;
            nsk._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(ab,m,m,b,u,cb,i,f,s).nsk", nsk);
            return nsk;
        }

        public static NeoStorageKey New(NeoVersionedAppUser vau, byte[] domain, byte[] className)
        {
            if (NeoVersionedAppUser.IsNull(vau))
            {
                return NeoStorageKey.Null();
            }

            NeoStorageKey nsk = new NeoStorageKey();
            nsk._app = NeoVersionedAppUser.GetAppNameAsByteArray(vau);
            nsk._major = NeoVersionedAppUser.GetMajor(vau);
            nsk._minor = NeoVersionedAppUser.GetMinor(vau);
            nsk._build = NeoVersionedAppUser.GetBuild(vau);
            //nsk._revision = NeoVersionedAppUser.GetRevision(vau);
            nsk._userScriptHash = NeoVersionedAppUser.GetUserScriptHash(vau);
            nsk._domain = domain;
            nsk._className = className;
            nsk._index = 0;
            nsk._fieldName = NeoEntityModel.NullByteArray;
            nsk._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(vau,bc)", nsk);
            return nsk;
        }

        public static NeoStorageKey Null()
        {
            NeoStorageKey nsk = new NeoStorageKey();
            _Initialize(nsk);
            if (NeoTrace.RUNTIME) LogExt("Null().nsk", nsk);
            return nsk;
        }

        // EntityState wrapper methods

        public static bool IsNull(NeoStorageKey nsk)
        {
            return (nsk._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods

        public static void Log(string label, NeoStorageKey nsk)
        {
            TraceRuntime(label, nsk._app, nsk._major, nsk._minor, nsk._build, /*nsk._revision,*/ nsk._domain, nsk._className, nsk._index, nsk._fieldName, nsk._userScriptHash);
        }

        public static void LogExt(string label, NeoStorageKey nsk)
        {
            TraceRuntime(label, nsk._app, nsk._major, nsk._minor, nsk._build, /*nsk._revision,*/ nsk._domain, nsk._className, nsk._index, nsk._fieldName, nsk._userScriptHash, nsk._state); // long values, state, extension last
        }

        private static readonly byte[] _bLeftBrace = "{".AsByteArray();
        private static readonly byte[] _bRightBrace = "}".AsByteArray();
        private static readonly byte[] _bColon = ":".AsByteArray();
        private static readonly byte[] _bEquals = "=".AsByteArray();
        private static readonly byte[] _bSemiColon = ";".AsByteArray();
        private static readonly byte[] _ba = "a".AsByteArray(); // App name
        private static readonly byte[] _bM = "M".AsByteArray(); // App major version
        private static readonly byte[] _bm = "m".AsByteArray(); // App minor version
        private static readonly byte[] _bb = "b".AsByteArray(); // App build number
        //private static readonly byte[] _br = "r".AsByteArray(); // App revision number
        private static readonly byte[] _bu = "u".AsByteArray(); // User script hash
        private static readonly byte[] _bd = "d".AsByteArray(); // Domain name
        private static readonly byte[] _bc = "c".AsByteArray(); // Class name
        private static readonly byte[] _bi = "i".AsByteArray(); // Index value
        private static readonly byte[] _bf = "f".AsByteArray(); // Field name

        private static readonly byte[] _bStringType = { (byte)ContractParameterTypeLocal.String };
        private static readonly byte[] _bBigIntegerType = { (byte)ContractParameterTypeLocal.Integer };
        private static readonly byte[] _bByteArrayType = { (byte)ContractParameterTypeLocal.ByteArray };
        private static readonly byte[] _bUserScriptHashType = { (byte)ContractParameterTypeLocal.ByteArray };

        public static byte[] StorageKey(NeoStorageKey nsk, byte[] bindex, byte[] fieldName)
        {
            if (NeoTrace.RUNTIME) LogExt("StorageKey(nsk,bi,bf).nsk", nsk);
            if (NeoTrace.RUNTIME) TraceRuntime("StorageKey(nsk,bi,bf).nsk", bindex, fieldName);

            byte[] bkey = Helper.Concat(_bLeftBrace, _ba).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(nsk._app).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bM).Concat(_bColon).Concat(_bBigIntegerType)
                                        .Concat(_bEquals).Concat(((BigInteger)(nsk._major)).AsByteArray()).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bm).Concat(_bColon).Concat(_bBigIntegerType)
                                        .Concat(_bEquals).Concat(((BigInteger)(nsk._minor)).AsByteArray()).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bb).Concat(_bColon).Concat(_bBigIntegerType)
                                        .Concat(_bEquals).Concat(((BigInteger)(nsk._build)).AsByteArray()).Concat(_bSemiColon);
            //bkey = Helper.Concat(bkey, _br).Concat(_bColon).Concat(_bBigIntegerType)
            //                          .Concat(_bEquals).Concat(((BigInteger)(nsk._revision)).AsByteArray()).Concat(_bComma);
            bkey = Helper.Concat(bkey, _bu).Concat(_bColon).Concat(_bUserScriptHashType)
                                        .Concat(_bEquals).Concat(nsk._userScriptHash).Concat(_bSemiColon);

            bkey = Helper.Concat(bkey, _bd).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(nsk._domain).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bc).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(nsk._className).Concat(_bSemiColon);

            bkey = Helper.Concat(bkey, _bi).Concat(_bColon).Concat(_bByteArrayType)
                                        .Concat(_bEquals).Concat(bindex).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bf).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(fieldName).Concat(_bSemiColon);

            bkey = Helper.Concat(bkey, _bRightBrace);

            if (NeoTrace.RUNTIME) TraceRuntime("StorageKey(nsk,bi,bf).bkey$BSK", bkey);
            return bkey;
        }

        public static byte[] StorageKey(NeoStorageKey nsk, int index, byte[] fieldName)
        {
            if (NeoTrace.RUNTIME) LogExt("StorageKey(nsk,i,bf).nsk", nsk);
            if (NeoTrace.RUNTIME) TraceRuntime("StorageKey(nsk,i,bf).nsk", index, fieldName);

            byte[] bkey = Helper.Concat(_bLeftBrace, _ba).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(nsk._app).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bM).Concat(_bColon).Concat(_bBigIntegerType)
                                        .Concat(_bEquals).Concat(((BigInteger)(nsk._major)).AsByteArray()).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bm).Concat(_bColon).Concat(_bBigIntegerType)
                                        .Concat(_bEquals).Concat(((BigInteger)(nsk._minor)).AsByteArray()).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bb).Concat(_bColon).Concat(_bBigIntegerType)
                                        .Concat(_bEquals).Concat(((BigInteger)(nsk._build)).AsByteArray()).Concat(_bSemiColon);
            //bkey = Helper.Concat(bkey, _br).Concat(_bColon).Concat(_bBigIntegerType)
            //                          .Concat(_bEquals).Concat(((BigInteger)(nsk._revision)).AsByteArray()).Concat(_bComma);
            bkey = Helper.Concat(bkey, _bu).Concat(_bColon).Concat(_bUserScriptHashType)
                                        .Concat(_bEquals).Concat(nsk._userScriptHash).Concat(_bSemiColon);

            bkey = Helper.Concat(bkey, _bd).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(nsk._domain).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bc).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(nsk._className).Concat(_bSemiColon);

            bkey = Helper.Concat(bkey, _bi).Concat(_bColon).Concat(_bBigIntegerType)
                                        .Concat(_bEquals).Concat(((BigInteger)index).AsByteArray()).Concat(_bSemiColon);
            bkey = Helper.Concat(bkey, _bf).Concat(_bColon).Concat(_bStringType)
                                        .Concat(_bEquals).Concat(fieldName).Concat(_bSemiColon);

            bkey = Helper.Concat(bkey, _bRightBrace);

            if (NeoTrace.RUNTIME) TraceRuntime("StorageKey(nsk,i,bf).bkey$BSK", bkey);
            return bkey;
        }
    }
}