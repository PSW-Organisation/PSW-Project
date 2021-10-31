using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class UserFeedback
    {
        public int Id { get; set; }
        public DateTime TimeWritten { get; set; }
        public int Rating { get; set; }
        public String Content { get; set; }
        public Boolean IsDeleted { get; set; }

        public UserFeedback(int id, DateTime po, int r, string con)
        {
            TimeWritten = po;
            Rating = r;
            Content = con;
            IsDeleted = false;
        }
    }
}

