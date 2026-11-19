using DatingApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.classes
{
    public class MeetingInvitation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Client Initiator { get; set; }
        public Client Target { get; set; }
        public DateTime MeetingDate { get; set; }
        public MeetingStatus Status { get; set; } = MeetingStatus.Pending;
    }
}
