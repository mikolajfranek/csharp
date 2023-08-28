using System;
using WpfApp.Backend;

namespace WpfApp
{
    public class Student : PropertyNotificationSupport
    {
        private string imie = String.Empty;
        private string nazwisko = String.Empty;
        private int rokPrzyjeciaNaStudia;

        public string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                if (imie != value)
                {
                    imie = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }
            set
            {
                if (nazwisko != value)
                {
                    nazwisko = value;
                    OnPropertyChanged();
                }
            }
        }

        public int RokPrzyjeciaNaStudia
        {
            get
            {
                return rokPrzyjeciaNaStudia;
            }
            set
            {
                if (rokPrzyjeciaNaStudia != value)
                {
                    rokPrzyjeciaNaStudia = value;
                    OnPropertyChanged();
                    OnPropertyChanged("CzasStudiowania");
                }
            }
        }

        public string CzasStudiowania
        {
            get
            {
                return (DateTime.Now.Year - RokPrzyjeciaNaStudia).ToString();
            }
        }
    }
}