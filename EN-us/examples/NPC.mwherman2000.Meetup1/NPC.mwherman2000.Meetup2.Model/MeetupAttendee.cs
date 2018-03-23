using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC.mwherman2000.Meetup2.Model
{
    public interface NPCLevel0Basic { }
    public interface NPCLevel1Managed { }
    public interface NPCLevel2Persistable { }
    public interface NPCLevel3Deletable { }
    public interface NPCLevel4Collectible { }
    public interface NPCLevel4CollectibleExt { }
    public interface NPCLevel4CustomMethods { }

    public class MeetupAttendee : NPCLevel0Basic,
                                 NPCLevel1Managed,
                                 NPCLevel2Persistable,
                                 NPCLevel3Deletable,
                                 NPCLevel4Collectible,
                                 NPCLevel4CollectibleExt
    {
        public string AttendeeName;
        public string AttendeeID;
        public string AttendeeUrl;
        public string AttendeePhotoUrl;
        public string MeetingID;
        public string MeetingUrl;
        public bool Attended;

        public MeetupAttendee(string attendeeName, string attendeeId, string attendeeUrl, string attendeePhotoUrl,
                                string meetingID, string meetingUrl,
                                string dateRegistered, 
                                bool attended)
        {
            this.AttendeeName = attendeeName;
            this.AttendeeID = attendeeId;
            this.AttendeeUrl = attendeeUrl;
            this.AttendeePhotoUrl = attendeePhotoUrl;
            this.MeetingID = meetingID;
            this.MeetingUrl = meetingUrl;
            this.Attended = attended;
        }
    }
}
