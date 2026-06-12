using System;
using System.ComponentModel;

namespace WpfOsoba
{
    public class Osoba : INotifyPropertyChanged
    {
        private string imieNazwisko;
        private string pierwszeImie;
        private string nazwisko;
        private string dataUrodzin;
        private int wiek;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nazwa)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nazwa));
        }

        public string ImieNazwisko
        {
            get { return imieNazwisko; }
            set
            {
                imieNazwisko = value;

                if (!string.IsNullOrWhiteSpace(value))
                {
                    string[] wyrazy =
                        value.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (wyrazy.Length > 0)
                    {
                        PierwszeImie = wyrazy[0];
                        Nazwisko = wyrazy[wyrazy.Length - 1];
                    }
                }

                OnPropertyChanged(nameof(ImieNazwisko));
            }
        }

        public string PierwszeImie
        {
            get { return pierwszeImie; }
            set
            {
                pierwszeImie = value;
                OnPropertyChanged(nameof(PierwszeImie));
            }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set
            {
                nazwisko = value;
                OnPropertyChanged(nameof(Nazwisko));
            }
        }

        public string DataUrodzin
        {
            get { return dataUrodzin; }
            set
            {
                dataUrodzin = value;

                if (DateTime.TryParse(value, out DateTime data))
                {
                    Wiek = ObliczWiek(data);
                }

                OnPropertyChanged(nameof(DataUrodzin));
            }
        }

        public int Wiek
        {
            get { return wiek; }
            set
            {
                wiek = value;
                OnPropertyChanged(nameof(Wiek));
            }
        }

        private int ObliczWiek(DateTime data)
        {
            int lata = DateTime.Now.Year - data.Year;

            if (DateTime.Now < data.AddYears(lata))
                lata--;

            return lata;
        }
    }
}