using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Command;

namespace vezba.SecretaryGUI.SecretaryViewModel
{
    class ViewAnnouncementVM
    {
        private SecretaryViewAnnouncement window;
        public string PostedDate { get; set; }
        public string EditedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ViewAnnouncementVM(Announcement a, SecretaryViewAnnouncement window)
        {
            PostedDate = a.FormatedDatePosted;
            EditedDate = "(izmenjeno " + a.FormatedDateEdited + ")";
            /*if (a.FormatedDatePosted.Equals(a.FormatedDateEdited))
            {
                EditedDate.Visibility = System.Windows.Visibility.Collapsed;
            }*/
            Title = a.Title;
            Content = a.Content;
            this.window = window;
            SetCommands();
        }

        public RelayCommand CloseCommand { get; private set; }

        private void CloseViewAnnouncementWindow(object parameter)
        {
            window.Close();
        }
        private void SetCommands()
        {
            CloseCommand = new RelayCommand(CloseViewAnnouncementWindow);
        }
    }
}
