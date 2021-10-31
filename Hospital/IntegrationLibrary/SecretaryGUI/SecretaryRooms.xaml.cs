using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using vezba.Template;

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryRooms.xaml
    /// </summary>
    public partial class SecretaryRooms : Page
    {
        public ObservableCollection<Room> Rooms { get; set; }
        public SecretaryRooms()
        {
            InitializeComponent();
            this.DataContext = this;
            RoomService roomService = new RoomService();
            Rooms = new ObservableCollection<Room>(roomService.GetAllRooms());
        }

        private void ViewRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (roomsTable.SelectedCells.Count > 0)
            {
                Room selectedRoom = (Room)roomsTable.SelectedItem;
                SecretaryViewRoom w = new SecretaryViewRoom(selectedRoom);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m2 = new SecretaryMessage("Niste selektovali prostoriju.");
            m2.ShowDialog();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Rooms.Clear();
                RoomService roomService = new RoomService();
                List<Room> rooms = new List<Room>();
                String input = SearchBox.Text;
                if (input.Trim().Equals(""))
                {
                    foreach (Room r in roomService.GetAllRooms())
                    {
                        Rooms.Add(r);
                    }
                    return;
                }
                rooms = DoSearch<Room>.GetSearchResult(new SearchRooms(), input);
                //rooms = roomService.GetSearchResultRooms(search);
                foreach (Room r in rooms)
                {
                    Rooms.Add(r);
                }
            }
        }
        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
                this.ViewRoomButton_Click(sender, e);
        }
    }
}