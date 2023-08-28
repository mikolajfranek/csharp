using System;
using System.Windows;
using WpfApp.Backend;

namespace WpfApp
{
    class StudentViewModel : PropertyNotificationSupport
    {
        private Student _kursant;
        public Student Kursant
        {
            get { return _kursant; }
            set
            {
                _kursant = value;
                OnPropertyChanged();
            }
        }
        public MyCommand Wyczysc { get; set; }

        public StudentViewModel()
        {
            _kursant = new Student
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                RokPrzyjeciaNaStudia = 2014
            };
            Wyczysc = new MyCommand(WyczyscDane);
        }

        private void WyczyscDane()
        {
            if (MessageBox.Show("Czy wyczyścić dane studenta?", "Pytanie",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Kursant.Imie = String.Empty;
                Kursant.Nazwisko = String.Empty;
                Kursant.RokPrzyjeciaNaStudia = DateTime.Now.Year;
            }
        }
    }
}
