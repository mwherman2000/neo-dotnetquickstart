using NPC.Runtime;
using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// NPC.mwherman2000.Meetup2.Contract.MeetupAttendee - Level 4 Collectible
///
/// Processed:      2018-03-21 9:15:47 AM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v2.1.0.40151
/// NPC Project:    https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:       Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.mwherman2000.Meetup2.Contract
{
    public partial class MeetupAttendee : NeoTraceRuntime /* Level 4 Collectible */
    {
        /// <summary>
        /// Collectible methods (NPC Level 4)
        /// </summary>
        /// <param name="e">e</param>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>bool</returns>
        public static bool PutElement(MeetupAttendee e, NeoVersionedAppUser vau, byte[] domain, int index)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return false;

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            e._state = NeoEntityModel.EntityState.PUTTED;
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA), e._state.AsBigInteger());
 
            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeName), e._attendeeName); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeID), e._attendeeID); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeUrl), e._attendeeUrl); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeePhotoUrl), e._attendeePhotoUrl); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bMeetingID), e._meetingID); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bMeetingUrl), e._meetingUrl); // Template: NPCLevel4APutElement_cs.txt

            Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttended), e._attended); // Template: NPCLevel4APutElement_cs.txt

            if (NeoTrace.RUNTIME) LogExt("PutElement(vau,i).MeetupAttendee", e); // Template: NPCLevel4BGetElement_cs.txt
            return true;
        }

        /// <summary>
        /// Get an element of an array of entities from Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>MeetupAttendee</returns>
        public static MeetupAttendee GetElement(NeoVersionedAppUser vau, byte[] domain, int index)
        {
            if (NeoVersionedAppUser.IsNull(vau)) return Null();

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            MeetupAttendee e;
            //byte[] bkey;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Get(bkey).MeetupAttendee.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = MeetupAttendee.Missing();
            }
            else // not MISSING
            {
                int ista = (int)bsta.AsBigInteger();
                NeoEntityModel.EntityState sta = (NeoEntityModel.EntityState)ista;
                if (sta == NeoEntityModel.EntityState.TOMBSTONED)
                {
                    e = MeetupAttendee.Tombstone();
                }
                else // not MISSING && not TOMBSTONED
                {
                    e = new MeetupAttendee();
                    string AttendeeName = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeName)).AsString(); // Template: NPCLevel4CGetElement_cs.txt

                    string AttendeeID = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeID)).AsString(); // Template: NPCLevel4CGetElement_cs.txt

                    string AttendeeUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeUrl)).AsString(); // Template: NPCLevel4CGetElement_cs.txt

                    string AttendeePhotoUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeePhotoUrl)).AsString(); // Template: NPCLevel4CGetElement_cs.txt

                    string MeetingID = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bMeetingID)).AsString(); // Template: NPCLevel4CGetElement_cs.txt

                    string MeetingUrl = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bMeetingUrl)).AsString(); // Template: NPCLevel4CGetElement_cs.txt

                    BigInteger Attended = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttended)).AsBigInteger(); // Template: NPCLevel4CGetElement_cs.txt

                    e._attendeeName = AttendeeName; e._attendeeID = AttendeeID; e._attendeeUrl = AttendeeUrl; e._attendeePhotoUrl = AttendeePhotoUrl; e._meetingID = MeetingID; e._meetingUrl = MeetingUrl; e._attended = Attended;  // NPCLevel4DBuryElement_cs.txt
                    e._state = sta;
                    e._state = NeoEntityModel.EntityState.GETTED; /* OVERRIDE */
                }
            }
            if (NeoTrace.RUNTIME) LogExt("Get(bkey).MeetupAttendee.e", e);
            return e;
        }

        /// <summary>
        /// Bury an element of an array of entities in Storage based on a NeoStorageKey (NPC Level 4)
        /// </summary>
        /// <param name="vau">vau</param>
        /// <param name="index">index</param>
        /// <returns>MeetupAttendee</returns>
        public static MeetupAttendee BuryElement(NeoVersionedAppUser vau, byte[] domain, int index)
        {
            if (NeoVersionedAppUser.IsNull(vau)) // TODO - create NeoEntityModel.EntityState.BADKEY?
            {
                return MeetupAttendee.Null();
            }

            Neo.SmartContract.Framework.Services.Neo.StorageContext ctx = Neo.SmartContract.Framework.Services.Neo.Storage.CurrentContext;
            NeoStorageKey nsk = NeoStorageKey.New(vau, domain, _bClassName);

            //byte[] bkey;
            MeetupAttendee e;
            byte[] bsta = Neo.SmartContract.Framework.Services.Neo.Storage.Get(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA));
            if (NeoTrace.RUNTIME) TraceRuntime("Bury(vau,index).MeetupAttendee.bsta", bsta.Length, bsta);
            if (bsta.Length == 0)
            {
                e = MeetupAttendee.Missing();
            }
            else // not MISSING - bury it
            {
                e = MeetupAttendee.Tombstone(); // TODO - should Bury() preserve the exist field values or re-initialize them? Preserve is cheaper but not as private
                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bSTA), e._state.AsBigInteger());

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeName), e._attendeeName); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeID), e._attendeeID); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeeUrl), e._attendeeUrl); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttendeePhotoUrl), e._attendeePhotoUrl); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bMeetingID), e._meetingID); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bMeetingUrl), e._meetingUrl); // NPCLevel4EBuryElement_cs.txt

                Neo.SmartContract.Framework.Services.Neo.Storage.Put(ctx, NeoStorageKey.StorageKey(nsk, index, _bAttended), e._attended); // NPCLevel4EBuryElement_cs.txt

            } // Template: NPCLevel4Part2_cs.txt
            if (NeoTrace.RUNTIME) LogExt("Bury(vau,i).MeetupAttendee", e);
            return e;
        }
    }
}