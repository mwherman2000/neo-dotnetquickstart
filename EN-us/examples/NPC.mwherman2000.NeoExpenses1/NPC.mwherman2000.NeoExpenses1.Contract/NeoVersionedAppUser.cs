using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.Runtime.NeoVersionedAppUser
///
/// Processed:        2018-03-29 8:40:07 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.34983
/// NPC Project:    https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.Runtime
{
    /// <summary>
    /// NeoVersionedAppUser class
    /// Class used to support the efficient creation and management of <c>NeoStorageKeys</c>
    /// </summary>
    public class NeoVersionedAppUser : NeoTraceRuntime
    {
        private byte[] _app;
        private int _major;
        private int _minor;
        private int _build;
        //private int _revision;
        private byte[] _userScriptHash;
        private NeoEntityModel.EntityState _state;

        public static void SetAppName(NeoVersionedAppUser vau, byte[] value) { vau._app = value; vau._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetAppNameAsByteArray(NeoVersionedAppUser vau) { return vau._app; }
        public static void SetAppName(NeoVersionedAppUser vau, string value) { vau._app = value.AsByteArray(); vau._state = NeoEntityModel.EntityState.SET; }
        public static string GetAppNameAsString(NeoVersionedAppUser vau) { return vau._app.AsString(); }
        public static void SetMajor(NeoVersionedAppUser vau, int value) { vau._major = value; vau._state = NeoEntityModel.EntityState.SET; }
        public static int GetMajor(NeoVersionedAppUser vau) { return vau._major; }
        public static void SetMinor(NeoVersionedAppUser vau, int value) { vau._minor = value; vau._state = NeoEntityModel.EntityState.SET; }
        public static int GetMinor(NeoVersionedAppUser vau) { return vau._minor; }
        public static void SetBuild(NeoVersionedAppUser vau, int value) { vau._build = value; vau._state = NeoEntityModel.EntityState.SET; }
        public static int GetBuild(NeoVersionedAppUser vau) { return vau._build; }
        //public static void SetRevision(NeoVersionedAppUser vau, int value) { vau._revision = value; vau._state = NeoEntityModel.EntityState.SET; }
        //public static int GetRevision(NeoVersionedAppUser vau) { return vau._revision; }
        public static void SetUserScriptHash(NeoVersionedAppUser vau, byte[] value) { vau._userScriptHash = value; vau._state = NeoEntityModel.EntityState.SET; }
        public static byte[] GetUserScriptHash(NeoVersionedAppUser vau) { return vau._userScriptHash; }
        public static void Set(NeoVersionedAppUser vau, byte[] app, int major, int minor, int build, /*int revision,*/ byte[] userScriptHash)
        {
            vau._app = app; vau._major = major; vau._minor = minor; vau._build = build; /*vau._revision = revision;*/
            vau._userScriptHash = userScriptHash; vau._state = NeoEntityModel.EntityState.SET;
        }
        public static void Set(NeoVersionedAppUser vau, string app, int major, int minor, int build, /*int revision,*/ byte[] userScriptHash)
        {
            vau._app = app.AsByteArray(); vau._major = major; vau._minor = minor; vau._build = build; /*vau._revision = revision;*/
            vau._userScriptHash = userScriptHash; vau._state = NeoEntityModel.EntityState.SET;
        }

        // Factory methods

        /// <summary>
        /// Prevents a default instance of the <see cref="NeoVersionedAppUser"/> class from being created.
        /// </summary>
        private NeoVersionedAppUser()
        {
        }

        /// <summary>
        /// Initializes the specified vau.
        /// </summary>
        /// <param name="vau">vau</param>
        /// <returns>NeoVersionedAppUser</returns>
        private static NeoVersionedAppUser _Initialize(NeoVersionedAppUser vau)
        {
            vau._app = NeoEntityModel.NullByteArray;
            vau._major = 0;
            vau._minor = 0;
            vau._build = 0;
            //vau._revision = 0;
            vau._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(vau).vau", vau);
            return vau;
        }

        /// <summary>
        /// News this instance.
        /// </summary>
        /// <returns>NeoVersionedAppUser</returns>
        public static NeoVersionedAppUser New()
        {
            NeoVersionedAppUser vau = new NeoVersionedAppUser();
            _Initialize(vau);
            if (NeoTrace.RUNTIME) LogExt("New().vau", vau);
            return vau;
        }

        /// <summary>
        /// News the specified application.
        /// </summary>
        /// <param name="app">application</param>
        /// <param name="major">major</param>
        /// <param name="minor">minor</param>
        /// <param name="build">build</param>
        /// <param name="userScriptHash">userScriptHash</param>
        /// <returns>NeoVersionedAppUser</returns>
        public static NeoVersionedAppUser New(byte[] app, int major, int minor, int build, /*int revision,*/ byte[] userScriptHash)
        {
            NeoVersionedAppUser vau = new NeoVersionedAppUser();
            vau._app = app; ;
            vau._major = major;
            vau._minor = minor;
            vau._build = build;
            //vau._revision = revision;
            vau._userScriptHash = userScriptHash;
            vau._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(ba,m,m,b,u).vau", vau);
            return vau;
        }

        /// <summary>
        /// News the specified application.
        /// </summary>
        /// <param name="app">application</param>
        /// <param name="major">major</param>
        /// <param name="minor">minor</param>
        /// <param name="build">build</param>
        /// <param name="userScriptHash">userScriptHash</param>
        /// <returns>NeoVersionedAppUser</returns>
        public static NeoVersionedAppUser New(string app, int major, int minor, int build, /*int revision,*/ byte[] userScriptHash)
        {
            NeoVersionedAppUser vau = new NeoVersionedAppUser();
            vau._app = app.AsByteArray();
            vau._major = major;
            vau._minor = minor;
            vau._build = build;
            //vau._revision = revision;
            vau._userScriptHash = userScriptHash;
            vau._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(sa,m,m,b,u).vau", vau);
            return vau;
        }

        /// <summary>
        /// Create a new entity representing a Null entity
        /// </summary>
        /// <returns>NeoVersionedAppUser</returns>
        public static NeoVersionedAppUser Null()
        {
            NeoVersionedAppUser vau = new NeoVersionedAppUser();
            _Initialize(vau);
            if (NeoTrace.RUNTIME) LogExt("Null().vau", vau);
            return vau;
        }

        // EntityState wrapper methods

        /// <summary>
        /// Test whether the specified NeoVersionedAppUser is Null.
        /// </summary>
        /// <param name="vau">vau</param>
        /// <returns>
        ///   <c>true</c> if the specified vau is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(NeoVersionedAppUser vau)
        {
            return (vau._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        /// <summary>
        /// Logs the specified label.
        /// </summary>
        /// <param name="label">label</param>
        /// <param name="vau">vau</param>
        /// <returns>void</returns>
        public static void Log(string label, NeoVersionedAppUser vau)
        {
            TraceRuntime(label, vau._app, vau._major, vau._minor, vau._build, /*vau._revision,*/ vau._userScriptHash);
        }

        /// <summary>
        /// Logs the ext.
        /// </summary>
        /// <param name="label">label</param>
        /// <param name="vau">vau</param>
        /// <returns>void</returns>
        public static void LogExt(string label, NeoVersionedAppUser vau)
        {
            TraceRuntime(label, vau._app, vau._major, vau._minor, vau._build, /*vau._revision,*/ vau._userScriptHash, vau._state); // long values, state, extension last
        }
    }
}
