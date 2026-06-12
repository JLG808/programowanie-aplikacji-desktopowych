using System.Windows;
using WpfOsoba;

namespace PAD_zad3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Osoba();
        }
    }
}