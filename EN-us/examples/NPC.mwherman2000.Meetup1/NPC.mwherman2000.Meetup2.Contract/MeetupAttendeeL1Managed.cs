using NPC.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.Meetup2.Contract.MeetupAttendee - Level 1 Managed
///
/// Processed:       2018-03-21 9:15:47 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.40151
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.Meetup2.Contract
{
    public partial class MeetupAttendee : NeoTraceRuntime /* Level 1 Managed */
    {
        private NeoEntityModel.EntityState _state;

        // Hidden constructor
        private MeetupAttendee()
        {
        }

        // Accessors

        public static void SetAttendeeName(MeetupAttendee e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._attendeeName = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetAttendeeName(MeetupAttendee e) { return e._attendeeName; }
        public static void SetAttendeeID(MeetupAttendee e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._attendeeID = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetAttendeeID(MeetupAttendee e) { return e._attendeeID; }
        public static void SetAttendeeUrl(MeetupAttendee e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._attendeeUrl = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetAttendeeUrl(MeetupAttendee e) { return e._attendeeUrl; }
        public static void SetAttendeePhotoUrl(MeetupAttendee e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._attendeePhotoUrl = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetAttendeePhotoUrl(MeetupAttendee e) { return e._attendeePhotoUrl; }
        public static void SetMeetingID(MeetupAttendee e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._meetingID = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetMeetingID(MeetupAttendee e) { return e._meetingID; }
        public static void SetMeetingUrl(MeetupAttendee e, string value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._meetingUrl = value; e._state = NeoEntityModel.EntityState.SET; }
        public static string GetMeetingUrl(MeetupAttendee e) { return e._meetingUrl; }
        public static void SetAttended(MeetupAttendee e, BigInteger value) // Template: NPCLevel1SetXGetX_cs.txt
                               { e._attended = value; e._state = NeoEntityModel.EntityState.SET; }
        public static BigInteger GetAttended(MeetupAttendee e) { return e._attended; }
        public static void Set(MeetupAttendee e, string AttendeeName, string AttendeeID, string AttendeeUrl, string AttendeePhotoUrl, string MeetingID, string MeetingUrl, BigInteger Attended) // Template: NPCLevel1Set_cs.txt
                                { e._attendeeName = AttendeeName; e._attendeeID = AttendeeID; e._attendeeUrl = AttendeeUrl; e._attendeePhotoUrl = AttendeePhotoUrl; e._meetingID = MeetingID; e._meetingUrl = MeetingUrl; e._attended = Attended;  e._state = NeoEntityModel.EntityState.SET; }        
        // Factory methods // Template: NPCLevel1Part2_cs.txt
        private static MeetupAttendee _Initialize(MeetupAttendee e)
        {
            e._attendeeName = ""; e._attendeeID = ""; e._attendeeUrl = ""; e._attendeePhotoUrl = ""; e._meetingID = ""; e._meetingUrl = ""; e._attended = 0; 
            e._state = NeoEntityModel.EntityState.NULL;
            if (NeoTrace.RUNTIME) LogExt("_Initialize(e).MeetupAttendee", e);
            return e;
        }
        public static MeetupAttendee New()
        {
            MeetupAttendee e = new MeetupAttendee();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("New().MeetupAttendee", e);
            return e;
        }
        public static MeetupAttendee New(string AttendeeName, string AttendeeID, string AttendeeUrl, string AttendeePhotoUrl, string MeetingID, string MeetingUrl, BigInteger Attended)
        {
            MeetupAttendee e = new MeetupAttendee();
            e._attendeeName = AttendeeName; e._attendeeID = AttendeeID; e._attendeeUrl = AttendeeUrl; e._attendeePhotoUrl = AttendeePhotoUrl; e._meetingID = MeetingID; e._meetingUrl = MeetingUrl; e._attended = Attended; 
            e._state = NeoEntityModel.EntityState.INIT;
            if (NeoTrace.RUNTIME) LogExt("New(.,.).MeetupAttendee", e);
            return e;
        }
        public static MeetupAttendee Null()
        {
            MeetupAttendee e = new MeetupAttendee();
            _Initialize(e);
            if (NeoTrace.RUNTIME) LogExt("Null().MeetupAttendee", e);
            return e;
        }

        // EntityState wrapper methods
        public static bool IsNull(MeetupAttendee e)
        {
            return (e._state == NeoEntityModel.EntityState.NULL);
        }

        // Log/trace methods
        public static void Log(string label, MeetupAttendee e)
        {
            TraceRuntime(label, e._attendeeName, e._attendeeID, e._attendeeUrl, e._attendeePhotoUrl, e._meetingID, e._meetingUrl, e._attended);
        }
        public static void LogExt(string label, MeetupAttendee e)
        {
            TraceRuntime(label, e._attendeeName, e._attendeeID, e._attendeeUrl, e._attendeePhotoUrl, e._meetingID, e._meetingUrl, e._attended, e._state);
        }
    }
}