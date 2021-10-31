using System;
using System.Collections.Generic;

namespace Model
{
   public class Announcement
   {
        public Announcement(int id, DateTime po, DateTime ed, string tit, string con, Visibility vis)
        {
            Id = id;
            Posted = po;
            Edited = ed;
            Title = tit;
            Content = con;
            Visibility = vis;
            IsDeleted = false;
            Recipients = new List<String>();
        }

        public int Id { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Edited { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public Boolean IsDeleted { get; set; }
        public Visibility Visibility { get; set; }
        public List<String> Recipients { get; set; }

        public string FormatedDatePosted
        {
            get
            {
                return Posted.ToString("dd.MM.yyyy.");
            }
        }
        public string FormatedDateEdited
        {
            get
            {
                return Edited.ToString("dd.MM.yyyy.");
            }
        }

        public void AddRecipient(String recipient)
        {
            Recipients.Add(recipient);
        }
   }
}