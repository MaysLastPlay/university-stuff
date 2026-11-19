using DatingApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.classes
{
    public class Client
    {
        public string RegNumber { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public DateTime RegDate { get; set; }
        public string PersonalDetails { get; set; }
        public PartnerRequirements Requirements { get; set; }
        public ClientStatus Status { get; set; } = ClientStatus.Active;

        public override string ToString() => $"{RegNumber} | {FullName} ({Gender}, {Age}р.)";
    }
}
