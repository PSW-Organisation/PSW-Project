using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Model;
using Service;
using vezba.Adapter;
using vezba.Repository;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Page
    {
        public Grid dynamicGrid;
        private DoctorView doctorView;
        private DateTime startOfWeek;
        private DateTime endOfWeek;
        public static List<Appointment> appointments;
        private DockPanel timeDockPanel;
        public List<Doctor> Doctors { get; set; }
        private Doctor selectedDoctor;
        private ScrollViewer scrollViewer;
        private TextBlock mondayBlock;
        private TextBlock tuesdayBlock;
        private TextBlock wednesdayBlock;
        private TextBlock thursdayBlock;
        private TextBlock fridayBlock;
        private TextBlock saturdayBlock;
        private TextBlock sundayBlock;
        private AppointmentService appointmentService;
        private Dictionary<int, Grid> appointmentGrids;

        public Calendar(DoctorView doctorView)
        {
            InitializeComponent();
            appointmentGrids = new Dictionary<int, Grid>();
            appointmentService = new AppointmentService();
            this.doctorView = doctorView;
            DoctorService doctorService = new DoctorService();
            Doctors = doctorService.GetAllDoctors();
            DataContext = this;

            var dayOfWeekToday = (6 + (int) DateTime.Today.DayOfWeek) % 7;
            startOfWeek = DateTime.Today.AddDays(-dayOfWeekToday);
            endOfWeek = startOfWeek.AddDays(7);

            CreateSchedule();

            var timeGrid = CreateTimeGrid();

            timeDockPanel = new DockPanel();
            DockPanel.SetDock(timeGrid, Dock.Left);
            timeDockPanel.Children.Add(timeGrid);
            timeDockPanel.Children.Add(dynamicGrid);

            scrollViewer = new ScrollViewer();
            scrollViewer.Content = timeDockPanel;

            var daysOfWeekBorder = CreateDaysOfWeekBorder();

            DockPanel daysOfWeekDockPanel = new DockPanel();
            DockPanel.SetDock(daysOfWeekBorder, Dock.Top);
            daysOfWeekDockPanel.Children.Add(daysOfWeekBorder);
            daysOfWeekDockPanel.Children.Add(scrollViewer);
            CalendarGrid.Children.Add(daysOfWeekDockPanel);

            selectedDoctor = doctorView.DoctorUser;
            if (selectedDoctor != null && selectedDoctor.Jmbg != null)
                DoctorsComboBox.SelectedValue = selectedDoctor.Jmbg;
        }

        private Border CreateDaysOfWeekBorder()
        {
            Grid daysOfWeekGrid = new Grid();
            daysOfWeekGrid.Height = 50;

            Border daysOfWeekBorder = new Border();
            daysOfWeekBorder.BorderThickness = new Thickness(0, 0, 0, 1);
            daysOfWeekBorder.BorderBrush = Brushes.Gray;

            daysOfWeekGrid.ColumnDefinitions.Add(new ColumnDefinition() {Width = new GridLength(50)});

            for (int i = 0; i < 7; i++)
            {
                daysOfWeekGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            mondayBlock = new TextBlock();
            mondayBlock.HorizontalAlignment = HorizontalAlignment.Center;
            mondayBlock.VerticalAlignment = VerticalAlignment.Bottom;
            mondayBlock.Foreground = Brushes.DimGray;
            mondayBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            Grid.SetColumn(mondayBlock, 1);
            daysOfWeekGrid.Children.Add(mondayBlock);

            tuesdayBlock = new TextBlock();
            tuesdayBlock.HorizontalAlignment = HorizontalAlignment.Center;
            tuesdayBlock.VerticalAlignment = VerticalAlignment.Bottom;
            tuesdayBlock.Foreground = Brushes.DimGray;
            tuesdayBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            Grid.SetColumn(tuesdayBlock, 2);
            daysOfWeekGrid.Children.Add(tuesdayBlock);

            wednesdayBlock = new TextBlock();
            wednesdayBlock.HorizontalAlignment = HorizontalAlignment.Center;
            wednesdayBlock.VerticalAlignment = VerticalAlignment.Bottom;
            wednesdayBlock.Foreground = Brushes.DimGray;
            wednesdayBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            Grid.SetColumn(wednesdayBlock, 3);
            daysOfWeekGrid.Children.Add(wednesdayBlock);

            thursdayBlock = new TextBlock();
            thursdayBlock.HorizontalAlignment = HorizontalAlignment.Center;
            thursdayBlock.VerticalAlignment = VerticalAlignment.Bottom;
            thursdayBlock.Foreground = Brushes.DimGray;
            thursdayBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            Grid.SetColumn(thursdayBlock, 4);
            daysOfWeekGrid.Children.Add(thursdayBlock);

            fridayBlock = new TextBlock();
            fridayBlock.HorizontalAlignment = HorizontalAlignment.Center;
            fridayBlock.VerticalAlignment = VerticalAlignment.Bottom;
            fridayBlock.Foreground = Brushes.DimGray;
            fridayBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            Grid.SetColumn(fridayBlock, 5);
            daysOfWeekGrid.Children.Add(fridayBlock);

            saturdayBlock = new TextBlock();
            saturdayBlock.HorizontalAlignment = HorizontalAlignment.Center;
            saturdayBlock.VerticalAlignment = VerticalAlignment.Bottom;
            saturdayBlock.Foreground = Brushes.DimGray;
            saturdayBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            Grid.SetColumn(saturdayBlock, 6);
            daysOfWeekGrid.Children.Add(saturdayBlock);

            sundayBlock = new TextBlock();
            sundayBlock.HorizontalAlignment = HorizontalAlignment.Center;
            sundayBlock.VerticalAlignment = VerticalAlignment.Bottom;
            sundayBlock.Foreground = Brushes.DimGray;
            sundayBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            Grid.SetColumn(sundayBlock, 7);
            daysOfWeekGrid.Children.Add(sundayBlock);

            UpdateDateIndicators();

            daysOfWeekBorder.Child = daysOfWeekGrid;
            return daysOfWeekBorder;
        }

        private static Grid CreateTimeGrid()
        {
            Grid timeGrid = new Grid();
            timeGrid.Height = 3000;
            timeGrid.Width = 50;
            for (int i = 0; i < 24; i++)
            {
                timeGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < timeGrid.RowDefinitions.Count; i++)
            {
                TextBlock timeBlock = new TextBlock();
                timeBlock.Text = "" + i;
                timeBlock.FontSize = 14;
                timeBlock.Foreground = Brushes.DimGray;
                timeBlock.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(timeBlock, i);
                timeGrid.Children.Add(timeBlock);
            }

            return timeGrid;
        }

        public void SetScrollViewerToFirstAppointment()
        {
            if(appointments.Count == 0)
                return;
            var earliestTime = appointmentService.GetEarliestTime(appointments);
            var scrollOffset = (earliestTime.Hours + (double)earliestTime.Minutes / 60) * dynamicGrid.Height / 24;
            scrollViewer.ScrollToVerticalOffset(scrollOffset);
        }

        private void CreateSchedule()
        {
            dynamicGrid = new Grid();
            dynamicGrid.Height = 3000;
            for (int i = 0; i < 24; i++)
            {
                dynamicGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 7; i++)
            {
                dynamicGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < dynamicGrid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < dynamicGrid.ColumnDefinitions.Count; j++)
                {
                    Border innerGridBorder = new Border();
                    innerGridBorder.BorderBrush = Brushes.Gray;
                    innerGridBorder.BorderThickness = new Thickness(0.3);
                    Grid innerGrid = new Grid();
                    innerGrid.Background = Brushes.Transparent;
                    var generatedStartTime = startOfWeek.AddDays(j);
                    generatedStartTime = generatedStartTime.AddHours(i);
                    innerGrid.MouseLeftButtonDown += (sen, evg) =>
                    {
                        doctorView.Main.Content = new CreateAppointment(doctorView, new CalendarAdapter(this), generatedStartTime, selectedDoctor);
                    };
                    innerGrid.MouseEnter += (sen, evg) =>
                    {
                        var bc = new BrushConverter();
                        innerGrid.Background = (Brush)bc.ConvertFrom("#FFE0E0E0");

                    };
                    innerGrid.MouseLeave += (sen, evg) =>
                    {
                        innerGrid.Background = Brushes.White;
                    };
                    innerGridBorder.Child = innerGrid;
                    Grid.SetRow(innerGridBorder, i);
                    Grid.SetColumn(innerGridBorder, j);
                    dynamicGrid.Children.Add(innerGridBorder);
                }
            }
        }

        private void GenerateAppointmentsForWeekAndDoctor()
        {
            appointments = appointmentService.GenerateAppointmentsForWeekAndDoctor(startOfWeek, endOfWeek, selectedDoctor);
            CreateSchedule();
            appointmentGrids.Clear();
            foreach (var appointment in appointments)
            {
                ShowAppointment(appointment);
            }
            timeDockPanel.Children.Add(dynamicGrid);
            SetScrollViewerToFirstAppointment();
        }

        public void ShowAppointment(Appointment appointment)
        {
            var row = appointment.StartTime.Hour;
            var rowSpan = (appointment.StartTime.Minute + appointment.DurationInMunutes) / (int)60 + 1;
            var topMargin = appointment.StartTime.Minute * dynamicGrid.Height / 1440 + 1;
            var bottomMargin = rowSpan * dynamicGrid.Height / 24 - topMargin - appointment.DurationInMunutes * dynamicGrid.Height / 1440 + 1;
            var col = (6 + (int)appointment.StartTime.DayOfWeek) % 7;
            Grid appointmentGrid = new Grid();
            appointmentGrid.Margin = new Thickness(1, topMargin, 1, bottomMargin);
            appointmentGrid.Background = Brushes.CornflowerBlue;
            appointmentGrid.MouseEnter += (sen, evg) =>
            {
                var bc = new BrushConverter();
                appointmentGrid.Background = (Brush)bc.ConvertFrom("#FF3075F0");

            };
            appointmentGrid.MouseLeave += (sen, evg) =>
            {
                appointmentGrid.Background = Brushes.CornflowerBlue;
            };
            appointmentGrids.Add(appointment.AppointentId, appointmentGrid);
            appointmentGrid.MouseLeftButtonDown += (sen, evg) =>
            {
                appointment = appointmentService.GetAppointmentById(appointment.AppointentId);
                doctorView.Main.Content = new ViewAppointmentPage(appointment, doctorView, new CalendarAdapter(this));
            };
            Grid.SetRow(appointmentGrid, row);
            Grid.SetColumn(appointmentGrid, col);
            Grid.SetRowSpan(appointmentGrid, rowSpan);

            appointmentGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            appointmentGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            appointmentGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            appointmentGrid.RowDefinitions.Add(new RowDefinition());

            TextBlock appointmentDescriptionBlock = new TextBlock();
            appointmentDescriptionBlock.Text = appointment.ApointmentDescription;
            appointmentDescriptionBlock.Foreground = Brushes.White;
            appointmentDescriptionBlock.FontSize = 10;
            appointmentDescriptionBlock.FontWeight = FontWeights.Bold;
            appointmentDescriptionBlock.TextWrapping = TextWrapping.WrapWithOverflow;
            appointmentDescriptionBlock.Margin = new Thickness(5, 5, 5, 0);
            Grid.SetRow(appointmentDescriptionBlock, 0);
            appointmentGrid.Children.Add(appointmentDescriptionBlock);

            TextBlock doctorBlock = new TextBlock();
            doctorBlock.Text = "Lekar: " + appointment.Doctor.NameAndSurname;
            doctorBlock.Foreground = Brushes.White;
            doctorBlock.FontSize = 10;
            doctorBlock.TextWrapping = TextWrapping.WrapWithOverflow;
            doctorBlock.Margin = new Thickness(5, 0, 5, 0);
            Grid.SetRow(doctorBlock, 1);
            appointmentGrid.Children.Add(doctorBlock);


            TextBlock patientBlock = new TextBlock();
            patientBlock.Text = "Pacijent: " + appointment.Patient.NameAndSurname;
            patientBlock.Foreground = Brushes.White;
            patientBlock.FontSize = 10;
            patientBlock.TextWrapping = TextWrapping.WrapWithOverflow;
            patientBlock.Margin = new Thickness(5, 0, 5, 0);
            Grid.SetRow(patientBlock, 2);
            appointmentGrid.Children.Add(patientBlock);

            TextBlock roomBlock = new TextBlock();
            roomBlock.Text = "Soba: " + appointment.Room.RoomNumber;
            roomBlock.Foreground = Brushes.White;
            roomBlock.FontSize = 10;
            roomBlock.TextWrapping = TextWrapping.WrapWithOverflow;
            roomBlock.Margin = new Thickness(5, 0, 5, 5);
            Grid.SetRow(roomBlock, 3);
            appointmentGrid.Children.Add(roomBlock);

            dynamicGrid.Children.Add(appointmentGrid);
        }

        public void RemoveAppointment(Appointment appointment)
        {
            var appointmentGrid = appointmentGrids[appointment.AppointentId];
            dynamicGrid.Children.Remove(appointmentGrid);
            appointmentGrids.Remove(appointment.AppointentId);
            SetScrollViewerToFirstAppointment();
        }

        private void NewAppointmentClick(object sender, RoutedEventArgs e)
        {
            doctorView.Main.Content = new CreateAppointment(doctorView, new CalendarAdapter(this), selectedDoctor);
        }

        private void PreviousWeekClick(object sender, RoutedEventArgs e)
        {
            timeDockPanel.Children.Remove(dynamicGrid);
            startOfWeek = startOfWeek.AddDays(-7);
            endOfWeek = endOfWeek.AddDays(-7);
            UpdateDateIndicators();
            GenerateAppointmentsForWeekAndDoctor();
        }

        private void UpdateDateIndicators()
        {
            var monday = startOfWeek;
            var tuesday = monday.AddDays(1);
            var wednesday = tuesday.AddDays(1);
            var thursday = wednesday.AddDays(1);
            var friday = thursday.AddDays(1);
            var saturday = friday.AddDays(1);
            var sunday = saturday.AddDays(1);
            MonthYearBlock.Text = monday.ToString("d") + " - " + sunday.ToString("d");
            mondayBlock.Text = "Ponedeljak " + monday.Day + "." + monday.Month + ".";
            tuesdayBlock.Text = "Utorak " + tuesday.Day + "." + tuesday.Month + ".";
            wednesdayBlock.Text = "Sreda " + wednesday.Day + "." + wednesday.Month + ".";
            thursdayBlock.Text = "Četvrtak " + thursday.Day + "." + thursday.Month + ".";
            fridayBlock.Text = "Petak " + friday.Day + "." + friday.Month + ".";
            saturdayBlock.Text = "Subota " + saturday.Day + "." + saturday.Month + ".";
            sundayBlock.Text = "Nedelja " + sunday.Day + "." + sunday.Month + ".";
        }

        private void NextWeekClick(object sender, RoutedEventArgs e)
        {
            timeDockPanel.Children.Remove(dynamicGrid);
            startOfWeek = startOfWeek.AddDays(7);
            endOfWeek = endOfWeek.AddDays(7);
            UpdateDateIndicators();
            GenerateAppointmentsForWeekAndDoctor();
        }

        
        private void SelectedDoctorChanged(object sender, SelectionChangedEventArgs e)
        {
            timeDockPanel.Children.Remove(dynamicGrid);
            selectedDoctor = (Doctor)DoctorsComboBox.SelectedItem;
            GenerateAppointmentsForWeekAndDoctor();
        }
        
        public void AddAppointmentToCurrentView(Appointment appointment)
        {
            if (appointmentService.IsAppointmentInCurrentView(appointment, startOfWeek, endOfWeek, selectedDoctor))
            {
                appointments.Add(appointment);
                ShowAppointment(appointment);
                SetScrollViewerToFirstAppointment();
            }
        }
    }
}
