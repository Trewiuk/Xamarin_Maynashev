using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteTaratorki.Models
{
    public class PersonalInfo
    {
        [PrimaryKey, AutoIncrement]
        public int PersonalId { get; set; }
        public string PersonalSurname { get; set; }
        public string PersonalName { get; set; }
        public string PersonalPhone { get; set; }
        public string PersonalMiddlename { get; set; }
        public string PersonalExperience { get; set; }
        public string PersonalEducation { get; set; }
        public string PersonalClassification { get; set; }
    }
}
