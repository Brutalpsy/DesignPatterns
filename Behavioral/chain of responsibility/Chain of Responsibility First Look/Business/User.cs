using System;
using System.Globalization;

namespace Chain_of_Responsibility_First_Look.Business
{
    public class User
    {
        public User(string Name, string SocialSecurityNumber, RegionInfo RegionInfo, DateTimeOffset DateOfBirth)
        {
            this.Name = Name;
            this.SocialSecurityNumber = SocialSecurityNumber;
            this.RegionInfo = RegionInfo;
            this.DateOfBirth = DateOfBirth;
        }

        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }
        public RegionInfo RegionInfo { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
    }
}
