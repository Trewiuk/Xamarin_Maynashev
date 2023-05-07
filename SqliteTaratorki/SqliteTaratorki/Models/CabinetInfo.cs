using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SqliteTaratorki.Models
{
    public class CabinetInfo
    {
        [PrimaryKey, AutoIncrement]
        public int CabinetId { get; set; }

        public string CabinetName { get; set; }

        public string Description { get; set; }

    }
}
