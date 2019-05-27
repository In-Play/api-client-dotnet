using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Play.Api.Client.Models.Direct
{
    public class UserDataModel
        {
            public UserInfo UserInfo { get; set; }
            public UserPreferences UserPreferences { get; set; }
            public UserMoneyData AccountData { get; set; }
        }


        public class UserInfo
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Type { get; set; }
            public bool EmailConfirmed { get; set; }
            public bool PhoneConfirmed { get; set; }
            public DateTime? SelfExclusion { get; set; }
            public string Role { get; set; }
            public string PromoCode { get; set; }
            public DateTime InsertedDate { get; set; }

        }

        public class UserPreferences
        {
            public bool IsBettor { get; set; }
            public bool IsTrade { get; set; }
            public bool MailNews { get; set; }
            public bool MailUpdates { get; set; }
            public bool MailActivity { get; set; }
            public string MailFrequency { get; set; }
            public bool SmsActivity { get; set; }
            public bool SmsUpdates { get; set; }
        }

        public class UserMoneyData
        {
           public decimal Profitlost { get; set; }
           public decimal Exposure { get; set; }
           public decimal Available { get; set; }
        }

}

