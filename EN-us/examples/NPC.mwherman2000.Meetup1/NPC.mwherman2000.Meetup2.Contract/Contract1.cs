using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using NPC.Runtime;
using System;
using System.Numerics;

namespace NPC.mwherman2000.Meetup2.Contract
{
    public class Contract1 : SmartContract
    {
        public static MeetupAttendee Main()
        {
            // NEO Blockchain Toronto Meetup Attendee Test Data: 
            //
            // "Michael H.",
            // "2169884", "https://www.meetup.com/NEO-Blockchain-Toronto/members/2169884",
            // "https://secure.meetupstatic.com/photos/member/1/4/0/9/member_266165129.jpeg",
            // "phzmjpyxgbpb", "https://www.meetup.com/NEO-Blockchain-Toronto/events/phzmjpyxgbpb",
            // 0

            MeetupAttendee e1 = MeetupAttendee.New();

            MeetupAttendee.Set(e1, "Michael H.",
                "2169884", "https://www.meetup.com/NEO-Blockchain-Toronto/members/2169884",
                "https://secure.meetupstatic.com/photos/member/1/4/0/9/member_266165129.jpeg",
                "phzmjpyxgbpb", "https://www.meetup.com/NEO-Blockchain-Toronto/events/phzmjpyxgbpb",
                0
                );

            MeetupAttendee.Log("e1", e1);

            MeetupAttendee.Put(e1, "phzmjpyxgbpb" + "/" + "2169884");

            MeetupAttendee e2 = MeetupAttendee.Get("phzmjpyxgbpb" + "/" + "2169884xx");

            MeetupAttendee.Log("e2", e2);

            if (MeetupAttendee.IsMissing(e2))
            {
                NeoTrace.Trace("e2 was Missing from Storage");
            }
            else
            {
                NeoTrace.Trace("e2 was not Missing from Storage");
            }

            return e2;
        }
    }
}
