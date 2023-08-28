using System;
using System.Collections.Generic;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TODO
            //https://github.com/PrismLibrary/Prism
            //https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master/01-BootstrapperShell
            //https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master/05-ViewInjection/ViewInjection/Views
            //DelegateCommand<T> (implementująca ICommand)
            //BindableBase (implementująca INotifyPropertyChanged)
            //https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master/08-ViewModelLocator (lokalizator modelu widoku)
        }
    }
}
