using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.Meetup2.Contract.MeetupAttendee - Level 3 Deletable
///
/// Processed:      2018-03-21 9:15:47 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.40151
/// NPC Project:    https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:       Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.Meetup2.Contract
{
    public partial class MeetupAttendee : NeoTraceRuntime /* Level 3 Deletable */
    {
        // Deletable methods
        public static bool IsBuried(MeetupAttendee e)
        {
            return (e._state == NeoEntityModel.EntityState.TOMBSTONED);
        }

        public static MeetupAttendee Tombstone()
        {
            MeetupAttendee e = new MeetupAttendee();
            e._attendeeName = ""; e._attendeeID = ""; e._attendeeUrl = ""; e._attendeePhotoUrl = ""; e._meetingID = ""; e._meetingUrl = ""; e._attended = 0; 
            e._state = NeoEntityModel.EntityState.TOMBSTONED;
            if (NeoTrace.RUNTIME) LogExt("Tombstone().MeetupAttendee", e);
            return e;
        }

        public static MeetupAttendee Bury(byte[] key)
        {
            if (key.Length == 0) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            byte[] _bkeyTag = Helper.Concat(key, _bclassKeyTag);

            MeetupAttendee e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, Helper.Concat(_bkeyTag, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(bkey).bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = MeetupAttendee.Missing();
            }
            else // not MISSING - bury it
            {
                e = MeetupAttendee.Tombstone(); // but don't overwrite existing field values - just tombstone it
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bSTA), e._state.AsBigInteger());

                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeeName), e._attendeeName); // Template: NPCLevel3ABury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeeID), e._attendeeID); // Template: NPCLevel3ABury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeeUrl), e._attendeeUrl); // Template: NPCLevel3ABury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttendeePhotoUrl), e._attendeePhotoUrl); // Template: NPCLevel3ABury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bMeetingID), e._meetingID); // Template: NPCLevel3ABury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bMeetingUrl), e._meetingUrl); // Template: NPCLevel3ABury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, Helper.Concat(_bkeyTag, _bAttended), e._attended); // Template: NPCLevel3ABury_cs.txt
            } // Template: NPCLevel3BBury_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(bkey).MeetupAttendee", e); 
            return e; // return Entity e to signal if key is Missing or bad key
        }

        public static MeetupAttendee Bury(string key)
        {
            if (key.Length == 0) return Null(); 

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            string _skeyTag = key + _classKeyTag;

            MeetupAttendee e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, _skeyTag + _sSTA);
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(skey).MeetupAttendee.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = MeetupAttendee.Missing();
            }
            else // not MISSING - bury it
            {
                e = MeetupAttendee.Tombstone(); // but don't overwrite existing field values - just tombstone it
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sSTA, e._state.AsBigInteger());

                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeeName, e._attendeeName); // Template: NPCLevel3CBury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeeID, e._attendeeID); // Template: NPCLevel3CBury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeeUrl, e._attendeeUrl); // Template: NPCLevel3CBury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttendeePhotoUrl, e._attendeePhotoUrl); // Template: NPCLevel3CBury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sMeetingID, e._meetingID); // Template: NPCLevel3CBury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sMeetingUrl, e._meetingUrl); // Template: NPCLevel3CBury_cs.txt
                //Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, _skeyTag + _sAttended, e._attended); // Template: NPCLevel3CBury_cs.txt
            } // Template: NPCLevel3Part2_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(skey).MeetupAttendee", e);
            return e; // return Entity e to signal if key is Missing or bad key
        }
    }
}