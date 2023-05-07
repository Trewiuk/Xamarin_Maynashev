using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteTaratorki.Models
{
    public class NoteInfo
    {
        [PrimaryKey, AutoIncrement]
        public int NoteId { get; set; }
        public string NoteDate { get; set; }
        public string NoteTime { get; set; }
        public string NoteClient { get; set; }
        public string NoteYsluga { get; set; }
        public string NoteCabinet { get; set; }
        public string NotePersonal { get; set; }
        public string NoteAction { get; set; }
    }
}
