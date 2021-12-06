using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationLibrary.DTO
{
    public class NotificationsForAppDto
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public DateTime Date { get; set; }
        public bool Seen { get; set; }

        public NotificationsForAppDto() { }
        public NotificationsForAppDto(int id, string content, DateTime date, bool seen)
        {
            Id = id;
            Content = content;
            Date = date;
            Seen = seen;
        }
    }
}
