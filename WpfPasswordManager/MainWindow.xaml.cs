using System.Windows;
using System.IO;
using Microsoft.Data.Sqlite;
using WpfPasswordManager.ViewModel;

namespace WpfPasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
        }
    }
}