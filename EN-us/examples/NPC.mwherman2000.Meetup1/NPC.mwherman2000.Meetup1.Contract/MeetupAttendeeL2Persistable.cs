using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.Meetup1.Contract.MeetupAttendee - Level 2 Persistable
///
/// Processed:       2018-03-21 9:03:57 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.40151
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.Meetup1.Contract
{
    public partial class MeetupAttendee : NeoTraceRuntime /* Level 2 Persistable */
    {
        // Class name and property names
        private const string _className = "MeetupAttendee";
        private static readonly byte[] _bClassName = _className.AsByteArray();

        private const string _sAttendeeName = "AttendeeName"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bAttendeeName = Helper.AsByteArray(_sAttendeeName);
        private const string _sAttendeeID = "AttendeeID"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bAttendeeID = Helper.AsByteArray(_sAttendeeID);
        private const string _sAttendeeUrl = "AttendeeUrl"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bAttendeeUrl = Helper.AsByteArray(_sAttendeeUrl);
        private const string _sAttendeePhotoUrl = "AttendeePhotoUrl"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bAttendeePhotoUrl = Helper.AsByteArray(_sAttendeePhotoUrl);
        private const string _sMeetingID = "MeetingID"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bMeetingID = Helper.AsByteArray(_sMeetingID);
        private const string _sMeetingUrl = "MeetingUrl"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bMeetingUrl = Helper.AsByteArray(_sMeetingUrl);
        private const string _sAttended = "Attended"; // Template: NPCLevel2AFieldConsts_cs.txt
        private static readonly byte[] _bAttended = Helper.AsByteArray(_sAttended);
        private const string _sSTA = "_STA"; // Template: NPCLevel2BMissing_cs.txt
        private static readonly byte[] _bSTA = Helper.AsByteArray(_sSTA);

        private const string _sEXT = "_EXT";
        private static readonly byte[] _bEXT = Helper.AsByteArray(_sEXT);
        
        // Internal fields
        private const string _classKeyTag = "/#" + _className + ".";
        private static readonly byte[] _bclassKeyTag = Helper.AsByteArray(_classKeyTag);
 
        // Persistable methods
        public static bool IsMissing(MeetupAttendee e)
        {
            return (e._state == NeoEntityModel.EntityState.MISSING);
        }

        public static MeetupAttendee Missing()
        {
            MeetupAttendee e = new MeetupAttendee();
            e._attendeeName = ""; e._attendeeID = ""; e._attendeeUrl = ""; e._attendeePhotoUrl = ""; e._meetingID = ""; e._meetingUrl = ""; e._attended = 0; 
            e._state = NeoEntityModel.EntityState.MISSING;
            if (NeoTrace.RUNTIME) LogExt("Missing().MeetupAttendee", e);
            return e;
        }

        public static bool Put(MeetupAttendee e, byte[] key)
        {
            if (key.Length == 0) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeeName), e._attendeeName); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeeID), e._attendeeID); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeeUrl), e._attendeeUrl); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeePhotoUrl), e._attendeePhotoUrl); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bMeetingID), e._meetingID); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bMeetingUrl), e._meetingUrl); // Template: NPCLevel2CPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttended), e._attended); // Template: NPCLevel2CPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(bkey).MeetupAttendee", e); // Template: NPCLevel2DPut_cs.txt
            return true;
        }

        public static bool Put(MeetupAttendee e, string key)
        {
            if (key.Length == 0) return false;
            if (NeoTrace.RUNTIME) LogExt("Put(skey).MeetupAttendee", e);

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey)._skeyTag", _skeyTag);

            e._state = NeoEntityModel.EntityState.PUTTED;
            BigInteger bis = e._state.AsBigInteger();
            if (NeoTrace.RUNTIME) TraceRuntime("Put(skey).bis", bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, bis);
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeeName, e._attendeeName); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeeID, e._attendeeID); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeeUrl, e._attendeeUrl); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeePhotoUrl, e._attendeePhotoUrl); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sMeetingID, e._meetingID); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sMeetingUrl, e._meetingUrl); // Template: NPCLevel2EPut_cs.txt
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttended, e._attended); // Template: NPCLevel2EPut_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Put(skey).MeetupAttendee", e); // Template: NPCLevel2FGet_cs.txt
            return true;
        }

        public static MeetupAttendee Get(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            MeetupAttendee e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = MeetupAttendee.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new MeetupAttendee();

                string AttendeeName = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bAttendeeName)).AsString(); //NPCLevel2GGet_cs.txt
                string AttendeeID = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bAttendeeID)).AsString(); //NPCLevel2GGet_cs.txt
                string AttendeeUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bAttendeeUrl)).AsString(); //NPCLevel2GGet_cs.txt
                string AttendeePhotoUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bAttendeePhotoUrl)).AsString(); //NPCLevel2GGet_cs.txt
                string MeetingID = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bMeetingID)).AsString(); //NPCLevel2GGet_cs.txt
                string MeetingUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bMeetingUrl)).AsString(); //NPCLevel2GGet_cs.txt
                BigInteger Attended = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bAttended)).AsBigInteger(); //NPCLevel2GGet_cs.txt
                e._attendeeName = AttendeeName; e._attendeeID = AttendeeID; e._attendeeUrl = AttendeeUrl; e._attendeePhotoUrl = AttendeePhotoUrl; e._meetingID = MeetingID; e._meetingUrl = MeetingUrl; e._attended = Attended;  // Template: NPCLevel2HGet_cs.txt
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).MeetupAttendee", e);
            return e;
        }

        public static MeetupAttendee Get(string key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            MeetupAttendee e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).MeetupAttendee.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = MeetupAttendee.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                e = new MeetupAttendee();

                string AttendeeName = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sAttendeeName).AsString(); //NPCLevel2IGet_cs.txt
                string AttendeeID = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sAttendeeID).AsString(); //NPCLevel2IGet_cs.txt
                string AttendeeUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sAttendeeUrl).AsString(); //NPCLevel2IGet_cs.txt
                string AttendeePhotoUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sAttendeePhotoUrl).AsString(); //NPCLevel2IGet_cs.txt
                string MeetingID = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sMeetingID).AsString(); //NPCLevel2IGet_cs.txt
                string MeetingUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sMeetingUrl).AsString(); //NPCLevel2IGet_cs.txt
                BigInteger Attended = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sAttended).AsBigInteger(); //NPCLevel2IGet_cs.txt
                if (NeoTrace.RUNTIME) TraceRuntime("Get(skey).e._attendeeName, e._attendeeID, e._attendeeUrl, e._attendeePhotoUrl, e._meetingID, e._meetingUrl, e._attended", e._attendeeName, e._attendeeID, e._attendeeUrl, e._attendeePhotoUrl, e._meetingID, e._meetingUrl, e._attended); // Template: NPCLevel2Part2_cs.txt
                e._attendeeName = AttendeeName; e._attendeeID = AttendeeID; e._attendeeUrl = AttendeeUrl; e._attendeePhotoUrl = AttendeePhotoUrl; e._meetingID = MeetingID; e._meetingUrl = MeetingUrl; e._attended = Attended; 
                e._state = sta;
                e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
            }
            if (NeoTrace.RUNTIME) LogExt("Get(skey).MeetupAttendee", e);
            return e;
        }
    }
}