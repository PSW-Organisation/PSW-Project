using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Note
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Time { get; set; }
        public String NoteContent { get; set; }

        public Note(DateTime start, DateTime end, DateTime time, String content)
        {
            this.StartDate = start;
            this.EndDate = end;
            this.Time = time;
            this.NoteContent = content;
        }

        override
        public String ToString()
        {
            return NoteContent;
        }
    }
}
