using System;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Mutex mutex;

        public MainWindow()
        {
            var name = Assembly.GetEntryAssembly()!.GetName().Name;
            mutex = new Mutex(true, name, out bool createdNew);
            if (createdNew == false)
                Environment.Exit(0);
            InitializeComponent();
            //TODO
            //- podział na moduły (jedna instancja, moduł uruchamiajacy) / wstrzykiwanie zależności?
            //- wstrzykiwanie widoków z zwalnianiem pamięci podczas przejścia z widoku do widoku,
            //- wpf style/widoki
            //- reaktywność,
            //- automatyczna aktualizacja
            //- logowanie z wylogowaniem zdalnym 
            //- poszukać inspiracji (https://github.com/PrismLibrary/Prism
            //https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master/01-BootstrapperShell
            //https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master/05-ViewInjection/ViewInjection/Views
            //https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master/08-ViewModelLocator
        }
    }
}
