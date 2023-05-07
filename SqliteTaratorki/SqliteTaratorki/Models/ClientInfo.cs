using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteTaratorki.Models
{
    public class ClientInfo
    {
        [PrimaryKey,AutoIncrement]
        public int ClientId { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
        public string ClientMiddlename { get; set; }
        public string ClientBirthday { get; set; }
        public string ClientImage { get; set; }

    }
}
