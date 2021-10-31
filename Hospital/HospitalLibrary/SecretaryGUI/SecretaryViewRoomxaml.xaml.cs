using Model;
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
using System.Windows.Shapes;
using vezba.Repository;

namespace vezba.SecretaryGUI
{

    public partial class SecretaryViewRoom : Window
    {
        public ObservableCollection<RoomInventory> Equipment { get; set; }
        public SecretaryViewRoom(Room selectedRoom)
        {
            InitializeComponent();
            Name.Content += (selectedRoom.RoomNumber).ToString();
            Floor.Content = selectedRoom.RoomFloorName;
            Type.Content = selectedRoom.RoomTypeName;


            RoomInventoryFileRepository roomInventoryFileRepository = new RoomInventoryFileRepository();

            List<RoomInventory> roomInventoryList = new List<RoomInventory>();
            foreach (RoomInventory roomInventory in roomInventoryFileRepository.GetAll())
            {
                if (roomInventory.room.RoomNumber == selectedRoom.RoomNumber)
                {
                    if (DateTime.Compare(roomInventory.StartTime, DateTime.Now) <= 0 &&
                        DateTime.Compare(roomInventory.EndTime, DateTime.Now) >= 0)
                    {
                        roomInventoryList.Add(roomInventory);
                    }
                }
            }

            Equipment = new ObservableCollection<RoomInventory>(roomInventoryList);
            this.DataContext = this;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.Close();
        }
    }
}